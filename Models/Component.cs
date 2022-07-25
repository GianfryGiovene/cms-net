using System.ComponentModel.DataAnnotations.Schema;

namespace Cms_Net.Models
{
    public class Component
    {
        public int Id { get; set; }

        [ForeignKey("ComponentDefinitionKey")]
        public string ComponentDefinitionKey { get; set; }
        public ComponentDefinition ComponentDefinition { get; set; }

        public int PageId { get; set; }
        public Page Page { get; set; }

        public List<Field>? Fields { get; set; }

        public Component()
        {

        }

        public Component(string key,Page page)
        {
            ComponentDefinitionKey = key;
            Page = page;
            PageId = page.Id;
        }
    }
}
