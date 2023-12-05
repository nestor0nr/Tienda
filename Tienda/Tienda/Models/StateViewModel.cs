using System.ComponentModel.DataAnnotations;

namespace Tienda.Models
{
    public class StateViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Departamento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe de tener maximo {1} caracter.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? Name { get; set; }

        public int CountryID { get; set; }
    }
}
