using System;

namespace lab.core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AutoDisposeAttribute : Attribute
    {
        public AutoDisposeAttribute(Type type)
        {
            TypeToDispose = type;
        }

        public Type TypeToDispose { get; }
    }
}