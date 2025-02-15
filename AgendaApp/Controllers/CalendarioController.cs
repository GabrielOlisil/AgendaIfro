using AgendaApp.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.Controllers;

[ApiController]
[Route("[controller]")]
public class CalendarioController (AgendaContext context) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<List<bool>>> AulasNoDia([FromBody]DateTime day)
    {

        var intervalos = context.Intervalos.Count();

        var list = new List<bool>();

        for (var i = 0; i < intervalos; i++)
        {
            list.Add(false);
        }
        
        
        
        var aula = await context.Agendamentos.Where(a => a.Dia == day)
            .Include(a => a.Intervalo)
            .ToListAsync();

        if (aula.Count == 0)
        {
            return list;
        }
        
        foreach (var item in aula)
        {
            list[item.Intervalo.IndexAula] = true;
        }

        return list;
    }
}