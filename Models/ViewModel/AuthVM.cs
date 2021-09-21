using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FOODEE.Models.ViewModel
{
    public class AuthVM
    {
        public class CreateUser
        {
            public DateTime CreatedAt { get; set; }

            [Required(ErrorMessage = "FirstName is required")]
            [DisplayName("FirstName")]
            [StringLength(60)]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "LastName is required")]
            [DisplayName("LastName")]
            [StringLength(60)]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Address is required")]
            [StringLength(70)]
            public string Address { get; set; }

            [Required(ErrorMessage = "Phone Number is required")]
            [StringLength(24)]
            public string PhoneNumber { get; set; }

            [DisplayName("Email Address")]
            [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
                ErrorMessage = "Email is is not valid.")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required(ErrorMessage = "Gender is required")]
            [Display(Name = "Gender:")]
            public string Gender { get; set; }

            [Required(ErrorMessage = "User Password is required")]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirm Password!!")]
            [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
            public string ConfirmPassword { get; set; }
        }

        public class LoginUser
        {
            [Required(ErrorMessage = "User E-mail is required")]
            [Display(Name = "E-mail Address:")]
            public string Email { get; set; }

            [Required(ErrorMessage = "User Password is required")]
            [Display(Name = "Password:")]
            public string Password { get; set; }
        }
    }
}