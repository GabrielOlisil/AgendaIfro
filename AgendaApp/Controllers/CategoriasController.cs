using AgendaApp.Context;
using AgendaApp.Services;
using Lib.Classes.Dtos.Categoria;
using Lib.Classes.Dtos.Intervalo;
using Lib.Classes.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace AgendaApp.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriasController(AgendaContext context, CategoriaService categoriaService) : ControllerBase
{
   

    [HttpGet("{id}")]
    public async Task<ActionResult<Categoria>> GetCategoriaById(int id)
    {
        Categoria? categoria = null;

        try
        {
            categoria = await categoriaService.FindCategoria(id);
        }
        catch (Exception e)
        {
            return NotFound();
        }

        return categoria;
    }

    [HttpGet]
    public async Task<List<Categoria>> ListCategoria()
    {
        var data = context.Categorias.ToListAsync();

        return await data;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Categoria>> CreateCategoria(CategoriaCreateDto CategoriaRequest)
    {
        var categoria = new Categoria()
        {
            Label = CategoriaRequest.Label!,
        };

        context.Categorias.Add(categoria);
        
  

        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCategoriaById), new { id = categoria.Id }, categoria);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<Categoria>> UpdateCategoria(int id, CategoriaUpdateDto categoriaUpdateDto)
    {

        var categoria = await context.Categorias.FindAsync(id);

        if (categoria is null) return NotFound();
        
        if (categoriaUpdateDto.Label is not null)
        {
            categoria.Label = categoriaUpdateDto.Label;
        }

        context.Categorias.Update(categoria);

        
        var changes = context.Entry(categoria).State == EntityState.Modified;

        if (changes)
        {
            await context.SaveChangesAsync();
        }

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoria(int id)
    {
        var categoria = await context.Categorias.FindAsync(id);

        if (categoria is null) return NotFound();

        context.Categorias.Remove(categoria);

        await context.SaveChangesAsync();

        return NoContent();
    }
}