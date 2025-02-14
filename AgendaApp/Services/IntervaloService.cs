using System.Data;
using AgendaApp.Context;
using Lib.Classes.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.Services;

public class IntervaloService(AgendaContext context)
{
    
    public async Task<Intervalo> FindIntervalo(Guid id)
    {
        var intervalo = await context.Intervalos.FindAsync(id);

        if (intervalo == null)
        {
            throw new ArgumentException("Intervalo Não encontrado");
        }

        return intervalo;
    }

}