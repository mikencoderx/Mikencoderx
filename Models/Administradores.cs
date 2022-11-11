using System.ComponentModel.DataAnnotations;

namespace Mikencoderx.Models
{
    public class Administradores
    {
        [Key]
        public int PkAdministradores { get; set; }
        public string nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
    }
}
