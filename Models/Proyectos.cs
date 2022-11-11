using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mikencoderx.Models
{
    public class Proyectos
    {
        [Key]
        public int PkProg { get; set; }
        public string URLWeb { get; set; }
        public string URLMaster { get; set; }

        [ForeignKey("Programadores")]
        public int FkProgramadores { get; set; }
        public Programadores Programador { get; set; }
    }
}
