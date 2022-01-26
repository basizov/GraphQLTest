using Microsoft.AspNetCore.Mvc;

namespace CommanderGQL.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
  [HttpGet]
  public ActionResult<string> GetTest() => Ok("Test");
}
