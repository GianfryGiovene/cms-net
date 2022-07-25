using Cms_Net.Context.Database;

namespace Cms_Net.Models
{
    public class HelperModel
    {
        public Page Page { get; set; }
        public List<ComponentDefinition>? CompDeftList { get; set; }
        public List<Component>? ComponentList { get; set; }

        public HelperModel()
        {
            using(CmsContext db = new CmsContext())
            {
                CompDeftList = db.ComponentsDefinitions.ToList();
            }
        }
    }
}
 