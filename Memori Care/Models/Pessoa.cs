using Memori_Care.Enums;
using System.ComponentModel.DataAnnotations;

namespace Memori_Care.Models;

public abstract class Pessoa
{

    [Key]
    public int Id { get; set; }
    [StringLength(255, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 255 caracteres.")]
    public string Nome { get; set; }
    [StringLength(11)]
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    [StringLength(1)]
    public string Sexo { get; set; }
    public RacaCor Raca { get; set; }


}
