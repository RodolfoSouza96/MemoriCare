using AutoMapper;
using Memori_Care.Data;
using Memori_Care.DTOs;
using Memori_Care.Interfaces;
using Memori_Care.Models;
using Microsoft.EntityFrameworkCore;

namespace Memori_Care.Services;

public class ProfissionalService : IProfissionalService
{

    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProfissionalService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProfissionalReadDto> Atualizar(int id, ProfissionalUpdateDTO profissionalUpdateDTO)
    {
        var buscaProfissional = await _context.Profissionais.FindAsync(id);

        if (buscaProfissional is null)
        {
            throw new Exception("Profissional não encontrado!");
        }

        _mapper.Map(profissionalUpdateDTO, buscaProfissional);

        await _context.SaveChangesAsync();

        return _mapper.Map<ProfissionalReadDto>(buscaProfissional);

    }

    public async Task<ProfissionalReadDto> Criar(ProfissionalCreateDto profissionalDto)
    {
        if(profissionalDto == null)
        {
            throw new Exception("Dados inválidos!");
        }

        var profissional = _mapper.Map<Profissional>(profissionalDto);
        _context.Profissionais.Add(profissional);

        var novoProfissional = await _context.SaveChangesAsync();

        var novoProfissionalDto = _mapper.Map<ProfissionalReadDto>(profissional);
        return novoProfissionalDto;
    }

    public async Task<ProfissionalReadDto> GetPorId(int id)
    {
        var profissional = await _context.Profissionais.FindAsync(id);
        
        if (profissional is null)
        {
            throw new Exception("Profissional não encontrado!");
        }

        var profissionalDto = _mapper.Map<ProfissionalReadDto>(profissional);

        return profissionalDto;
    }

    public async Task<IEnumerable<ProfissionalReadDto>> GetTodos(string? nome = null)
    {
        var profissionais = await _context.Profissionais.ToListAsync() ?? new();
        return _mapper.Map<IEnumerable<ProfissionalReadDto>>(profissionais);
    }

    public async Task<bool> Inativar(int id)
    {
        var buscaProfissional = await _context.Profissionais.FindAsync(id);

        if (buscaProfissional is null)
        {
            throw new Exception("Profissional não encontrado!");
        }

        buscaProfissional.Ativo = false;
        await _context.SaveChangesAsync();

        return true;

    }
    public async Task<bool> Ativar(int id)
    {
        var buscaProfissional = await _context.Profissionais.FindAsync(id);

        if (buscaProfissional is null)
        {
            throw new Exception("Profissional não encontrado!");
        }

        buscaProfissional.Ativo = true;
        buscaProfissional.DataInativacao = null;
        await _context.SaveChangesAsync();

        return true;

    }
}
