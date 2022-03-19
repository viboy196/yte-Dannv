using System.ComponentModel.DataAnnotations;
using Xcomp.Share.Domain;

namespace Xcomp.Share.Models
{
    public class UserModel 
    {
        public string Id { get; set; }
        public string Phone { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }

        public DateTime? BirthOfDate { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
    }


    public class LoginUserModel
    {
        [Required]
        [RegularExpression("0[0-9]{9}", ErrorMessage = "Phone is invalid")]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class ActiveUserModel
    {
        
        public string Phone { get; set; }
        public string ActiveCode { get; set; }
    }


    public class CreateUserModel
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string? FullName { get; set; }
        public DateTime? BirthOfDate { get; set; }
        public string? Title { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
    }

}
