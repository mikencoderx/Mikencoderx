using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mikencoderx.Models
{
    public class Registros
    {
        [Key]
        public int PkRegistro { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey("Usuarios")]
        public int FkUsuarios { get; set; }
        public Usuarios Usuarios { get; set; }
    }
}
