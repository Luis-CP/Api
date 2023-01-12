using Microsoft.AspNetCore.Mvc;

namespace apicon_net.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HellowordController : ControllerBase
{
    IHelloWorldService helloWorldService;
     public HellowordController(IHelloWorldService helloWorld)
     {
        helloWorldService = helloWorld;
     }

     public IActionResult Get()
     {
        return Ok(helloWorldService.GetHelloWorld());
     }
}