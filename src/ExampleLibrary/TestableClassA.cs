using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleLibrary
{

    public class TestableClassA
    {

        [TestMe.NoParameters(true)]
        public bool ReturnTrue() => true;

        [TestMe.NoParameters(false)]
        public bool ReturnFalse() => false;

        [TestMe.SingleParameter(1, 2)]
        [TestMe.SingleParameter(2, 4)]
        public int TimesTwo(int value) => value * 2;

    }

}
