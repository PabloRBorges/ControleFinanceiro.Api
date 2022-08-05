using Core.Interfaces.DataContext;
using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.Base;
using Core.Models;

namespace Infrastructure.Repositories
{
    public class IncomeRepository : RepositoryBase<Income>, IIncomeRepository
    {
        public IncomeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
