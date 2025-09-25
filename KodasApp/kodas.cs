using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("pacukasisrusio_gmail_com")]
public class Task3Controller : ControllerBase
{
    [HttpGet]
   public IActionResult Get([FromQuery] string? x, [FromQuery] string? y)

    {
        if (string.IsNullOrWhiteSpace(x) || string.IsNullOrWhiteSpace(y))
        {
            return Content("NaN");
        }
        if (!ulong.TryParse(x, out ulong ix) || ix == 0 ||
            !ulong.TryParse(y, out ulong iy) || iy == 0)
        {
            return Content("NaN");
        }

        int lcm = LCM(ix, iy);
        return Content(lcm.ToString());
    }

    static ulong GCD(ulong a, ulong b)

    {
        while (b != 0)
        {
            int t = b;
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
