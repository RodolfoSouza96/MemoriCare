using Memori_Care.DTOs;
using Memori_Care.Models;

namespace Memori_Care.Interfaces;

public interface IPacienteService
{
    Task<IEnumerable<PacienteReadDTO>> GetTodos();
    Task<PacienteReadDTO> GetPorId(int id);
    Task<PacienteReadDTO> Criar(PacienteCreateDto pacienteDto);
}