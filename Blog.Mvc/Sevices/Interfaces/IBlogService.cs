
using BlogMvc.Contexts;
using System.Linq.Expressions;

namespace Blog.Mvc.Sevices.Interfaces
{
    public interface IBlogService :  IRepository<Blog.Mvc.Entities.Blog>
    {
       
        Task<Blog.Mvc.Entities.Blog> GetBlogWithImagesAsync(int blogId);
        IQueryable<Blog.Mvc.Entities.Blog> GetBlogsWithFilter(Expression<Func<Blog.Mvc.Entities.Blog,bool>>? query);
        IQueryable<Blog.Mvc.Entities.Blog> GetAll();
       
    }
   
}
