namespace Blog.Mvc.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string MainImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Image> Images { get; set; }
    }
}
