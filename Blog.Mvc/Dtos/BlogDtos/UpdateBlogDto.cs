namespace Blog.Mvc.Dtos.BlogDtos
{
    public class UpdateBlogDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string MainImage { get; set; }
        public string CreatedDate { get; set; }
    }
}
