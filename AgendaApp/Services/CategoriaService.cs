using AgendaApp.Context;
using Lib.Classes.Entities;

namespace AgendaApp.Services;

public class CategoriaService(AgendaContext context)
{
    public async Task<Categoria> FindCategoria(int id)
    {
        var categoria = await context.Categorias.FindAsync(id);

        if (categoria == null)
        {
            throw new ArgumentException("Categoria Não encontrada");
        }

        return categoria;
    }
}