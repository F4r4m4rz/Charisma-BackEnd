using System;
using System.Reflection;
using Charisma.Core.Model.Base;

namespace Charisma.Core.Data
{
    internal static class Tools
    {
        /// <summary>
        /// Sets all the properties and fields of the target as for source
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void MatchUpObjects<T>(T source, T target)
        {
            // Match up fields
            MatchUpObjects_Fields(source, target);

            // Match up properties
            MatchUpObjects_Properties(source, target);
        }

        /// <summary>
        /// Sets all the fields of the target as for source
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        internal static void MatchUpObjects_Fields<T>(T source, T target)
        {
            FieldInfo[] fields = source.GetType().GetFields();
            foreach (FieldInfo field in fields)
            {
                if (field.GetValue(source) != field.GetValue(target))
                {
                    field.SetValue(target, field.GetValue(source));
                }
            }
        }

        /// <summary>
        /// Sets all the properties of the target as for source
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        internal static void MatchUpObjects_Properties<T>(T source, T target)
        {
            PropertyInfo[] properties = source.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(source) != property.GetValue(target))
                {
                    property.SetValue(target, property.GetValue(source));
                }
            }
        }
    }
}
