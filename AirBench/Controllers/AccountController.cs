using AirBench.Data;
using AirBench.Models;
using AirBench.Repositories;
using AirBench.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace AirBench.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private Context context;

        public AccountController()
        {
            context = new Context();
        }
        
        [AllowAnonymous]
        public ActionResult Register()
        {
            var viewModel = new RegisterViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(viewModel.Password, 12);

                User user = new User(0, viewModel.Email, viewModel.FirstName, viewModel.LastName, hashedPassword);
                var repository = new UserRepository(context);
                repository.Insert(user);

                FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }
        
        [AllowAnonymous]
        public ActionResult Login()
        {
            var ViewModel = new LoginViewModel();
            return View(ViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if(ModelState.IsValidField("UserName") && ModelState.IsValidField("Password"))
            {
                var repository = new UserRepository(context);
                User user = repository.GetLoggedInUser(viewModel.Email);

                if(user == null || !BCrypt.Net.BCrypt.Verify(viewModel.Password, user.HashedPassword))
                {
                    ModelState.AddModelError("", "Those credentials do not exist for this application.");
                }
            }
        

            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}