using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mikencoderx.Models
{
    public class Membresias
    {
        [Key]
        public int PkMembresias { get; set; } 
        public bool Estado { get; set; }

        [ForeignKey("Clientes")]
        public int FkClientes { get; set; }
        public Clientes Clientes { get; set; }

        [ForeignKey("Proyecto")]
        public int FkProyecto { get; set; }
        public Proyectos Proyectos { get; set; }

        [ForeignKey("Detalles")]
        public int FkDetalles { get; set; }
        public Detalles Detalles { get; set; }
    }
}
