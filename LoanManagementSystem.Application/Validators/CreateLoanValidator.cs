using FluentValidation;
using LoanManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Application.Validators
{
    public class CreateLoanValidator : AbstractValidator<Loan>
    {
        public CreateLoanValidator() 
        {
            RuleFor(x => x.Amount).NotEmpty().GreaterThan(0);
            RuleFor(x => x.DurationInMonths).NotEmpty().InclusiveBetween(1, 360);
            RuleFor(x => x.InterestRate).InclusiveBetween(1, 50);
        }
    }
}
