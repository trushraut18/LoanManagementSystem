using LoanManagementSystem.Application.DTOs;
using LoanManagementSystem.Domain.Entities;
using LoanManagementSystem.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LoansController(ApplicationDbContext context)
        {
            _context = context;
        }
  
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateLoan(CreateLoanDto request)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var loan = new Loan
            {
                Amount = request.Amount,
                DurationInMonths = request.DurationInMonths,
                InterestRate = request.InterestRate,
                Status = "Pending",
                UserId = Convert.ToInt32(userId),
                CreatedDate = DateTime.UtcNow
            };

            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();  
            return Ok("");
        }
 
        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public IActionResult GetAllLoans()
        {
            var loans = _context.Loans.ToList();
            return Ok(loans);
        }
    }
}
