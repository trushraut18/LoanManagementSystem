using FluentValidation;
using LoanManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Application.Validators
{
    public class RegisterRequestValidator :AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required").MaximumLength(100);
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required").MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().WithMessage("First Name is required");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Password must be at least 6 characters");
        }

    }
}
