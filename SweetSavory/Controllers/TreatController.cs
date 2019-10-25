using Microsoft.AspNetCore.Mvc;
using SweetSavory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SweetSavory.Controllers
{
    public class TreatController : Controllers
    {
        private readonly SweetSavoryContext _db;
        private readonly UserManager<StoreManager> _userManager;
        public TreatController(UserManager<StoreManager> storeManager, SweetSavoryContext db)
        {
            _userManager = storeManager;
            _db = db;
        }
        public ActionResult Index()
        {
            List<Treat> allTreats = _db.Treats.Include(t => t.Flavors).ToList();
            return View(allTreats);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.FlavorID = new SelectList(_db.Flavors, "FlavorID", "FlavorName");
            return View();

        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(Treat newTreat, int FlavorID)
        {
            var userID = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userID);
            newTreat.User = currentUser;
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}