using Blog.Mvc.Repository;
using Blog.Mvc.Sevices.Interfaces;
using BlogMvc.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Mvc.Sevices.Implementation
{
    public class BlogService : BlogRepository, IBlogService
    {
        private readonly BlogDbContext _context;
        public BlogService(BlogDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Entities.Blog> GetAll()
        {
            return _context.Blogs;
        }

        public IQueryable<Entities.Blog> GetBlogsWithFilter(Expression<Func<Entities.Blog, bool>>? query)
        {
            return _context.Blogs.Where(query) ;
        }

        public async Task<Entities.Blog> GetBlogWithImagesAsync(int blogId)
        {
            return await _context.Blogs.Include(a => a.Images).FirstOrDefaultAsync(a => a.BlogId == blogId); ;
        }
    }
}
