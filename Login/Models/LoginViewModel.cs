using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El campo debe ser un correo electronico válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
