using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mikencoderx.Models
{
    public class Membresias
    {
        [Key]
        public int PkMembresias { get; set; } 

        public DateTime FechaApertura { get; set; }
        public DateTime FechaVencimiento { get; set; }

        [ForeignKey("Planes")]
        public int FkPlanes { get; set; }
        public Planes Planes { get; set; }

        [ForeignKey("Clientes")]
        public int FkClientes { get; set; }
        public Clientes Clientes { get; set; }

        [ForeignKey("Proyectos")]
        public int FkProyecto { get; set; }
        public Proyectos Proyectos { get; set; }

    }
}
