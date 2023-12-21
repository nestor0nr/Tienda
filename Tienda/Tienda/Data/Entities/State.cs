using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tienda.Data.Entities
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name = "Departamento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe de tener maximo {1} caracter.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? Name { get; set; }

        [JsonIgnore]
        public  Country country { get; set; }//1 Departamento pertenece a 1 pais

        public ICollection<City> Cities { get; set; } //1 de departamento tiene una lista de Ciuddades

        [Display(Name = "Ciudades")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;


    }
}
