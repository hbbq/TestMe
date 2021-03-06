﻿using System;

namespace TestMe
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public abstract class TestAttributeBase : Attribute
    {

        public object ExpectedValue { get; }
        public object[] Parameters { get; }

        internal TestAttributeBase(object expectedValue, object[] parameters)
        {
            ExpectedValue = expectedValue;
            Parameters = parameters;
        }

    }

}
