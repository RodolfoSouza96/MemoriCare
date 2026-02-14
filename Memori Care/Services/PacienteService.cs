using AutoMapper;
using Memori_Care.Data;
using Memori_Care.DTOs;
using Memori_Care.Interfaces;
using Memori_Care.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Memori_Care.Services;

public class PacienteService : IPacienteService
{

    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public PacienteService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PacienteReadDTO> Criar(PacienteCreateDto pacienteDto)
    { 
        if(pacienteDto is null)
        {
            throw new Exception("Dados inválidos!");
        }

        var paciente = _mapper.Map<Paciente>(pacienteDto);

        _context.Pacientes.Add(paciente);

        var novoPaciente = await _context.SaveChangesAsync();

        var novoPacienteDto = _mapper.Map<PacienteReadDTO>(paciente);
        return novoPacienteDto;

    }

    public async Task<PacienteReadDTO> GetPorId(int id)
    {

        var paciente = await _context.Pacientes.FindAsync(id);

        if (paciente is null)
        {
            throw new Exception("Paciente não encontrado!");
        }

        var pacienteDto = _mapper.Map<PacienteReadDTO>(paciente);

        return pacienteDto;

    }

    public async Task<IEnumerable<PacienteReadDTO>> GetTodos()
    {
          var pacientes = await _context.Pacientes.ToListAsync() ?? new();
          return _mapper.Map<IEnumerable<PacienteReadDTO>>(pacientes);
          
    }
}
