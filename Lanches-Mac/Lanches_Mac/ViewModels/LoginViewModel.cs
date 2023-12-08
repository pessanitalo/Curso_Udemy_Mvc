using System.ComponentModel.DataAnnotations;

namespace Lanches_Mac.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Campo Obrigatorio")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
