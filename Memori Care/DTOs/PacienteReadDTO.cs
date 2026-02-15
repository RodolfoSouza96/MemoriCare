using Memori_Care.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Memori_Care.DTOs;

public class PacienteReadDTO
{
    public int Id {  get; set; }
    public string NumeroProntuario { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    [JsonConverter(typeof(DateConverterBrasileiro))]

    public DateTime? DataNascimento { get; set; }
    public int Idade { get; set; }
    public string Sexo { get; set; }
    public RacaCor Raca { get; set; }
    public string CNS { get; set; }
    public TipoSanguineo TipoSanguineo { get; set; }
    public bool Obito { get; set; }
    [JsonConverter(typeof(DateConverterBrasileiro))]

    public DateTime? DataObito { get; set; }

}
