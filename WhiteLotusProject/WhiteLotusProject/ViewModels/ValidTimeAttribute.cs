using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WhiteLotusProject.ViewModels
{
    public class ValidTimeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);
            return (isValid);

        }
    }
}