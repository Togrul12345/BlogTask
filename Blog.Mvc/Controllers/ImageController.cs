using Blog.Mvc.Dtos.ImageDtos;
using Blog.Mvc.Entities;
using Blog.Mvc.Sevices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Mvc.Controllers
{
    public class ImageController : Controller
    {
        private readonly IRepository<Blog.Mvc.Entities.Image> _repository;
        private readonly IBlogService _service;

        public ImageController(IRepository<Entities.Image> repository, IBlogService service)
        {

            _repository = repository;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            ViewBag.blogId = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateImageDto createImageDto)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(new Blog.Mvc.Entities.Image
                {
                    ImageUrl = createImageDto.ImageUrl,
                    BlogId = createImageDto.BlogId,
                    
                });

                // Redirect to the blog details or index page after creating the image
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            var blog=await _service.GetBlogWithImagesAsync(id);
            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveImage(int id,int BlogId)
        {
            var image = await _repository.GetByIdAsync(id);
            if (image != null)
            {
                await _repository.DeleteAsync(image);
                return RedirectToAction("Remove", "Image", new {id=BlogId});
            }
            return BadRequest("image not found");
        }
    }
}
