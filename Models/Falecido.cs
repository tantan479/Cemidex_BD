using System.ComponentModel.DataAnnotations;
namespace Cemidex_BD.Models;

public class Falecido
{
    [Key]
    public int IDFalecido { get; set; }
    [Required][StringLength(64)]
    public string Nome { get; set; }
    [Required][StringLength(64)][Display(Name = "Nome da Mãe")]
    public string NomeMae { get; set; }
    [Required][StringLength(64)][Display(Name = "Nome do Pai")]
    public string NomePai { get; set; }
    [Required][Display(Name = "Data do Enterro")]
    public DateTime TempoEnterro { get; set; }
    [Required]
    public char Sexo { get; set; }
    [Required][StringLength(16)]
    public string EstadoCivil { get; set; }
    [Required][Display(Name = "Registro de Óbito")]
    public string RegistroObito { get; set; }
    [Required][Display(Name = "Certidão de Óbito")]
    public string CertidaoObito { get; set; }
    [Display(Name = "Data de Óbito")]
    public DateTime DataObito{ get; set; }
    [Display(Name = "Data de Nascimento")]
    public DateTime DataNascimento{ get; set; }
}
