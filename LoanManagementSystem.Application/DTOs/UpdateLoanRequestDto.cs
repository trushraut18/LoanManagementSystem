using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Application.DTOs
{
    public class UpdateLoanRequestDto
    {
        public decimal Amount { get; set; }

        public int DurationInMonths { get; set; }

        public decimal InterestRate { get; set; }

   }
}
