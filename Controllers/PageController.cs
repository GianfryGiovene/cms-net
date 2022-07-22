﻿using Cms_Net.Context.Database;
using Cms_Net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms_Net.Controllers
{
    public class PageController : Controller
    {
        // GET: HomeController1
        public ActionResult Index()
        {
            using(CmsContext db = new CmsContext())
            {
                List<Page> pageList = db.Pages.ToList();

                return View("Index",pageList);
            }
            
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {

            using (CmsContext db = new CmsContext())
            {
                Page page = new Page();

                return View("Create", page);
            }
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Page p)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    using(CmsContext db = new CmsContext())
                    {
                        return View("Create");

                    }
                }
                using (CmsContext db = new CmsContext())
                {
                    db.Pages.Add(p);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
