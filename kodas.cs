using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("pacukasisrusio_gmail_com")]
public class Task3Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string x, [FromQuery] string y){
        int x, y, a=0;
        if (!int.TryParse(xInput, out x) || x <= a ||
            !int.TryParse(yInput, out y) || y <= a)
        {
            Console.WriteLine("NaN");
            return;
        }
        int lcm = LCM(x, y);
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