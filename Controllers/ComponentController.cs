using Cms_Net.Context.Database;
using Cms_Net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cms_Net.Controllers
{
    public class ComponentController : Controller
    {
        // GET: HomeController1
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Select(string key)
        {
            using(CmsContext db = new CmsContext())
            {
                Component component = new Component();

                return View("_View");
            }
            
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}
