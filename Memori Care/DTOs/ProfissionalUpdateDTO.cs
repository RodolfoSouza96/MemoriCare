using Memori_Care.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Memori_Care.DTOs;

public class ProfissionalUpdateDTO
{

    [StringLength(255, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 255 caracteres.")]
    public string Nome { get; set; }
    [StringLength(11)]
    public string CPF { get; set; }
    [JsonConverter(typeof(DateConverterBrasileiro))]
    public DateTime DataNascimento { get; set; }
    [StringLength(1)]
    public string Sexo { get; set; }
    public RacaCor Raca { get; set; }

    [Required(ErrorMessage = "O campo 'RegistroProfissional' é obrigatório!")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O Registro Profissional deve ter entre 3 e 100 caracteres.")]
    public string RegistroProfissional { get; set; }
    [Required(ErrorMessage = "O campo 'NumeroConselho' é obrigatório!")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "O Numero do Conselho deve ter entre 3 e 20 caracteres.")]
    public string NumeroConselho { get; set; }
    [Required(ErrorMessage = "O campo 'Especialidade' é obrigatório!")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "A especialidade deve ter entre 3 e 100 caracteres.")]
    public string Especialidade { get; set; }
    [JsonConverter(typeof(DateConverterBrasileiro))]
    public DateTime? DataAdmissao { get; set; }
    [Required]
    public bool Ativo { get; set; } = false;

}
