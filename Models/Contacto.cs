using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud7MVC.Models
{
    public class Contacto
    {
  
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Telefono es requerido")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Celular es requerido")]
        public string Celular { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; }
    }
}