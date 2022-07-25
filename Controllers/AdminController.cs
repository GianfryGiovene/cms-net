using Cms_Net.Context.Database;
using Cms_Net.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms_Net.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IWebHostEnvironment _hostEnvironment;
        
        public AdminController(IWebHostEnvironment environment)
        {
            _hostEnvironment = environment;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ComponentList()            
        {
            string path = "D:/Documenti/Coding/Corso_Experis/Esercizi/Cms-Net/Views/Page/Components";

            string[] dirs = Directory.GetDirectories(path,"*", SearchOption.TopDirectoryOnly);

            List<string> componentList = new List<string>();
            foreach(string dir in dirs)
            {
                
                string[] dirSplit = dir.Split("\\");
                string componentName = dirSplit.Last();

                componentList.Add(componentName);
            }

            ViewData["componentList"] = componentList;
            return View();
        }
            
        public ActionResult InstallComponent(string name)
        {
            using(CmsContext db = new CmsContext())
            {
                try
                {
                    ComponentDefinition cd = new ComponentDefinition(name);

                    db.ComponentsDefinitions.Add(cd);
                    db.SaveChanges();

                    return RedirectToAction("ComponentList");

                }catch(DbUpdateException ex)
                {
                    return View("Exception");
                }            
            }            
        }

        public ActionResult UnistallComponent(string name)
        {

            using(CmsContext db = new CmsContext())
            {
                try
                {
                    ComponentDefinition cd = db.ComponentsDefinitions.Where(cd => cd.Key == name).FirstOrDefault();

                    db.ComponentsDefinitions.Remove(cd);
                    db.SaveChanges();

                    return RedirectToAction("ComponentList");
                }
                catch (DbUpdateException ex)
                {
                    return View("Exception");
                }
            }            
        }

    }
}
