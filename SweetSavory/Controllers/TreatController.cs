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
    public class TreatController : Controller
    {
        private readonly SweetSavoryContext _db;
        private readonly UserManager<StoreManager> _userManager;
        private readonly SignInManager<StoreManager> _signInManager;
        public TreatController(UserManager<StoreManager> storeManager, SignInManager<StoreManager> signInManager,  SweetSavoryContext db)
        {
            _userManager = storeManager;
            _signInManager = signInManager;
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
        public async Task<ActionResult> Create(FlavorTreat newTreat, int FlavorID)
        {
            Treat foundTreat = _db.Treats.Where(t => t.TreatName == newTreat.Treat.TreatName).FirstOrDefault();
            if(foundTreat != null)
            {
                newTreat.Treat = foundTreat;
            }
            else
            {
                var userID = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var currentUser = await _userManager.FindByIdAsync(userID);
                newTreat.Treat.CreatedBy = currentUser;
            }
            
            // Treat newTreat = new Treat();
            // newTreat.TreatName = treatName;
            Flavor foundFlavor = _db.Flavors.FirstOrDefault(t => t.FlavorID == FlavorID);
            
            newTreat.Flavor = foundFlavor;
            // FlavorTreat newFlavorTreat = new FlavorTreat();
            
            // newFlavorTreat.Flavor = foundFlavor;
            // newFlavorTreat.Treat = newTreat;
            // newTreat.Flavors.Add(newFlavorTreat);
            // _db.Treats.Add(newTreat);
            _db.FlavorTreats.Add(newTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        [Authorize]
        [HttpGet]
        public ActionResult AddFlavor(int TreatID)
        {
            ViewBag.FlavorID = new SelectList(_db.Flavors, "FlavorID", "FlavorName");
            Treat foundTreat = _db.Treats.FirstOrDefault(t => t.TreatID == TreatID);
            return View(foundTreat);

        }
        // [HttpPost]
        // public async Task<ActionResult> AddFlavor(Treat foundTreat, int flavorID)
        // {
        //     var userID = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //     var currentUser = await _userManager.FindByIdAsync(userID);
        //      FlavorTreat newFlavorTreat = new FlavorTreat();
        //     Flavor foundFlavor = _db.Flavors.FirstOrDefault(t => t.FlavorID == FlavorID);
        //     newFlavorTreat.Flavor = foundFlavor;
        //     newFlavorTreat.Treat = foundTreat;
        //     foundTreat.Flavors.Add(newFlavorTreat);
        //     _db.Entry(foundTreat).State = entityState.Modified;
        //     _db.SaveChanges();
        //     return RedirectToAction("Index");
        // }
    }
}