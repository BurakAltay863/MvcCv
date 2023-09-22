using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }
        public PartialViewResult SocialMedia()
        {
            var socialmedia = db.TblSocialMedia.Where(x=>x.Durum==true).ToList();
            return PartialView(socialmedia);
        }

        public PartialViewResult Experience()
        {
            var experience = db.TblExperience.ToList();
            return PartialView(experience);
        }
        public PartialViewResult Education()
        {
            var education = db.TblEducation.ToList();
            return PartialView(education);
        }
        public PartialViewResult Skills()
        {
            var skilss = db.TblSkills.ToList();
            return PartialView(skilss);
        }
        public PartialViewResult Certificate()
        {
            var certificate = db.TblCertificate.ToList();
            return PartialView(certificate);
        }
        [HttpGet]
        public PartialViewResult Communication()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Communication(TblCommunication t)
        {
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblCommunication.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}