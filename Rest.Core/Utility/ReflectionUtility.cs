using System;
using System.Linq;
using System.Reflection;

namespace Rest.Core.Utility
{
    public class ReflectionUtility
    {
        public static Type[] GetTypesInNamespace(string nameSpace)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

        public static Type[] GetTypesInNamespace(string nameSpace, bool IncludeSubNamespace)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetTypes().Where(t => StartWith(t.Namespace, nameSpace)).ToArray();
        }

        private static bool StartWith(string NameSpace, string CompareTo)
        {
            if (!string.IsNullOrEmpty(NameSpace))
            {
                return NameSpace.StartsWith(CompareTo, StringComparison.Ordinal);
            }
            else
            {
                return false;
            }
        }
    }
}
