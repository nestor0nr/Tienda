using System.ComponentModel.DataAnnotations;

namespace Tienda.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe de tener maximo {1} caracter.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? Name { get; set; }

        public int StateId { get; set; } //para saber a que Departamento pertenece la ciudad
    }
}
