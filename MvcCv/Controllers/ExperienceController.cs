using MvcCv.Models.Entity;
using MvcCv.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {

        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult ExperienceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ExperienceAdd(TblExperience p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult ExperienceDelete(int id)
        {
            TblExperience t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ExperienceCall(int id)
        {
            TblExperience t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult ExperienceCall(TblExperience p)
        {
            TblExperience t = repo.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.Subtitle = p.Subtitle;
            t.Descreption = p.Descreption;
            t.Date = p.Date;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}