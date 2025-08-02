using AutoMapper;

namespace Image.Mvc.Profiles.ImageProfile
{
    public class ImageProfile:Profile
    {
        public ImageProfile()
        {

            CreateMap<Blog.Mvc.Entities.Image, Blog.Mvc.Dtos.ImageDtos.CreateImageDto>().ReverseMap();
            CreateMap<Blog.Mvc.Entities.Image, Blog.Mvc.Dtos.ImageDtos.ResultImageDto>().ReverseMap();
            CreateMap<Blog.Mvc.Entities.Image, Blog.Mvc.Dtos.ImageDtos.UpdateImageDto>().ReverseMap();
        }
    }
}
