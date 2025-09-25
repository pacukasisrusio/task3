using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("pacukasisrusio_gmail_com")]
public class Task3Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string x, [FromQuery] string y)
    {
        int ix, iy;

        if (!int.TryParse(x, out ix) || ix < 0 ||
            !int.TryParse(y, out iy) || iy < 0)
        {
            return Content("NaN");
        }
        if (ix == 0)
        return Content(iy.ToString());

        if (iy == 0)
        return Content(ix.ToString());

        int lcm = LCM(ix, iy);
        return Content(lcm.ToString());
    }

    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    static int LCM(int a, int b)
    {
        return a / GCD(a, b) * b;
    }
}
