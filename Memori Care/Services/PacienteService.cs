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

    public async Task<bool> AtivarObito(int id, DateTime dataDigitada)
    {
        var buscaPaciente = await _context.Pacientes.FindAsync(id);

        if (buscaPaciente == null) {

            throw new Exception("Paciente não encontrado!");
        }

        buscaPaciente.Obito = true;
        buscaPaciente.DataObito = dataDigitada;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<PacienteReadDTO> Criar(PacienteCreateDTO pacienteDto)
    {
        string anoCurto = DateTime.Now.ToString("yy");

        if (pacienteDto is null)
        {
            throw new Exception("Dados inválidos!");
        }

        if (pacienteDto.Obito && pacienteDto.DataObito == null)
        {
            throw new Exception("Se o óbito for confirmado, a data do óbito deve ser informada.");
        }

        var paciente = _mapper.Map<Paciente>(pacienteDto);

        string prefixo = anoCurto + "-";

        var contagemAno = await _context.Pacientes
            .CountAsync(p => p.NumeroProntuario != null && p.NumeroProntuario.StartsWith(prefixo));

        int proximoNumero = contagemAno + 1;

        paciente.NumeroProntuario = $"{prefixo}{proximoNumero:D4}";

        _context.Pacientes.Add(paciente);

        var resultado = await _context.SaveChangesAsync();

        if (resultado <= 0)
        {
            throw new Exception("Não foi possível salvar o paciente no banco de dados.");
        }

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

    public async Task<bool> RemoverObito(int id)
    {
        var buscaPaciente = await _context.Pacientes.FindAsync(id);
        
        if (buscaPaciente is null)
        {
            throw new Exception("Paciente não encontrado!");
        }

        buscaPaciente.Obito = false;
        await _context.SaveChangesAsync();

        return true;

    }
}
