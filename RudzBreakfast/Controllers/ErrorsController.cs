using Microsoft.AspNetCore.Mvc;

namespace RudzBreakfast.Controllers;

public class ErrorsControoler : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }

}