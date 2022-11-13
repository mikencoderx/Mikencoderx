using System.ComponentModel.DataAnnotations;

namespace Mikencoderx.Models
{
    public class Programadores
    {
        [Key]
        public int PkPrgramadores { get; set; }
        public string Nombre { get; set; }
        public string URLFoto { get; set; }
        public string Correo { get; set; }
        public string Descrpcion { get; set; }
    }
}
