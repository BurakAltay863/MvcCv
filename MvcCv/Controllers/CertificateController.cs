using MvcCv.Models.Entity;
using MvcCv.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        CertificateRepository repo = new CertificateRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult CertificateCall(int id)
        {
            var t = repo.Find(x => x.ID  == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult CertificateCall(TblCertificate p)
        {
            TblCertificate t = repo.Find(x => x.ID == p.ID);
            t.Date = p.Date;
            t.Descreption = p.Descreption;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult CertificateAdd(TblCertificate p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CertificateAdd()
        {

            return  View();
        }
        public ActionResult CertificateDelete(int id)
        {
            var t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}