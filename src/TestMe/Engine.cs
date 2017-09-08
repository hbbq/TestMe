using System;
using System.Collections.Generic;
using System.Linq;
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

        public static IEnumerable<Assembly> GetAssemblies(Assembly a)
        {
            var list = new List<string>();
            var stack = new Stack<Assembly>();

            stack.Push(a);

            do
            {
                var asm = stack.Pop();

                yield return asm;

                foreach (var reference in asm.GetReferencedAssemblies())
                    if (!list.Contains(reference.FullName))
                    {
                        stack.Push(Assembly.Load(reference));
                        list.Add(reference.FullName);
                    }

            }
            while (stack.Count > 0);

        }

        private static object[] GetTestParameters(Type type, MethodInfo method, TestAttributeBase attribute)
        {

            switch (attribute)
            {

                case NoParametersAttribute a:
                    return new[] { $"{type.Name}.{method.Name}() => {a.ExpectedValue ?? "null"}", type.FullName, method.Name, a.ExpectedValue };

                case SingleParameterAttribute a:
                    var o = new[] { $"{type.Name}.{method.Name}({a.Parameters[0]}) => {a.ExpectedValue ?? "null"}", type.FullName, method.Name, a.ExpectedValue };
                    o = o.Concat(a.Parameters).ToArray();
                    return o;

            }

            return null;
        }

        public static void DoTest(object[] parameters)
        {

            var assembly = Assembly.GetCallingAssembly();
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
