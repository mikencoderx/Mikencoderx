using AppContext = Mikencoderx.Context.AppContext;
using Microsoft.AspNetCore.Mvc;

namespace Mikencoderx.Controllers
{
    public class PlanesController : Controller
    {
        private readonly IHttpContextAccessor _Acess;
        private readonly AppContext _context;
        public PlanesController(AppContext context, IHttpContextAccessor acess)
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
