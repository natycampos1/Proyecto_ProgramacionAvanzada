using System.ComponentModel.DataAnnotations;

namespace KN_WEB.Models
{
    public class UsuarioRegistroModel
    {
        [Required(ErrorMessage = "La identificación es obligatoria")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public string Contrasenna { get; set; }

        [Required(ErrorMessage = "Debe confirmar la contraseña")]
        [DataType(DataType.Password)]
        [Compare("Contrasenna", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmarContrasenna { get; set; }
    }
}