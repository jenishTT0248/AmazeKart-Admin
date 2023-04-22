using AmazeKart.Admin.Core.Utility;
using System.Reflection;

namespace AmazeKart.Admin.Core.Enums
{
    public static class EnumResult
    {
        public static string GetStringValue(this Enum value)
        {
            Type type = value.GetType();

            FieldInfo fieldInfo = type.GetField(value.ToString());

            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
            typeof(StringValueAttribute), false) as StringValueAttribute[];

            return attribs.Length > 0 ? attribs[0].Value : string.Empty;
        }
    }
}