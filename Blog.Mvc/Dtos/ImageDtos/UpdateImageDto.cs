namespace Blog.Mvc.Dtos.ImageDtos
{
    public class UpdateImageDto
    {
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
       
        public int BlogId { get; set; }
    }
}
