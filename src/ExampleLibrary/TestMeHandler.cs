using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Xunit;

namespace ExampleLibrary
{

    public class TestMeHandler
    {

        [Theory]
        [MemberData(nameof(GetTests))]
        public void Test(string description, params object[] parameters) => TestMe.Engine.DoTest(Assembly.GetExecutingAssembly(), parameters);

        public static IEnumerable<object[]> GetTests => TestMe.Engine.GetTestMethods(Assembly.GetExecutingAssembly());

    }

}
