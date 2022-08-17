using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Get(string username, string password)
        {
            var result = _userRepository.List(x => x.Username == username && x.Password == password);

            return Task.FromResult(result.FirstOrDefault());
        }
    }
}
