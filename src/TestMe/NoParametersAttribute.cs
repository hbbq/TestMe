using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
