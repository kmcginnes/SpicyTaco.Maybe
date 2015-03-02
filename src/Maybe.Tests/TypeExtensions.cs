using System;
using System.Diagnostics;
using System.Reflection;

namespace Maybe.Tests
{
    [DebuggerStepThrough]
    public static class TypeExtensions
    {
        public static ConstructorInfo[] Constructors(this Type type)
        {
            return type.GetConstructors(
                BindingFlags.Public | BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Instance);
        }
    }
}