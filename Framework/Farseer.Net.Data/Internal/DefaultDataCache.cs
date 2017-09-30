﻿using System.Collections;
using System.Collections.Generic;
using Farseer.Net.Data.Cache;
using Farseer.Net.Data.Infrastructure;

namespace Farseer.Net.Data.Internal
{
    /// <summary>
    /// 默认的表、视图数据缓存处理方式（不支持分布式）
    /// </summary>
    public class DefaultDataCache<TEntity> : IDataCache<TEntity> where TEntity : class, new()
    {
        public DefaultDataCache(AbsDbSet set)
        {
            _set = set;
        }

        private readonly AbsDbSet _set;

        public IEnumerable<TEntity> Get()
        {
            return EntityCacheManger.Cache<TEntity>(_set.SetMap.PhysicsMap, () =>
            {
                var expBuilder = new ExpressionBuilder(_set.SetMap);
                expBuilder.DeleteSortCondition();
                return _set.Context.Executeor.ToList<TEntity>(_set.Context.DbProvider.CreateSqlBuilder(expBuilder, _set.SetMap.Name).ToList());
            });
        }

        public void Update(IEnumerable<TEntity> lst)
        {
            EntityCacheManger.Update(_set.SetMap.PhysicsMap, (IList)lst);
        }
    }
}