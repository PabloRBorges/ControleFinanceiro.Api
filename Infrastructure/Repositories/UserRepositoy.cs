using Core.Interfaces.DataContext;
using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.Base;
using Core.Models;

namespace Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
