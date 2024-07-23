namespace RealEstate.Core.Models.Account
{
    using System.ComponentModel.DataAnnotations;
    public class LoginTwoFaModel : LoginModel
    {
        [Required]
        public string Code { get; set; } = null!;
    }
}
