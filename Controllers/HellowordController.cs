using Microsoft.AspNetCore.Mvc;

namespace proyectoef.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HellowordController : ControllerBase
{
    IHelloWorldService helloWorldService;

    TareasContext dbcontext;
     public HellowordController(IHelloWorldService helloWorld,TareasContext db)
     {
        helloWorldService = helloWorld;
        dbcontext = db;
     }

   [HttpGet]
     public IActionResult Get()
     {
        return Ok(helloWorldService.GetHelloWorld());
     }

     [HttpGet]
      [Route("createdb")]
     public IActionResult CreatDatabase()
     {
         dbcontext.Database.EnsureCreated();
         return Ok();
     }
}