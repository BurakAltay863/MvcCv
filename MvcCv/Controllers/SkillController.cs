using MvcCv.Models.Entity;
using MvcCv.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        SkilssRepository repo = new SkilssRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult SkillAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SkillAdd(TblSkills p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SkillDelete(int id)
        {
            var t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SkillCall(int id)
        {
            TblSkills t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult SkillCall(TblSkills p)
        {
            TblSkills t = repo.Find(x => x.ID == p.ID);
            t.Skill = p.Skill;
            t.Ratio = p.Ratio;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}