using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Application.DTOs
{
    public class DashboardAnalyticsDto
    {
        public int TotalLoans { get; set; }
        public decimal TotalLoanAmount { get; set; }
        public int ApprovedLoans { get; set; }
        public int PendingLoans { get; set; }
    }
}
