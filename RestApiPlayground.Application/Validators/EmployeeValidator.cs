using FluentValidation;
using RestApiPlayground.Domain.Contracts;

namespace RestApiPlayground.Application.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            //firstName
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(20).WithMessage("First Name cannot be longer than 20 characters.");

            //lastName
            When(x => !string.IsNullOrEmpty(x.LastName), () =>
            {
                RuleFor(x => x.LastName).MaximumLength(20).WithMessage("Last Name cannot be longer than 20 characters.");
            });

            //department
            When(x => !string.IsNullOrEmpty(x.Department), () =>
            {
                RuleFor(x => x.Department).MaximumLength(50).WithMessage("Address cannot be longer than 50 characters.");
            });

            //email
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("It must be a valid email address.")
                .MaximumLength(50).WithMessage("Last Name cannot be longer than 50 characters.");


            //contact
            RuleFor(x => x.ContactNumber).NotEmpty().WithMessage("Contact Number is required.")
                .Matches(@"^\d{10}$").WithMessage("Contact number must be exactly 10 digits.");

            //address
            When(x => !string.IsNullOrEmpty(x.Address), () =>
            {
                RuleFor(x => x.Address).MaximumLength(50).WithMessage("Address cannot be longer than 50 characters.");
            });

        }
    }
}
