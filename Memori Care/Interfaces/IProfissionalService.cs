using Memori_Care.DTOs;

namespace Memori_Care.Interfaces;

public interface IProfissionalService
{
    Task<ProfissionalReadDto> Criar(ProfissionalCreateDto profissionalDto);
    Task<IEnumerable<ProfissionalReadDto>> GetTodos(string? nome = null);
    Task<ProfissionalReadDto> GetPorId(int id);
    Task<ProfissionalReadDto> Atualizar(int id, ProfissionalUpdateDTO profissionalUpdateDTO);
    Task<bool> Inativar(int id);
    Task<bool> Ativar(int id);
}