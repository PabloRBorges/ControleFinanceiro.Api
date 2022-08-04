using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.Base;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class IncomeRepositoy : RepositoryBase<Income>, IIncomeRepository
    {
        public IncomeRepositoy(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
