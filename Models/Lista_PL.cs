using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mikencoderx.Models
{
    public class Lista_PL
    {
        public int Porcentaje { get; set; }

        [ForeignKey("Tecnologias")]
        public int FkTecnologiass { get; set; }
        public Tecnologias Tecnologias { get; set; }

        [ForeignKey("Programadores")]
        public int FkProgramadores { get; set; }
        public Programadores Programadores { get; set; }

        [Key]
        public int pkLista { get; set; }
    }
}
