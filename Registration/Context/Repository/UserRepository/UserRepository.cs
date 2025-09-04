using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Registration.Model.Users;

namespace Registration.Context.Repository.UserRepository
{
    public class UserRepository : IUserRepository<AppUser>
    {
        private readonly AppDbContext context;
        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Correct(AppUser user)
        {
            if (user != null)
            {
                var userdb = context.Users.Find(user.Id);
                if (userdb != null)
                {
                    userdb.FirstName = user.FirstName;
                    userdb.LastName = user.LastName;
                    userdb.Email = user.Email;
                    userdb.BirthDay = user.BirthDay;
                    userdb.PhoneNumber = user.PhoneNumber;

                    context.Users.Attach(userdb);
                    context.SaveChanges();
                }
            }
        }

        public void Create(AppUser user)
        {
            context.Add(user);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = context.Users.Find(id);

            if (user != null)
            {
                {
                    context.Remove<AppUser>(user);
                    context.SaveChanges();
                }
            }
        }

        public AppUser GetByEmail(string Email)
        {
            if (!string.IsNullOrEmpty(Email)) return context.Users.FirstOrDefault(x => x.Email == Email);
            else throw new Exception("При поиске Usera по Email произошла ошибка");
        }

        public AppUser GetById(int id)
        {
            if (id > 0) return context.Users.FirstOrDefault(x => x.Id == id);
            else throw new Exception("При поиске Usera по ID произошла ошибка");
        }

        public AppUser GetByLogin(string Login)
        {
            if (!string.IsNullOrEmpty(Login)) return context.Users.FirstOrDefault(x => x.Login == Login);
            else throw new Exception("При поиске Usera по Email произошла ошибка");
        }

        public IEnumerable<AppUser> List()
        {
            return context.Users.ToList();
        }
    }
}
