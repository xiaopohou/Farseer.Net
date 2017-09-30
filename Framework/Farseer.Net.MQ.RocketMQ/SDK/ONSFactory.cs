//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

namespace Farseer.Net.MQ.RocketMQ.SDK
{
    public class ONSFactory : IDisposable
    {
        private HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal ONSFactory(IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new HandleRef(this, cPtr);
        }

        internal static HandleRef getCPtr(ONSFactory obj) { return obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr; }

        ~ONSFactory() { Dispose(); }

        public virtual void Dispose()
        {
            lock (this)
            {
                if (swigCPtr.Handle != IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        ONSClient4CPPPINVOKE.delete_ONSFactory(swigCPtr);
                    }
                    swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public static ONSFactoryAPI getInstance()
        {
            var cPtr = ONSClient4CPPPINVOKE.ONSFactory_getInstance();
            var ret = cPtr == IntPtr.Zero ? null : new ONSFactoryAPI(cPtr, false);
            return ret;
        }
    }
}