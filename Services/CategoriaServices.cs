using proyectoef.Models;

namespace proyectoef.Services;

public class CategoriaService
{
    TareasContext context;

    public CategoriaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }

    public async Task Save(Categoria categoria)
    {
        context.Add(categoria); 
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id,Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);

        context.Add(categoria); 
        await context.SaveChangesAsync();
    }
}

public interface ICategoriaService{

}