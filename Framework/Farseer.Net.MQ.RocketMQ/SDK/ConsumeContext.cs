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

namespace FS.MQ.RocketMQ.SDK
{
    public class ConsumeContext : IDisposable
    {
        private HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal ConsumeContext(IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new HandleRef(this, cPtr);
        }

        internal static HandleRef getCPtr(ConsumeContext obj) { return obj == null ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr; }

        ~ConsumeContext() { Dispose(); }

        public virtual void Dispose()
        {
            lock (this)
            {
                if (swigCPtr.Handle != IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        ONSClient4CPPPINVOKE.delete_ConsumeContext(swigCPtr);
                    }
                    swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public ConsumeContext() : this(ONSClient4CPPPINVOKE.new_ConsumeContext(), true) { }
    }
}