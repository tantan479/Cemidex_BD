using System.ComponentModel.DataAnnotations;

namespace Cemidex_BD.Models;

public class LoginViewModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    [Display(Name = "Lembrar de mim")]
    public bool Lembrar { get; set; }
}