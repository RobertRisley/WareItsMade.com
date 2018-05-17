using System.ComponentModel.DataAnnotations;

namespace WareItsMade.com.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string Action { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class ManageUserViewModel
    {
        public ManageUserViewModel() { }
        public ManageUserViewModel(ApplicationUser user)
        {
            this.Name = user.Name;
            this.CountryId = user.CountryId;
            this.HomePage = user.HomePage;
            this.Street1 = user.Street1;
            this.Street2 = user.Street2;
            this.City = user.City;
            this.SubdivisionId = user.SubdivisionId;
            this.PostalCode = user.PostalCode;
        }

        //[Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        //[Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        // custom added fields
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Country ")]
        public string CountryId { get; set; }

        [Required]
        [Display(Name = "Home Page ")]
        public string HomePage { get; set; }

        [Display(Name = "Address 1 ")]
        public string Street1 { get; set; }

        [Display(Name = "Address 2 ")]
        public string Street2 { get; set; }

        [Display(Name = "City ")]
        public string City { get; set; }

        [Display(Name = "State/Subdivision ")]
        public string SubdivisionId { get; set; }

        [Display(Name = "Postal Code ")]
        public string PostalCode { get; set; }

        //public virtual Iso3166 Iso3166 { get; set; }
        //public virtual Iso3166_2 Iso3166_2 { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        // custom added fields
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Country ")]
        public string CountryId { get; set; }

        [Required]
        [Display(Name = "Home Page ")]
        public string HomePage { get; set; }

        [Display(Name = "Address 1 ")]
        public string Street1 { get; set; }

        [Display(Name = "Address 2 ")]
        public string Street2 { get; set; }

        [Display(Name = "City ")]
        public string City { get; set; }

        [Display(Name = "State/Subdivision ")]
        public string SubdivisionId { get; set; }

        [Display(Name = "Postal Code ")]
        public string PostalCode { get; set; }

        //public virtual Iso3166 Iso3166 { get; set; }
        //public virtual Iso3166_2 Iso3166_2 { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
