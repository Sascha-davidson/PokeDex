using System.Reflection;

namespace PokeDex.Lib.Enums
{
    [AttributeUsage(AttributeTargets.Field)]
    public class StyleAttribute : Attribute
    {
        public string Name { get; set; } = string.Empty;
    }

    public static class EnumExtensions
    {
        public static string GetStyleName(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (field?.GetCustomAttribute<StyleAttribute>() is StyleAttribute attribute)
            {
                return attribute.Name;
            }
            return enumValue.ToString().ToLowerInvariant();
        }
    }
}