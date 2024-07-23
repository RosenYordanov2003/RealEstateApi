namespace RealEstate.Core.Models.Account
{
    using System.ComponentModel.DataAnnotations;
    public class ResetPasswordModel
    {
       
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Confirm passwrod does not match")]
        public string ConfirmPassword { get; set; } = null!;

        public string Token { get; set; } = null!;
    }
}
