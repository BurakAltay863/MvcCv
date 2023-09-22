using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repostories;
namespace MvcCv.Controllers
{   [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
        
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(TblAdmin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminDelete(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminCall(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminCall(TblAdmin p)
        {
            TblAdmin t = repo.Find(x => x.ID == p.ID);
            t.UserName = p.UserName;
            t.Password = p.Password;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}