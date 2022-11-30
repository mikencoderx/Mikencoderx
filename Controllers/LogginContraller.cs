using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Mikencoderx.Models;
using System;
using System.Data;
using Mikencoderx.Models;
using AppContext = Mikencoderx.Context.AppContext;
using Microsoft.EntityFrameworkCore;

namespace Mikencoderx.Controllers
{
    public class LogginContraller : Controller
    {
        private readonly IHttpContextAccessor _Acess;
        private readonly AppContext _context;
        public LogginContraller(AppContext context, IHttpContextAccessor acess)
        {
            _context = context;
            _Acess = acess;
        }

        public IActionResult Index()
        {
            if(_Acess.HttpContext.Session.GetString("Rol") != null )
            {
                return Redirect("~/Programadores/Index");
            }
            return View();
        }

        [HttpPost]
        public JsonResult LoginUser(string user, string Password)
        {
            try
            {
                var response = _context.Usuarios.Include(i=>i.Roles).Where(x => x.Usuario == user && x.Contraseña == Password).FirstOrDefault();
                if (response != null)
                {
                    _Acess.HttpContext.Session.SetString("Rol", response.Roles.Nombre);
                    _Acess.HttpContext.Session.SetInt32("Pk", response.PkUsuario);
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
