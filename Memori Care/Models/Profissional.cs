using System.ComponentModel.DataAnnotations;

namespace Memori_Care.Models;

public class Profissional : Pessoa
{
    [Required(ErrorMessage = "O campo 'RegistroProfissional' é obrigatório!")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O Registro Profissional deve ter entre 3 e 100 caracteres.")]
    public string RegistroProfissional { get; set; }
    [Required(ErrorMessage = "O campo 'NumeroConselho' é obrigatório!")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "O Numero do Conselho deve ter entre 3 e 20 caracteres.")]
    public string NumeroConselho { get; set; }
    [Required(ErrorMessage = "O campo 'Especialidade' é obrigatório!")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "A especialidade deve ter entre 3 e 100 caracteres.")]
    public string Especialidade {  get; set; }
    public DateTime DataAdmissao { get; set; }
    public DateTime? DataInativacao {  get; set; }
    private bool _ativo;
    [Required]
    public bool Ativo
    {
        get => _ativo;
        set
        {
            _ativo = value;

            if (_ativo == false)
            {
                DataInativacao = DateTime.Now;
            }
            else
            {
                DataInativacao = null;
            }
        }
    }

}
