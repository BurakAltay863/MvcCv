﻿using MvcCv.Models.Entity;
using MvcCv.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutRpository repo = new AboutRpository();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(TblAbout p)
        {
            //TblHobby t = new TblHobby();
            var t = repo.Find(x => x.ID == 1);
            t.Name = p.Name;
            t.Surname = p.Surname;
            t.Address = p.Address;
            t.Mail = p.Mail;
            t.Descreption = p.Descreption;
            t.Telephone = p.Telephone;
            t.Image = p.Image;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}