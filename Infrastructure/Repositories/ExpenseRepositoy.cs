using Core.Interfaces.DataContext;
using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.Base;
using Core.Models;

namespace Infrastructure.Repositories
{
    public class ExpenseRepository : RepositoryBase<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
