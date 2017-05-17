using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EtsyClone.Models;
using EtsyClone.ViewModels;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EtsyClone.Controllers
{
    public class PeopleController : Controller
    {

        private readonly EtsyContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly RoleManager<Role> _roleManager;

        public PeopleController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, EtsyContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile(string username)
        {
            //username = "allieh";
            ProfileViewModel vm = new ProfileViewModel();
            vm.Account = _db.Users.FirstOrDefault(u => u.UserName == username);
            vm.Profile = _db.UserProfiles.FirstOrDefault(p => p.ApplicationUserId == vm.Account.Id);
            return View(vm);
        }

    }
}
