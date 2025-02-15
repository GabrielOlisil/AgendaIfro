using AgendaApp.Context;
using AgendaApp.Services;
using static AgendaApp.Services.IntervaloService;
using Lib.Classes.Dtos.Intervalo;
using Lib.Classes.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace AgendaApp.Controllers;

[ApiController]
[Route("[controller]")]
public class IntervalosController(AgendaContext context, IntervaloService intervaloService) : ControllerBase
{
   

    [HttpGet("{id}")]
    public async Task<ActionResult<Intervalo>> GetIntervaloById(Guid id)
    {
        Intervalo? intervalo = null;
        try
        {
            intervalo = await intervaloService.FindIntervalo(id);
        }
        catch (Exception e)
        {
            return NotFound();
        }

        return intervalo;
    }

    [HttpGet]
    public async Task<List<Intervalo>> ListIntervalos()
    {
        var data = context.Intervalos.OrderBy(i => i.IndexAula).ToListAsync();

        return await data;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Intervalo>> CreateIntervalo(IntervaloCreateDto intervaloRequest)
    {
        var intervalo = new Intervalo()
        {
            Id = Guid.Empty,
            Label = intervaloRequest.Label,
            Comeco = intervaloRequest.Comeco,
        };

        context.Intervalos.Add(intervalo);


        try
        {
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return BadRequest("Dados enviados da forma errada");
        }

        return CreatedAtAction(nameof(GetIntervaloById), new { id = intervalo.Id }, intervalo);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<Intervalo>> UpdateIntervalo(Guid id, IntervaloUpdateDto intervaloUpdateDto)
    {

        var intervalo = await context.Intervalos.FindAsync(id);

        if (intervalo is null) return NotFound();
        
        if (intervaloUpdateDto.Label is not null)
        {
            intervalo.Label = intervaloUpdateDto.Label;
        }
        
        if (intervaloUpdateDto.Comeco is not null)
        {
            intervalo.Comeco = intervaloUpdateDto.Comeco;
        }
        
     
        context.Intervalos.Update(intervalo);

        
        var changes = context.Entry(intervalo).State == EntityState.Modified;

        if (changes)
        {
            await context.SaveChangesAsync();
        }

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIntervalo(Guid id)
    {
        var intervalo = await context.Intervalos.FindAsync(id);

        if (intervalo is null) return NotFound();

        context.Intervalos.Remove(intervalo);

        await context.SaveChangesAsync();

        return NoContent();
    }
}