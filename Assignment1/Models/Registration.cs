using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Registration
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        public string? username { get; set; }
        [Required(ErrorMessage = "Please enter a type.")]
        public string? type { get; set; }
        [Required(ErrorMessage = "Please enter a password.")]
        public string? password { get; set; }


    }
}
