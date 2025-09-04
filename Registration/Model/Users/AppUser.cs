using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Registration.Model.Users
{
    public class AppUser : IdentityUser
    {
        //public int Id { get; set; }

        //[Required]
        //[MaxLength(50)]
        //public string Login {  get; set; }

        //[Required]
        //[MaxLength(50)]
        //public string Email {  get; set; }

        //[Required]
        //public string Role { get; set; } = "AppUser";

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string SecondName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        public bool IsAgree { get; set; }

        // Навигационное свойство
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }
    }
}
