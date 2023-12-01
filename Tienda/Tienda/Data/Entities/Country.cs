using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tienda.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name="Pais")]
        [MaxLength(50,ErrorMessage ="El campo {0} debe de tener maximo {1} caracter.")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string? Name { get; set; }

    }
}
