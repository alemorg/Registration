using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Registration.Model.Users;

namespace Registration.Context.Repository.UserRepository
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly AppDbContext context;
        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Correct(User user)
        {
            if (user != null)
            {
                var userdb = context.User.Find(user.Id);
                if (userdb != null)
                {
                    userdb.FirstName = user.FirstName;
                    userdb.LastName = user.LastName;
                    userdb.Email = user.Email;
                    userdb.BirthDay = user.BirthDay;
                    userdb.PhoneNumber = user.PhoneNumber;

                    context.User.Attach(userdb);
                    context.SaveChanges();
                }
            }
        }

        public void Create(User user)
        {
            context.Add(user);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = context.User.Find(id);

            if (user != null)
            {
                {
                    context.Remove<User>(user);
                    context.SaveChanges();
                }
            }
        }

        public User GetByEmail(string Email)
        {
            if (!string.IsNullOrEmpty(Email)) return context.User.FirstOrDefault(x => x.Email == Email);
            else throw new Exception("При поиске Usera по Email произошла ошибка");
        }

        public User GetById(int id)
        {
            if (id > 0) return context.User.FirstOrDefault(x => x.Id == id);
            else throw new Exception("При поиске Usera по ID произошла ошибка");
        }

        public User GetByLogin(string Login)
        {
            if (!string.IsNullOrEmpty(Login)) return context.User.FirstOrDefault(x => x.Login == Login);
            else throw new Exception("При поиске Usera по Email произошла ошибка");
        }

        public IEnumerable<User> List()
        {
            return context.User.ToList();
        }
    }
}
