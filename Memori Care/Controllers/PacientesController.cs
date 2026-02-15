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
    public async Task<IActionResult> Criar([FromBody] PacienteCreateDTO pacienteDto)
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

    [HttpPut("{id:int}/ativar")]
    public async Task<IActionResult> AtivarObito(int id, DateTime dataSugerida) {

        var ativou = await _service.AtivarObito(id, dataSugerida);

        if (ativou)
        {
            return NoContent();
        }
        return NotFound("Não foi possivel localizar o paciente para colocar o óbito!");

    }

    [HttpPut("{id:int}/remover-obito")]
    public async Task<IActionResult> RemoverObito(int id)
    {
        var inativar = await _service.RemoverObito(id);

        if (inativar)
        {
            return NoContent();
        }

        return NotFound("Não foi possivel localizar o paciente para remover o óbito!");
    }
}
