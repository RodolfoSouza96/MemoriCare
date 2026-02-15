using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Memori_Care.Models;

public class Atendimento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public int Boletim { get; set; }
    [Required]
    public Profissional ProfissionalId { get; set; }
    [ForeignKey("ProfissionalId")]
    public Profissional Profissional {  get; set; }
    [Required]
    public Paciente PacienteId { get; set; }
    [ForeignKey("PacienteId")]
    public Paciente Paciente { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFinal {  get; set; }
    [StringLength(4000, MinimumLength = 20)]
    public string? Anamense { get; set; }
    [StringLength(4000, MinimumLength = 20)]
    public string? Plano { get; set; }
    [StringLength(4000, MinimumLength = 20)]
    public string? Prescricao { get; set; }


}
