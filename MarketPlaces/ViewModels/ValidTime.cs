using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MarketPlaces.ViewModels
{
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //same as for future date class
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "HH:mm", CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);

            return (isValid);
        }
    }
}