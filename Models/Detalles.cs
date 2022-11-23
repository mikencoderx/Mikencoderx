using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mikencoderx.Models
{
    public class Detalles
    {
        [Key]
        public int PkDetelle { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FwechaVencimiento { get; set; }
        [ForeignKey("Planes")]
        public int FkPlanes { get; set; }
        public Planes Planes { get; set; }
        public bool Estado { get; set; }

    }
}
