namespace Blog.Mvc.Dtos.BlogDtos
{
    public class CreateBlogDto
    {
        
        public string Title { get; set; }
        public string Content { get; set; }
        public string MainImage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
