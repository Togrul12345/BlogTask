using BlogMvc.Contexts;

namespace Blog.Mvc.Repository
{
    public class BlogRepository : Repository<Entities.Blog>
    {
        public BlogRepository(BlogDbContext context) : base(context)
        {
        }
    }
}
