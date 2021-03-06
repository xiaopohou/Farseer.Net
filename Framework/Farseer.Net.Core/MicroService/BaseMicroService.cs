﻿// ********************************************
// 作者：何达贤（steden） QQ：11042427
// 时间：2017-03-02 14:09
// ********************************************

using System;
using System.ServiceModel;
using System.Threading.Tasks;
using FS.Core.Net;
using FS.Core.Net.Gateway;
using FS.Extends;

namespace FS.Core.MicroService
{
    /// <summary>
    /// 微服务基类
    /// </summary>
    public abstract class BaseMicroService : AbsBaseService
    {
        /// <summary>
        /// 微服务基类
        /// </summary>
        public BaseMicroService(GatewayHeaderVO header) : base(header) { }

        /// <summary>
        /// 调用的业务逻辑
        /// </summary>
        protected abstract Task<ApiResponseJson> Invoke();

        /// <summary>
        /// 带实体类检查的调用
        /// </summary>
        public async Task<ApiResponseJson> InvokeCheck()
        {
            try
            {
#if !DEBUG
            // 网关效验
            var gatewayResult = GatewayValidate();
            if (!gatewayResult.Status) { return gatewayResult; }
#endif
                return await Invoke();
            }
            catch (AggregateException exp)
            {
                var err = string.Empty;
                var statusCode = 500;
                foreach (var inner in exp.InnerExceptions)
                {
                    err += inner.Message;
                    var exception = inner as FaultException;
                    if (exception != null) { statusCode = exception.Code.Name.ConvertType(0); }
                }
                return ApiResponseJson.Error(err, null, statusCode);
            }
            catch (FaultException exp)
            {
                return ApiResponseJson.Error(exp.Message, exp.Action, exp.Code.Name.ConvertType(0));
            }
            catch (System.Exception exp)
            {
                return ApiResponseJson.Error(exp.Message, null, 500);
            }
        }
    }
}