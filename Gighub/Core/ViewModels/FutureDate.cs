using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Gighub.Core.ViewModels
{
    //This is my custom validation to check whether the date is in the future when the user inputs it 
    public class FutureDate: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid =  DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy", CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);
            return (isValid && dateTime > DateTime.Now);
        }
    }
}