using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Domain.Entities
{
    public class Loan : BaseEntity
    {
        public decimal Amount { get; set; }
        public int DurationInMonths { get; set; }
        public decimal InterestRate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; } = null;

    }
}
