using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Domain.Entities
{
    public class LoanPayment :BaseEntity
    {
        public int LoanId { get; set; }
        public Loan Loan { get; set; } = null;
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMode { get; set; }
        public string TransactionReference { get; set; } = string.Empty;
    }
}
