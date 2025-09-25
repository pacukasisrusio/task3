using Microsoft.AspNetCore.Mvc;
using System.Numerics;

[ApiController]
[Route("pacukasisrusio_gmail_com")]
public class Task3Controller : ControllerBase
{
    [HttpGet]
   public IActionResult Get([FromQuery] string? x, [FromQuery] string? y)

    {
        BigInteger bx;
        BigInteger by;

        if (!BigInteger.TryParse(x, out bx) || bx <= 0 ||
            !BigInteger.TryParse(y, out by) || by <= 0)
        {
            return Content("NaN");
        }

        BigInteger lcm = LCM(bx, by);
        return Content(lcm.ToString());
    }

    static BigInteger GCD(BigInteger a, BigInteger b)

    {
        while (b != 0)
        {
            ulong t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    static BigInteger LCM(BigInteger a, BigInteger b)

    {
        return a/GCD(a,b)*b;
    }
}
