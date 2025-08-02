using System.Diagnostics;
using Blog.Mvc.Entities;
using Blog.Mvc.Models;
using Blog.Mvc.Sevices.Interfaces;
using Blog.Mvc.Sevices.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Blog.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _service;

        public HomeController(IBlogService service)
        {
           
            _service = service;
        }

        public async Task<IActionResult> Index(string currentFilter,int? pageNumber,string sort,string searchString)
        {
            ViewData["DateSort"] = String.IsNullOrEmpty(sort) ? "date_desc" : "";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var blogs = _service.GetAll();
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                 blogs = _service.GetBlogsWithFilter(a => a.Title.Contains(searchString));
            }

            ViewData["CurrentSort"] = sort;
            switch (sort)
            {
                case "date_desc":
                    blogs = blogs.OrderByDescending(a => a.CreatedDate);
                    break;
                default:
                    blogs = blogs.OrderBy(a => a.CreatedDate);
                    break;

            }
            int pageSize = 3;
           

            return View(await PaginatedList<Blog.Mvc.Entities.Blog>.CreateAsync(blogs.AsNoTracking(),pageNumber??1,pageSize));
        }

       
    }
}
