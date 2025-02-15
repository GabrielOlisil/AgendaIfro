using AgendaApp.Context;
using AgendaApp.Services;
using Lib.Classes.Dtos.Agenda;
using Lib.Classes.Dtos.Categoria;
using Lib.Classes.Dtos.Intervalo;
using Lib.Classes.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.Controllers;

[ApiController]
[Route("[controller]")]
public class AgendasController(
    AgendaContext context,
    IntervaloService intervaloService,
    CategoriaService categoriaService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<Agenda>> GetAgendaById(Guid id)
    {
        var agenda = await context.Agendamentos.Include(a => a.Intervalo)
            .Include(a => a.Categoria)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (agenda == null)
        {
            return NotFound();
        }

        return agenda;
    }

    [HttpGet]
    public async Task<List<AgendaCreateDto>> ListAgenda()
    {
        var data = await context.Agendamentos.Select(a => new AgendaCreateDto
        {
            Titulo = a.Titulo,
            Descricao = a.Descricao,
            Dia = a.Dia,
            IntervaloId = a.Intervalo.Id,  // Apenas o ID de Intervalo
            CategoriaId = a.Categoria.Id
        }).ToListAsync();


        return data;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Agenda>> CreateAgenda(AgendaCreateDto agendaRequest)
    {
        Agenda agenda = null;
        try
        {
            agenda = new Agenda()
            {
                Id = Guid.Empty,
                Titulo = agendaRequest.Titulo,
                Descricao = agendaRequest.Descricao,
                Dia = agendaRequest.Dia,
                Intervalo = await intervaloService.FindIntervalo(agendaRequest.IntervaloId!.Value),
            };

            if (agendaRequest.CategoriaId is not null)
            {
                agenda.Categoria = await categoriaService.FindCategoria(agendaRequest.CategoriaId!.Value);
            }
            
            context.Agendamentos.Add(agenda);


            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return BadRequest("Dados foram enviados no formato inválido\n" + e.Message);
        }
        

  

        return CreatedAtAction(nameof(GetAgendaById), new { id = agenda.Id }, agenda);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<Categoria>> UpdateAgenda(Guid id, AgendaUpdateDto agendaUpdateDto)
    {
        var agenda = await context.Agendamentos.FindAsync(id);

        if (agenda is null) return NotFound();

        if (agendaUpdateDto.Titulo is not null)
        {
            agenda.Titulo = agendaUpdateDto.Titulo;
        }

        if (agendaUpdateDto.Dia.HasValue)
        {
            agenda.Dia = agendaUpdateDto.Dia.Value;
        }

        if (agendaUpdateDto.Descricao is not null)
        {
            agenda.Descricao = agendaUpdateDto.Descricao;
        }

        if (agendaUpdateDto.CategoriaId is not null)
        {
            try
            {
                agenda.Categoria = await categoriaService.FindCategoria(id);
            }
            catch
            {
                return NotFound("Categoria Not Found");
            }
        }

        if (agendaUpdateDto.IntervaloId is not null)
        {
            try
            {
                agenda.Intervalo = await intervaloService.FindIntervalo(id);
            }
            catch
            {
                return NotFound("Intervalo Not Found");
            }
        }

        context.Agendamentos.Update(agenda);


        var changes = context.Entry(agenda).State == EntityState.Modified;

        if (changes)
        {
            await context.SaveChangesAsync();
        }

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAgenda(Guid id)
    {
        var agenda = await context.Agendamentos.FindAsync(id);

        if (agenda is null) return NotFound("Não foi encontrada um agendamento com esse id");

        context.Agendamentos.Remove(agenda);

        await context.SaveChangesAsync();

        return NoContent();
    }
}