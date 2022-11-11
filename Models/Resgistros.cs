using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mikencoderx.Models
{
    public class Resgistros
    {
        [Key]
        public int PkRegistro { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey("Administradores")]
        public int FkAdministrador { get; set; }
        public Administradores Administradores { get; set; }
    }
}
