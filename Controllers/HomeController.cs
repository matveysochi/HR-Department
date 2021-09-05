using Microsoft.AspNetCore.Mvc;

namespace HRD.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}