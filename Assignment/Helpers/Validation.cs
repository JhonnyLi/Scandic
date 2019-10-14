using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Helpers
{
    /// <summary>
    /// Only invalid if a German guest does not enter a title.
    /// </summary>
    public class TitleValidationAttribute : ValidationAttribute
    {
        private readonly string hotelCountryCode;
        private const string _countryCode = "DE";

        public TitleValidationAttribute(string hotelCountryCode)
        {
            this.hotelCountryCode = hotelCountryCode;
        }

        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(hotelCountryCode) ?? throw new ArgumentNullException(nameof(hotelCountryCode));
            var propertyValue = property.GetValue(validationContext.ObjectInstance, null) as string;

            if (_countryCode.Equals(propertyValue, StringComparison.InvariantCultureIgnoreCase) && string.IsNullOrEmpty((string)value))
                return new ValidationResult("Title is required");

            return ValidationResult.Success;
        }
    }
}
