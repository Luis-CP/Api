using Microsoft.AspNetCore.Mvc;

namespace apicon_net.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PacientesController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<PacientesController> _logger;

    private static List<Pacientes> ListPacientes = new List<Pacientes>();

    public PacientesController(ILogger<PacientesController> logger)
    {
        _logger = logger;

        if(ListPacientes == null || !ListPacientes.Any())
        {
             ListPacientes= Enumerable.Range(1, 5).Select(index => new Pacientes
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList();
        }
    }

    [HttpGet(Name = "GetPacientes")]

    //[Route("get/Pacientes")]//la opccion route sirve para poder multiples enrutamientos a funciones do pedidos http
    public IEnumerable<Pacientes> Get()
    {
        _logger.LogDebug("Se ingreso Obtuvo correctamente los datos");
       return ListPacientes;
    }

    [HttpPost] 
    public IActionResult Post(Pacientes pacientes)
    {
        ListPacientes.Add(pacientes);
        
        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        ListPacientes.RemoveAt(index);

        return Ok();
    }
}