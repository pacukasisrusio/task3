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
        int minValue = 0;

        if (!int.TryParse(x, out ix) || ix <= minValue ||
            !int.TryParse(y, out iy) || iy <= minValue)
        {
            return Content("NaN");
        }

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
