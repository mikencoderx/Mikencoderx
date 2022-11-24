using Microsoft.AspNetCore.Mvc;

namespace Mikencoderx.Controllers
{
    public class ProyectosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
