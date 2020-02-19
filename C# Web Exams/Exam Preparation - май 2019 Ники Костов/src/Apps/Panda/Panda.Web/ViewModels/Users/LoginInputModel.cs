using SIS.MvcFramework.Attributes.Validation;

namespace Panda.Web.ViewModels.Users
{
    public class LoginInputModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Username should be between 5 and 20 characters")]
        public string Username { get; set; }

        [RequiredSis]
        public string Password { get; set; }
    }
}
