using System.ComponentModel.DataAnnotations.Schema;

namespace Mikencoderx.Models
{
    public class Lista_PL
    {
        [ForeignKey("Clientes")]
        public int FkClientes { get; set; }
        public Lenguajes lenguajes { get; set; }

        [ForeignKey("Programadores")]
        public int FkProgramadores { get; set; }
        public Programadores Programadores { get; set; }
    }
}
