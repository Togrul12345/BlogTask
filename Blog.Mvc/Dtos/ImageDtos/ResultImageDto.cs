namespace Blog.Mvc.Dtos.ImageDtos
{
    public class ResultImageDto
    {
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public Blog.Mvc.Entities.Blog Blog { get; set; }
        public int BlogId { get; set; }
    }
}
