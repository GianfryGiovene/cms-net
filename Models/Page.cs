﻿namespace Cms_Net.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<Component>? Components { get; set; }


        public Page()
        {

        }

        public Page(string title)
        {
            Title = title;
        }

        public void EditPage(string title)
        {
            Title = title;
        }
    }
}
