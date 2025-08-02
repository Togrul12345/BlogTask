using AutoMapper;
using Blog.Mvc.Dtos.BlogDtos;
using Blog.Mvc.Sevices.Interfaces;

using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Blog.Mvc.Controllers
{
    public class BlogController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IBlogService _service;

        public BlogController(IBlogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogDto createBlogDto)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(new Blog.Mvc.Entities.Blog
                {
                    Title = createBlogDto.Title,
                    Content = createBlogDto.Content,
                    MainImage = createBlogDto.MainImage,
                    CreatedDate = createBlogDto.CreatedDate
                });
                // Here you would typically save the blog to the database
                // For now, we will just return the created blog data
                return RedirectToAction("Index", "Home");
            }
            return View(createBlogDto);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var blog = await _service.GetBlogWithImagesAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var blog = await _service.GetBlogWithImagesAsync(id);
           var result= _mapper.Map<UpdateBlogDto>(blog);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Blog.Mvc.Dtos.BlogDtos.UpdateBlogDto updateBlogDto)
        {
            if (ModelState.IsValid)
            {
               var blog= _mapper.Map<Blog.Mvc.Entities.Blog>(updateBlogDto);
                await _service.UpdateAsync(blog);
                return RedirectToAction("Index", "Home");
            }
            return View(updateBlogDto);
        }
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var blog = await _service.GetBlogWithImagesAsync(id);
           await _service.DeleteAsync(blog);
            return RedirectToAction("Index", "Home");
        }
    }
}
