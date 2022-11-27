using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mikencoderx.Models
{
    public class Usuarios
    {
        [Key]
        public int PkUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
        public string Usuario { get; set; }

        [ForeignKey("Roles")]
        public int FkRoles { get; set; }
        public Roles Roles { get; set; }

        //esta seccion o objeto es para el loggin
    }
}
