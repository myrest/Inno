using System;
using System.Linq;
using System.Reflection;

namespace Rest.Core.Utility
{
    public static class ReflectionUtility
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

        /// <summary>
        /// 把物件Source裏頭的屬性相同的值，複製到Destence
        /// </summary>
        /// <param name="Source">Source class</param>
        /// <param name="Distance">Distance class</param>
        /// <returns></returns>
        public static void MapByProperties<T1, T2>(this T1 Source, T2 Distance)
            where T1 : class
            where T2 : class
        {
            if (Source != null)
            {
                Type fromType = Source.GetType();
                Type toType = Distance.GetType();
                foreach (PropertyInfo prop in fromType.GetProperties())
                {
                    var toProp = toType.GetProperty(prop.Name);
                    if (toProp != null)
                    {
                        toType.GetProperty(prop.Name).SetValue(Distance, prop.GetValue(Source, null), null);
                    }
                }
            }
        }
    }
}