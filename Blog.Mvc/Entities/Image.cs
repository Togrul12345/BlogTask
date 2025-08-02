namespace Blog.Mvc.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public Blog Blog { get; set; }
        public int BlogId { get; set; }
    }
}
