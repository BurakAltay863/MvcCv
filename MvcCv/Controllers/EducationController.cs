using MvcCv.Models.Entity;
using MvcCv.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        EducationRepository repo = new EducationRepository();
        // GET: Education

        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }
        [HttpGet]
        public ActionResult EducationAdd()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult EducationAdd(TblEducation p)
        {
            if (!ModelState.IsValid)
            {
                return View("EducationAdd");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EducationDelete(int id)
        {
            var t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EducationCall(int id)
        {
            TblEducation t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EducationCall(TblEducation p)
        {
            if (!ModelState.IsValid)
            {
                return View("EducationCall");
            }
            TblEducation t = repo.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.Subtitle1 = p.Subtitle1;
            t.Subtitle2 = p.Subtitle2;
            t.GNO = p.GNO;
            t.Date = p.Date;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}