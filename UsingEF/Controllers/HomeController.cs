using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UsingEF.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //public ActionResult Index()
        //{
        //    //EFEventsRepository repository = new EFEventsRepository();
        //    //return View(repository.GetEvents());

        //}

        EFEventsRepository context = new EFEventsRepository();

        public ActionResult Index()
        {
            return View(context.GetEvents);
        }
        public ActionResult Details(int id) //+передаём авторов события
        {
            ViewBag.LstAuthirs = context.GetAuthorsToEvent(id);
            return View(context.GetEvent(id));
        }
    }
}