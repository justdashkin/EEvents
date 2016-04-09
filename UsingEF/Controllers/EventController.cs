using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain;

namespace UsingEF.Controllers
{
    public class EventController : Controller
    {
        EFEventsRepository context = new EFEventsRepository();
        // GET: Event
        public ActionResult Index()
        {
            return View(context.GetEvents);
        }
        public ActionResult Details(int id) //+передаём авторов события
        {
            ViewBag.LstAuthirs = context.GetAuthorsToEvent(id);
            return View(context.GetEvent(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event event1)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                context.CreateEvent(event1);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
        public ActionResult Edit(int id) {
            //ViewBag.LstAuthorToStudent(id).Select(x => x.Surname).ToList();
            ViewBag.LstAuthors = context.GetAuthors;

            return ViewBag(context.GetEvent(id));
        }

        [HttpPost]
        public ActionResult Edit(Event event1, String[] chosenAuthor) {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                context.EditEvent(event1, chosenAuthor);
                TempData["EditEvent"] = "Update Event" + event1.Title;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id) {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, Event event1) {
            try
            {
                context.DeleteEvent(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}