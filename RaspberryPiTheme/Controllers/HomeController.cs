using Microsoft.AspNetCore.Mvc;

namespace OrchardCore.Themes.RaspberryPiTheme.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
