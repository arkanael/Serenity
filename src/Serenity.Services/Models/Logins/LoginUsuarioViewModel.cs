using System.ComponentModel.DataAnnotations;

namespace Serenity.Services.Models.Logins
{
    public class LoginUsuarioViewModel
    {
        [Required(ErrorMessage = "O campo login é obrigatório.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        public string Senha { get; set; }
    }
}
