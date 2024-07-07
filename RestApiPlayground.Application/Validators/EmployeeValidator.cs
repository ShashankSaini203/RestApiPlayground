﻿using FluentValidation;
using RestApiPlayground.Domain.Contracts;

namespace RestApiPlayground.Application.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(20).WithMessage("First Name cannot be longer than 20 characters.");

            When(x => !string.IsNullOrEmpty(x.Address), () =>
            {
                RuleFor(x => x.Address).MaximumLength(50).WithMessage("Address cannot be longer than 50 characters.");
            });

            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            When(x => !string.IsNullOrEmpty(x.Address), () =>
            {
                RuleFor(x => x.ContactNumber).NotEmpty();
            });
            RuleFor(x => x.Department).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ModifiedDate).NotEmpty();
            RuleFor(x => x.CreationDate).NotEmpty();

        }
    }
}
