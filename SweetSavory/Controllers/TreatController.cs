using Microsoft.AspNetCore.Mvc;
using SweetSavory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
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
            List<Treat> allTreats = _db.Treats.Include(t => t.Flavors).ThenInclude(f => f.Flavor).ToList();
            return View(allTreats);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            Console.WriteLine(_db.Flavors.Count());
            if(_db.Flavors.Count() == 0)
            {
                return RedirectToAction("AddFlavorType", "Flavor");
            }
            ViewBag.FlavorID = new SelectList(_db.Flavors, "FlavorID", "FlavorName");
            return View();

        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(FlavorTreat newTreat, int FlavorID)
        {
    
            Treat foundTreat = _db.Treats.Where(t => t.TreatName == newTreat.Treat.TreatName).FirstOrDefault();
            Console.WriteLine(foundTreat.TreatName);
            if(foundTreat != null)
            {
                newTreat.Treat.TreatID = foundTreat.TreatID;
            }
            else
            {
                var userID = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var currentUser = await _userManager.FindByIdAsync(userID);
                newTreat.Treat.CreatedBy = currentUser;
            }
            Flavor foundFlavor = _db.Flavors.FirstOrDefault(t => t.FlavorID == FlavorID);
            newTreat.Flavor = foundFlavor;
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
        [HttpPost]
        public async Task<ActionResult> AddFlavor(int TreatID, int flavorID)
        {
            // Treat foundTreat = _db.Treats.FirstOrDefault(t => t.TreatID == TreatID);
            Flavor foundFlavor = _db.Flavors.FirstOrDefault(t => t.FlavorID == flavorID);
            Treat foundTreat = _db.Treats.Where(t => t.TreatID == TreatID).FirstOrDefault();
            FlavorTreat newFlavorTreat = new FlavorTreat();
            // conditional isnt really needed it should be able to find a treat
            if(foundTreat != null)
            {
                newFlavorTreat.Treat = foundTreat;
            }
            else
            {
            var userID = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userID);
            }
            
            newFlavorTreat.Flavor = foundFlavor;
            newFlavorTreat.Treat = foundTreat;
            _db.FlavorTreats.Add(newFlavorTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Console.WriteLine(id);
            ViewBag.FlavorID = new SelectList(_db.Flavors, "FlavorID", "FlavorName");  
            Treat foundTreat = _db.Treats.FirstOrDefault(t => t.TreatID == id);
            return View(foundTreat);
        }
        [HttpPost]
        public ActionResult Edit(Treat editedTreat)
        {
            _db.Entry(editedTreat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index", "Treat");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Treat treatToBeDeleted = _db.Treats.FirstOrDefault(t => t.TreatID == id);
            return View(treatToBeDeleted);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Console.WriteLine(id);
            Treat treatToBeDeleted = _db.Treats.FirstOrDefault(t => t.TreatID == id);
            FlavorTreat flavorTreatToBeDeleted = _db.FlavorTreats.FirstOrDefault(t => t.Treat.TreatID == id);
            _db.Treats.Remove(treatToBeDeleted);
            _db.FlavorTreats.Remove(flavorTreatToBeDeleted);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}