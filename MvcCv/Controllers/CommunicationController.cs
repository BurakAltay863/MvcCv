using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repostories;
namespace MvcCv.Controllers
{
    public class CommunicationController : Controller
    {
        // GET: Communication
        CommunicationRepository repo = new CommunicationRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
    }
}