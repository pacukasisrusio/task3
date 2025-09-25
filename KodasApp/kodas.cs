using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("pacukasisrusio_gmail_com")]
public class Task3Controller : ControllerBase
{
    [HttpGet]
   public IActionResult Get([FromQuery] string? x, [FromQuery] string? y)

    {
        ulong ux, uy;

        if (!ulong.TryParse(x, out ux) || ux == 0 ||
            !ulong.TryParse(y, out uy) || uy == 0)
        {
            return Content("NaN");
        }

        ulong lcm = LCM(ux, uy);
        return Content(lcm.ToString());
    }

    static ulong GCD(ulong a, ulong b)

    {
        while (b != 0)
        {
            ulong t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    static ulong LCM(ulong a, ulong b)

    {
        return a / GCD(a, b) * b;
    }
}
