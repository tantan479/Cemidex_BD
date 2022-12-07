using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cemidex_BD.Models;

public class Falecido
{
    [Key]
    public int IDFalecido { get; set; }
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [StringLength(64)]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [StringLength(64)]
    [Display(Name = "Nome da Mãe")]
    public string NomeMae { get; set; }
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [StringLength(64)]
    [Display(Name = "Nome do Pai")]
    public string NomePai { get; set; }
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Data do Enterro")]
    public DateTime TempoEnterro { get; set; }
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public char Sexo { get; set; }
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [StringLength(16)]
    public string EstadoCivil { get; set; }
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Registro de Óbito")]
    public string RegistroObito { get; set; }
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Certidão de Óbito")]
    public string CertidaoObito { get; set; }
    [Display(Name = "Data de Óbito")]
    public DateTime DataObito { get; set; }
    [Display(Name = "Data de Nascimento")]
    public DateTime DataNascimento { get; set; }

    [NotMapped, Required]
    public IFormFile ArquivoImagem { get; set; }

    [NotMapped]
    public string CaminhoImagem
    {
        get
        {
            var caminhoArquivoImagem = Path.Combine(
                $"\\img\\falecido\\", this.IDFalecido.ToString("D6") + ".jpg");
            return caminhoArquivoImagem;
        }
    }
}
