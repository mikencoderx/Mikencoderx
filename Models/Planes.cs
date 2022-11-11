using System.ComponentModel.DataAnnotations;

namespace Mikencoderx.Models
{
    public class Planes
    {
        [Key]
        public int PkPlanes { get; set; }
        public string Tipo { get; set; }
        public double cantidad { get; set; }
        public double estado { get; set; }
    }
}
