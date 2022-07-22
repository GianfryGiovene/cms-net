using System.ComponentModel.DataAnnotations;

namespace Cms_Net.Models
{
    public class ComponentDefinition
    {
        [Key]
        public string Key { get; set; }

        public ComponentDefinition()
        {

        }

        public ComponentDefinition(string key)
        {
            this.Key = key;
        }

    }
}
