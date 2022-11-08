using Microsoft.AspNetCore.Mvc.Rendering;
using StartFromScratch.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace StartFromScratch
{

    public static class ExtensionMethods
    {

        public static string GetDisplayName(this Enum value)
        {
            return value.GetType()
              .GetMember(value.ToString())
              .First()
              .GetCustomAttribute<DisplayAttribute>()
              ?.GetName();
        }
    }
}
