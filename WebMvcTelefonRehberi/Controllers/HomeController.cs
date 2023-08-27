using Microsoft.AspNetCore.Mvc;

namespace WebMvcTelefonRehberi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
