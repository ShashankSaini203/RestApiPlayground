using System.ComponentModel.DataAnnotations;

namespace RestApiPlayground.Domain.Helpers.Attributes
{
    public class NotPlaceholderAttribute : ValidationAttribute
    {
        private readonly string _placeholder;

        public NotPlaceholderAttribute(string placeholder)
        {
            _placeholder = placeholder;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string strValue && strValue == _placeholder)
            {
                return new ValidationResult($"The field {validationContext.DisplayName} cannot be '{_placeholder}'.");
            }

            return ValidationResult.Success;
        }
    }
}
