using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Mikencoderx.Models
{
    public class Tecnologias
    {
        [Key]
        public int PkTecnologias { get; set; }
        public string Nombre { get; set; }
        public string URLFoto { get; set; }
    }
}
