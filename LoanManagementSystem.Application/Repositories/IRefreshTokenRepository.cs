using LoanManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Application.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync( RefreshToken refreshToken );
        Task<RefreshToken> GetByTokenAsync( string token );
        Task SaveChangesAsync();
    }
}
