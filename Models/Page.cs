namespace Cms_Net.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Title { get; set; }

        List<Component>? Components { get; set; }



        public Page()
        {

        }

        public Page(string title)
        {
            Title = title;
        }
    }
}
