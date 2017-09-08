using System.Collections.Generic;
using System.Reflection;
using TestMe;
using Xunit;

namespace ExampleLibrary
{

    public class TestMeHandler
    {

        [Theory]
        [MemberData(nameof(GetTests))]
        public void Test(string description, params object[] parameters) => Engine.DoTest(parameters);

        public static IEnumerable<object[]> GetTests() => Engine.GetTestMethods(Assembly.GetExecutingAssembly());

    }

}
