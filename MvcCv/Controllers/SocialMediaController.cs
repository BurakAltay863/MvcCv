using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repostories;

namespace MvcCv.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        SocialMediaRepository repo = new SocialMediaRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult SocialMediaAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SocialMediaAdd(TblSocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SocialMediaCall(int id)
        {
            var t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult SocialMediaCall(TblSocialMedia p)
        {
            TblSocialMedia t = repo.Find(x => x.ID == p.ID);
            t.Name = p.Name;
            t.Durum = true;
            t.Link = p.Link;
            t.Ikon = p.Ikon;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
        public ActionResult SocialMediaDelete(int id)
        {
            var result = repo.Find(x => x.ID == id);
            result.Durum = false;
            repo.TUpdate(result);
            return RedirectToAction("Index");
        }
    }
}