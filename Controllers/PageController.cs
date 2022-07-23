using Cms_Net.Context.Database;
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
        public ActionResult Details(Page modelPage)
        {
            using( CmsContext db = new CmsContext())
            {
                Page page = db.Pages.Where(p => p.Id == modelPage.Id).FirstOrDefault();
                if(page == null)
                {
                    return NotFound("Pizza non trovata");
                }
                else
                {
                    return View("Details", page);
                }
                
            }
            
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
                    return RedirectToAction("Details",p);
                }
                
            }
            catch
            {
                return NotFound("Errore imprevisto");
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            using(CmsContext db = new CmsContext())
            {
                Page page = db.Pages.Where(i => i.Id == id).FirstOrDefault();
                if(page == null)
                {
                    return NotFound("Pagina non trovata");
                }
                else
                {
                     return View(page);
                }
            }
            
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Page page)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    using (CmsContext db = new CmsContext())
                    {
                        return View("Edit");

                    }
                }
                using (CmsContext db = new CmsContext())
                {
                    Page editPage = db.Pages.Where(p => p.Id == id).FirstOrDefault();
                    if(editPage != null)
                    {
                        editPage.EditPage(page.Title);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return NotFound();
                    }
                    
                }
            }
            catch
            {
                return NotFound();
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
                using (CmsContext db = new CmsContext()) 
                {
                    Page page = db.Pages.Where(p => p.Id == id).FirstOrDefault();

                    if(page != null)
                    {
                        db.Pages.Remove(page);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return NotFound("Pagina non trovata");
                    }
                    
                }
                
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
