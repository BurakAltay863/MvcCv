using MvcCv.Models.Entity;
using MvcCv.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobbyController : Controller
    {
        // GET: Hobby
        HobbyRepository repo = new HobbyRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(TblHobby p)
        {
            //TblHobby t = new TblHobby();
            var t = repo.Find(x => x.ID == 3);
            t.Descreption1 = p.Descreption1;
            t.Descreption2 = p.Descreption2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}