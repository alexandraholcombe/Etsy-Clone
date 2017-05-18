using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EtsyClone.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using EtsyClone.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EtsyClone.Controllers
{
    public class AccountController : Controller
    {

        private readonly EtsyContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IAddressRepository _addressRepo;
        //private readonly RoleManager<Role> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, EtsyContext db, IAddressRepository addressRepo = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            if(addressRepo == null)
            {
                _addressRepo = new EFAddressRepository();
            }
            else
            {
                _addressRepo = addressRepo;
            }
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (model.Email.IndexOf('@') > -1)
            {
                //Validate email format
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                       @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                          @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(model.Email))
                {
                    //ModelState.AddModelError("Email", "Email is not valid");
                }
            }
            else
            {
                //validate Username format
                string emailRegex = @"^[a-zA-Z0-9]*$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(model.Email))
                {
                    //ModelState.AddModelError("Email", "Username is not valid");
                }
            }
            var userName = model.Email;
            if (userName.IndexOf('@') > -1)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
                else
                {
                    userName = user.UserName;
                }
            }
            var result = await _signInManager.PasswordSignInAsync(userName, model.Password, isPersistent: true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("WINNER", "Home");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                UserProfile profile = new UserProfile { ApplicationUserId = user.Id, FirstName = model.FirstName, LastName = model.LastName };
                //profile.ApplicationUserId = user.Id;
                //profile.FirstName = model.FirstName;
                //profile.LastName = model.LastName;
                _db.UserProfiles.Add(profile);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddAddress()
        {
            List<Country> countries = Country.GetCountries();
            IEnumerable<SelectListItem> selectList =
                from c in countries
                select new SelectListItem
                {
                    Text = c.name,
                    Value = c.name
                };
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = _db.Users.FirstOrDefault(u => u.Id == userId);
            var profile = _db.UserProfiles.FirstOrDefault(p => p.ApplicationUserId == user.Id);
            NewAddressViewModel vm = new NewAddressViewModel();
            vm.UserProfileId = profile.Id;
            vm.Countries = selectList;
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddAddress(NewAddressViewModel vm)
        {
            Address newAddress = Address.CreateAddress(vm);
            _addressRepo.Save(newAddress);
            return RedirectToAction("Addresses", "Account", vm.UserProfileId);
        }
        
        public IActionResult Addresses()
        {
            AddressesViewModel vm = new AddressesViewModel();
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = _db.Users.FirstOrDefault(u => u.Id == userId);
            var profile = _db.UserProfiles.FirstOrDefault(p => p.ApplicationUserId == user.Id);
            vm.Addresses = profile.GetAddresses();
            return View(vm);
        }
    }
}