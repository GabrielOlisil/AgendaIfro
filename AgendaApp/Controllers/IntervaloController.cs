using AgendaApp.Context;
using AgendaApp.Dtos;
using AgendaApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.Controllers;

[ApiController]
[Route("[controller]")]
public class IntervaloController(AgendaContext context): ControllerBase
{
    
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Intervalo>> Create(IntervaloCreateDTO intervaloCreateDto)
    {
        var intervalo = new Intervalo()
        {
            Id = Guid.Empty,
            Comeco = intervaloCreateDto.Comeco,
            Fim = intervaloCreateDto.Fim
        };
        
        context.Intervalos.Add(intervalo);

        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetIntervaloById), new { id = intervalo.Id }, intervalo);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Intervalo>> GetIntervaloById(Guid id)
    {
        var intervalo = await context.Intervalos.FindAsync(id);

        if (intervalo == null)
        {
            return NotFound();
        }

        return intervalo;
    }
    
    [HttpGet]
    public  ActionResult<string> Intervalo()
    {

        return Ok("Server Running");
    }
}