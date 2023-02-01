using Microsoft.AspNetCore.Mvc;
using proyectoef.Models;
using proyectoef.Services;

namespace proyectoef.Controllers;

[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    ICategoriaService categoriaService;

    public CategoriaController(ICategoriaService service)
    {
        categoriaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoriaService.Get());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Categoria categoriaAdd)
    {
        var categoria = new Categoria()
        {
            Nombre = categoriaAdd.Nombre,
            Descripcion = categoriaAdd.Descripcion,
            Peso = categoriaAdd.Peso
        };
    await categoriaService.Save(categoria);
    return NoContent();
    }

    [HttpPut ("{id}")]
    public async Task <IActionResult> Put(Guid id,[FromBody] Categoria categoria)
    {
        await categoriaService.Update(id,categoria);
        return Ok();
    }

    [HttpDelete ("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoriaService.Delete(id);
        return Ok();
    }
}