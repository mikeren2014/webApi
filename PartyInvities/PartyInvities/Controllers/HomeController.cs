using PartyInvities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyInvities.Controllers
{
    public class HomeController : Controller
    {
        Repository res = new Repository();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rsvp()
        {
            return View();
        }

        public ActionResult Thanks()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Rsvp(GuestResponse response)
        {
            if (ModelState.IsValid)
            {
                Repository.Add(response);
                return View("Thanks", response);
            }
            else
            {
                return View();
            }
        }
        [ChildActionOnly]
        public ActionResult Attendees()
        {
            return View(Repository.Responses.Where(x => x.WillAttend == true));
        }
    }
}