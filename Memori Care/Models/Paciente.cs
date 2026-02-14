using Memori_Care.Enums;
using System.ComponentModel.DataAnnotations;

namespace Memori_Care.Models;

public class Paciente : Pessoa
{
    [Required(ErrorMessage = "O campo Idade é obrigatório")]
    public int Idade { get; set; }
    [Required(ErrorMessage = "O campo 'CNS' é obrigatório!")]
    [StringLength(15)]
    public string CNS { get; set; }
    public TipoSanguineo TipoSanguineo { get; set; }
    public bool Obito {  get; set; }



}
