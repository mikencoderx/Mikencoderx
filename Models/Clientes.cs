using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mikencoderx.Models
{
    public class Clientes
    {
        [Key]
        public int PkCliente { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string RFC { get; set; }
    }
}
