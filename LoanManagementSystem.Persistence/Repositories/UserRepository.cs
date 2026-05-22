using LoanManagementSystem.Application.Repositories;
using LoanManagementSystem.Domain.Entities;
using LoanManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task AddSync(User user)
        {
            await _context.Users.AddAsync(user);

        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();

        }
    }
}
