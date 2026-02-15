using Memori_Care.DTOs;
using Memori_Care.Models;

namespace Memori_Care.Interfaces;

public interface IPacienteService
{
    Task<IEnumerable<PacienteReadDTO>> GetTodos();
    Task<PacienteReadDTO> GetPorId(int id);
    Task<PacienteReadDTO> Criar(PacienteCreateDTO pacienteDto);
    Task<bool> AtivarObito(int id, DateTime dataDigitada);
    Task<bool> RemoverObito(int id);
}