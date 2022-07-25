using Cms_Net.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cms_Net.Context.Database
{
    public class CmsContext : IdentityDbContext<IdentityUser>
    {

        public DbSet<Page> Pages { get; set; }

        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentDefinition> ComponentsDefinitions { get; set; }
        public DbSet<Field> Fields { get; set; }

        public CmsContext(DbContextOptions<CmsContext> options)
         : base(options)
        {

        }
        public CmsContext()
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=cms-db;Integrated Security=True");
        }
    }
}
