using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mikencoderx.Models
{
    public class Resgistros
    {
        [Key]
        public int PkRegistro { get; set; }
        public string accion { get; set; }
        public DateTime fecha { get; set; }
        [ForeignKey("Administradores")]
        public int FkAdministrador { get; set; }
        public Administradores Administradores { get; set; }
    }
}
