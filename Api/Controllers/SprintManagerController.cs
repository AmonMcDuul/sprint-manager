using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class SprintManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
