using Memori_Care.DTOs;
using Memori_Care.Interfaces;
using Memori_Care.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Memori_Care.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProfissionaisController : ControllerBase
{

    private readonly IProfissionalService _service;

    public ProfissionaisController(IProfissionalService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(ProfissionalCreateDto profissionalDto)
    {
        var criar = await _service.Criar(profissionalDto);

        if (criar == null)
        {
            return BadRequest("Dados inválidos!!");
        }

        return CreatedAtRoute("ObterProfissional", new { id = criar.Id }, criar);
    }

    [HttpGet("{id:int}", Name = "ObterProfissional")]
    public async Task<IActionResult> GetPorId(int id)
    {
        var profissionalId = await _service.GetPorId(id);

        if (profissionalId is null)
        {
            return NotFound($"Profissional com id = {id} não foi encontrada!!");
        }

        return Ok(profissionalId);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var profissionais = await _service.GetTodos();

        return Ok(profissionais);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar(int id, ProfissionalUpdateDTO profissionalUpdateDTO) 
    {
        var atualizacao = await _service.Atualizar(id, profissionalUpdateDTO);

        if (atualizacao is null)
        {
            return NotFound($"Profissional com id = {id} não foi encontrada!!");
        }

        return Ok(atualizacao);
    }

    [HttpPut("{id:int}/ativar")]
    public async Task<IActionResult> Ativar(int id)
    {
        var ativou = await _service.Ativar(id);

        if (ativou)
        {
            return NoContent();
        }
        return NotFound("Não foi possivel localizar o profissonal para inativação.");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Inativar(int id)
    {
        var inativar = await _service.Inativar(id);
        
        if(inativar)
        {
            return NoContent();
        }
        return NotFound("Não foi possivel localizar o profissonal para inativação.");
    }

    


}

