using Microsoft.AspNetCore.Mvc;
using AppContext = Mikencoderx.Context.AppContext;

namespace Mikencoderx.Controllers
{
    public class PanelController : Controller
    {
        private readonly IHttpContextAccessor _Acess;
        private readonly AppContext _context;
        public PanelController(AppContext context, IHttpContextAccessor acess)
        {
            _context = context;
            _Acess = acess;
        }

        public IActionResult Index()
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar
            return View();
        }
    }
}
