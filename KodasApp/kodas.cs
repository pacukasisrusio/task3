using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;

[ApiController]
[Route("pacukasisrusio_gmail_com")]
public class Task3Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string? x, [FromQuery] string? y)
    {
        bool xValid = BigInteger.TryParse(x, out BigInteger ix) && ix >= 0;
        bool yValid = BigInteger.TryParse(y, out BigInteger iy) && iy >= 0;

        if (!xValid || !yValid)
            return Content("NaN");

        if (ix.IsZero)
            return Content(iy.ToString(), "Nan");

        if (iy.IsZero)
            return Content(ix.ToString(), "NaN");

        BigInteger lcm = LCM(ix, iy);
        return Content(lcm.ToString(), "NaN");
    }

    static BigInteger GCD(BigInteger a, BigInteger b)
    {
        while (b != 0)
        {
            BigInteger t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    static BigInteger LCM(BigInteger a, BigInteger b)
    {
        return a / GCD(a, b) * b;
    }
}
