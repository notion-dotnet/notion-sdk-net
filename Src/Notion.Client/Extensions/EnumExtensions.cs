using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Notion.Client.Extensions
{
    public static class EnumExtensions
    {
        public static string GetEnumMemberValue<T>(this T enumValue) where T : Enum
        {
            var enumType = typeof(T);
            var memInfo = enumType.GetMember(enumValue.ToString());

            var attr = memInfo.FirstOrDefault()?.GetCustomAttributes(false).OfType<EnumMemberAttribute>()
                .FirstOrDefault();

            if (attr != null)
            {
                return attr.Value;
            }

            return null;
        }
    }
}
