using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestMe
{

    public class SingleParameterAttribute : TestAttributeBase
    {

        public SingleParameterAttribute(object parameter, object expectedValue) : base(expectedValue, new object[] { parameter })
        {
        }

    }

}
