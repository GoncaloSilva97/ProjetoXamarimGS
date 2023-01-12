using System.ComponentModel.DataAnnotations;

namespace ProjetoXamarimGS.Models
{
    public class SearchCityViewModel
    {
        [Required(ErrorMessage = "City name is empty!")]
        [Display(Name = "City Name")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid Input, Length must be between 2 and 20 charactres")]


        public string CityName { get; set; }

    }
}
