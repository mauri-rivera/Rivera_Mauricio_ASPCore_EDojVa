#pragma warning disable CS8618

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDojVa.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "Debe proporcionar un dato!!")]
        [MinLength(2, ErrorMessage = "Debe tener al menos 2 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe proporcionar un dato!!")]
        public string Ubicacion { get; set; }

        [Required(ErrorMessage = "Debe proporcionar un dato!!")]
        public string Lenguaje { get; set; }

        [MinLength(21, ErrorMessage = "Debe tener al menos 21 caracteres")]
        public string? Comentario { get; set; }
    }
}