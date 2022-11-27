using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Mikencoderx.Models
{
    public class Roles
    {
        [Key]
        public int PkRol { get; set; }
        public string Nombre { get; set; }
    }
}
