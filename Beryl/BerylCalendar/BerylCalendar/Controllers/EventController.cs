using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BerylCalendar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace BerylCalendar.Controllers
{
    public class EventController : Controller
    {
        private BerylDbContext db;
        private readonly UserManager<IdentityUser> userManager;

        public EventController(BerylDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        } 

        [HttpGet]
        [Authorize]
        public IActionResult CreateEvent() {
            return View();
        } 
        
        public IActionResult Index() {
            return View("Index", userManager.GetUserId(User));
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddEvent(CreateEvent ev){ 
            if (ModelState.IsValid){
                ev.eve.TypeId = Int32.Parse(ev.name);
                ev.eve.AccountId = db.Accounts.Where(e => e.Username == userManager.GetUserName(User)).Select(e => e.Id).ToArray()[0];
                ev.eve.StartDateTime = ev.eve.StartDateTime.Date.Add(ev.startTime.TimeOfDay);
                ev.eve.EndDateTime = ev.eve.EndDateTime.Date.Add(ev.endTime.TimeOfDay);
                db.Events.Add(ev.eve);
                db.SaveChanges();
                return View("EventCreateSuccess");
            }
            return RedirectToAction("CreateEvent");
        }
    }
}