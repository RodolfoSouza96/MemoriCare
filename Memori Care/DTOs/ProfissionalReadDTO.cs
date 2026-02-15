using Memori_Care.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Memori_Care.DTOs;

public class ProfissionalReadDto
{

    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    [JsonConverter(typeof(DateConverterBrasileiro))]
    public DateTime DataNascimento { get; set; }
    public string Sexo { get; set; }
    public RacaCor Raca { get; set; }
    public string RegistroProfissional { get; set; }
    public string NumeroConselho { get; set; }
    public string Especialidade { get; set; }
    [JsonConverter(typeof(DateConverterBrasileiro))]
    public DateTime DataAdmissao { get; set; }
    [JsonConverter(typeof(DateConverterBrasileiro))]
    public DateTime? DataInativacao { get; set; }
    public bool Ativo { get; set; } = false;

}
