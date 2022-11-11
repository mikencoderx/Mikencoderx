using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Mikencoderx.Models
{
    public class Lenguajes
    {
        [Key]
        public int PkLenguajes { get; set; }
        public string Nombre { get; set; }
        public string URLFoto { get; set; }

    }
}
