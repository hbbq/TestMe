using System;

namespace TestMe
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class NoParametersAttribute : TestAttributeBase
    {

        public NoParametersAttribute(object expectedValue) : base(expectedValue, null)
        {
        }

    }

}
