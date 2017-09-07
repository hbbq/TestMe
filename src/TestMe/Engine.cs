using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Shouldly;

namespace TestMe
{

    public class Engine
    {

        public static IEnumerable<object[]> GetTestMethods(Assembly assembly)
        {
            var list = assembly.GetTypes()
                .SelectMany(t => t.GetMethods()
                    .SelectMany(m => m.GetCustomAttributes<TestAttributeBase>()
                        .Select(a => GetTestParameters(t, m, a))
                    )
                ).ToList();

            return list;
        }

        private static object[] GetTestParameters(Type type, MethodInfo method, TestAttributeBase attribute)
        {

            switch (attribute)
            {

                case NoParametersAttribute a:
                    return new[] { $"{type.Name}.{method.Name}() => {attribute.ExpectedValue ?? "null"}", type.FullName, method.Name, attribute.ExpectedValue };

                case SingleParameterAttribute a:
                    var o = new object[] { $"{type.Name}.{method.Name}({a.Parameters[0]}) => {attribute.ExpectedValue ?? "null"}", type.FullName, method.Name, attribute.ExpectedValue };
                    o = o.Concat(a.Parameters).ToArray();
                    return o;

            }

            return null;
        }

        public static void DoTest(Assembly assembly, object[] parameters)
        {

            var type = assembly.GetTypes().First(t => t.FullName == parameters[0].ToString());
            var method = type.GetMethods().First(m => m.Name == parameters[1].ToString());
            var expectedValue = parameters[2];
            parameters = parameters.Skip(3).ToArray();
            if (parameters.Length == 0) parameters = null;

            var obj = Activator.CreateInstance(type);
            method.Invoke(obj, parameters).ShouldBe(expectedValue);

        }

    }

}
