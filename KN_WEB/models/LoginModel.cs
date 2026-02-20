
using System.ComponentModel.DataAnnotations;

namespace KN_WEB.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "La identificación es obligatoria")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public string Contrasenna { get; set; }

        public bool Remember { get; set; }
    }
}