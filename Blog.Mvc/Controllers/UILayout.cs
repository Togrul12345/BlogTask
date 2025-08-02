using Microsoft.AspNetCore.Mvc;

namespace Blog.Mvc.Controllers
{
    public class UILayout : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
