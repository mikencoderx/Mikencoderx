using Microsoft.AspNetCore.Mvc;
using AppContext = Mikencoderx.Context.AppContext;


namespace Mikencoderx.Controllers
{
    public class LogginContraller : Controller
    {
        private readonly AppContext _context;

        public LogginContraller( AppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginUser(string user, string Password)
        {
            try
            {
                var response = _context.Administradores.Where(x => x.Usuario == user && x.Contraseña == Password).ToList();
                if (response.Count() > 0)
                {
                    //se va a logear
                    return Json(new { success = true });
                }
                else
                {
                    //Errors
                    return Json(new { success = false });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un eror" + ex.Message);
            }
        }

    }
}
