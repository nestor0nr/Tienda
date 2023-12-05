using System.ComponentModel.DataAnnotations;

namespace Tienda.Data.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe de tener maximo {1} caracter.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? Name { get; set; }

        public State state { get; set; } //1 Ciudad pertenece a una departamento

    }
}
