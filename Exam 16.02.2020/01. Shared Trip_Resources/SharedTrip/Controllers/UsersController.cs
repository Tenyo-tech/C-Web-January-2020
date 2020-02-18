using SharedTrip.Services;
using SharedTrip.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/");
            }

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Register()
        {

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.View();
            }

            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.View();
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.View();
            }

            //if (this.usersService.EmailExists(input.Email))
            //{
            //    return this.View();
            //}
            //
            //if (this.usersService.UsernameExists(input.Username))
            //{
            //    return this.View();
            //}

            this.usersService.Register(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();

            return this.Redirect("/");
        }
    }
}
