using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mikencoderx.Models;
using System.Diagnostics;
using AppContext = Mikencoderx.Context.AppContext;

namespace Mikencoderx.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppContext _context;
        public HomeController(AppContext context, IHttpContextAccessor acess)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            var programadores = await _context.Programadores.Where(x=>x.Estado == true).ToListAsync();
            var tecnologias = await _context.Tecnologias.ToListAsync();
            var planes = await _context.Planes.Where(x => x.Estado == true).ToListAsync();

            Coleccion x = new Coleccion();
            x.Planes = planes;
            x.Programadores = programadores;
            x.tecnologias = tecnologias;

            return View(x);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}