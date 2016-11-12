using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MarketPlaces.ViewModels
{
    public partial class FutureDate : ValidationAttribute
    {
        //This class is to override the Isvalid method
        public override bool IsValid(object value)
        {
            //TryParseExact specifies the format the date will appear as
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);
            //return that the date is written in the right format and that it is in the future
            return (isValid && dateTime > DateTime.Now);
        }
    }
}