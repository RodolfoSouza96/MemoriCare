using Memori_Care.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Memori_Care.DTOs;

public class PacienteCreateDto
{

    [Required(ErrorMessage = "O campo 'Nome' é obrigatório!")]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 255 caracteres.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O campo 'CPF' é obrigatório!")]
    [StringLength(11)]
    public string CPF { get; set; }
    [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]
    [JsonConverter(typeof(DateConverterBrasileiro))]
    public DateTime DataNascimento { get; set; }
    [Required(ErrorMessage = "O campo Idade é obrigatório")]
    public int Idade { get; set; }
    [Required(ErrorMessage = "O campo 'Sexo' é obrigatório!")]
    [StringLength(1)]
    public string Sexo { get; set; }
    [Required(ErrorMessage = "Ocampo 'Raça' é obrigatório!")]
    public RacaCor Raca { get; set; }
    [Required(ErrorMessage = "O campo CNS é obrigatório")]
    public string CNS { get; set; }
    public TipoSanguineo TipoSanguineo { get; set; }
    public bool Obito { get; set; }

}
