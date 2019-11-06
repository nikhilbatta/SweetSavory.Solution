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
    public class FlavorController : Controller
    {
        private readonly SweetSavoryContext _db;
        public FlavorController(SweetSavoryContext db)
        {
            _db = db;
        }
        [Authorize]
        [HttpGet]
        public ActionResult AddFlavorType()
        {
            if(_db.Flavors.Count() == 0)
            {
                ViewBag.Data = "No flavors exist yet, Before you make a treat you need to add some flavors.";
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddFlavorType(Flavor newFlavorType)
        {
            _db.Flavors.Add(newFlavorType);
            _db.SaveChanges();
            return RedirectToAction("Index", "Treat");
        }
    }
}