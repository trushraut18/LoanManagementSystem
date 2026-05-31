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

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetLoanById(int id)
        {
            var loan = _context.Loans.FirstOrDefault(lo => lo.Id == id);
            if (loan == null)
            {
                return NotFound();
            }
            return Ok(loan);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoan(int id, UpdateLoanRequestDto request)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            loan.Amount = request.Amount;
            loan.DurationInMonths = request.DurationInMonths;
            loan.InterestRate = request.InterestRate;

            await _context.SaveChangesAsync();
            return NoContent();

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var loan = await _context.Loans.FindAsync(id);

            if(loan == null)
            {
                return NotFound();
            }

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
