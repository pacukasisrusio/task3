using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;

[ApiController]
[Route("pacukasisrusio_gmail_com")]
public class Task3Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string x, [FromQuery] string y)
    {

        if (!BigInteger.TryParse(x, out BigInteger ix) || ix < 0 ||
            !BigInteger.TryParse(y, out BigInteger iy) || iy < 0)
        {
            return Content("NaN");
        }
        if (ix == 0)
        return Content(iy.ToString());

        if (iy == 0)
        return Content(ix.ToString());

        BigInteger lcm = LCM(ix, iy);
        return Content(lcm.ToString());
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
