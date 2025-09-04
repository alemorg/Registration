using Registration.Model.Hotels;
using Registration.Model.Users;

namespace Registration.Context.Repository.UserRepository
{
    public class UserService
    {
        private readonly IUserRepository<AppUser> repository;

        public UserService(IUserRepository<AppUser> repository)
        {
            this.repository = repository;
        }
        public IEnumerable<AppUser> List()
        {
            return repository.List();
        }

        public void Create(AppUser user)
        {
            repository.Create(user);
        }

        public void Correct(AppUser user)
        {
            repository.Correct(user);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public AppUser Profile(int id)
        {
            return repository.GetById(id);
        }

        public AppUser GetByEmail(string Email)
        {
            return repository.GetByEmail(Email);
        }

        public AppUser GetByLogin(string Login)
        {
            return repository.GetByEmail(Login);
        }

    }
}
