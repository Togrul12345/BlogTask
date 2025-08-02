using AutoMapper;

namespace Blog.Mvc.Profiles.BlogProfile
{
    public class BlogProfile:Profile
    {
        public BlogProfile()
        {
            CreateMap<Blog.Mvc.Entities.Blog, Dtos.BlogDtos.CreateBlogDto>().ReverseMap();
            CreateMap<Blog.Mvc.Entities.Blog, Dtos.BlogDtos.ResultBlogDto>().ReverseMap();
            CreateMap<Blog.Mvc.Entities.Blog, Dtos.BlogDtos.UpdateBlogDto>().ReverseMap();

        }
    }
}
