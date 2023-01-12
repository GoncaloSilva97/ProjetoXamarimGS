using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjetoXamarimGS.Data.Entities
{
    public class User : IdentityUser
    {

        //[Key]
        //[override]
        //public override string Id { get; set; }
        //public new string Id { get; set; }
        //public string Id { get; set; }

        //public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters lenght.")]
        public string FirstName { get; set; }


        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters lenght.")]
        public string LastName { get; set; }


        

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}