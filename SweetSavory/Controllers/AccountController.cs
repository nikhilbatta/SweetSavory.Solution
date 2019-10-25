using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SweetSavory.Models;
using System.Threading.Tasks;
using SweetSavory.ViewModels;

namespace SweetSavory.Controllers
{
    public class AccountController : Controller
    {
        private readonly SweetSavoryContext _db;
        private readonly UserManager<StoreManager> _userManager;
        private readonly SignInManager<StoreManager> _signInManager;

        public AccountController(UserManager<StoreManager> userManager, SignInManager<StoreManager> signInManager, SweetSavoryContext db)
        {
             _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
         public IActionResult Register()
        {
            return View();
        }
        public async Task<ActionResult> Register (RegisterViewModel model)
        {
            var user = new StoreManager { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
         [HttpPost]
        public async Task<ActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}