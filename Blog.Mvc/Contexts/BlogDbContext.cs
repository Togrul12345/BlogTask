
using Blog.Mvc.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogMvc.Contexts
{
    public class BlogDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Server=DESKTOP-MFDQNKF\\SQLEXPRESS;DataBase=BlogDB;integrated Security=true;TrustServerCertificate=true"));
        }
        public DbSet<Blog.Mvc.Entities.Blog> Blogs { get; set; }
        public DbSet<Blog.Mvc.Entities.Image> Images { get; set; }
    }
}
