using Memori_Care.DTOs;
using Memori_Care.Interfaces;
using Memori_Care.Models;
using Microsoft.AspNetCore.Mvc;

namespace Memori_Care.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PacientesController : ControllerBase
{

    private readonly IPacienteService _service;

    public PacientesController(IPacienteService service)
    {
        _service = service;
    }


    [HttpPost()]
    public async Task<IActionResult> Criar([FromBody] PacienteCreateDto pacienteDto)
    {
        var criar = await _service.Criar(pacienteDto);

        if (criar == null)
        {
            return BadRequest("Dados inválidos!!");
        }

        return CreatedAtRoute("ObterPaciente", new { id = criar.Id }, criar);
    }

    [HttpGet("{id:int}", Name = "ObterPaciente")]
    public async Task<IActionResult> GetPorId(int id)
    {
        var pacienteId = await _service.GetPorId(id);

        if (pacienteId is null)
        {
            return NotFound($"Paciente com id = {id} não foi encontrada!!");
        }

        return Ok(pacienteId);

    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        var pacientes = await _service.GetTodos();

        return Ok(pacientes);
    }
}
