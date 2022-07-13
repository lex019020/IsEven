using System.Diagnostics;
using IsEven.Services;
using Microsoft.AspNetCore.Mvc;

namespace IsEven.Controllers;

[ApiController]
[Route("[controller]")]
public class IsEvenController : ControllerBase
{
    private readonly ILogger<IsEvenController> _logger;
    private readonly IEvenCalculator _evenCalculator;

    public IsEvenController(ILogger<IsEvenController> logger, IEvenCalculator evenCalculator)
    {
        _logger = logger;
        _evenCalculator = evenCalculator;
    }

    [HttpGet]
    public async Task<bool> Get(int number)
    {
        var sw = Stopwatch.StartNew();
        var result = await _evenCalculator.IsEven(number);
        sw.Stop();
        _logger.LogInformation("Request: {number} from IP: {ip}, time elapsed: {time}", 
            number, 
            HttpContext.Connection.RemoteIpAddress,
            sw.Elapsed);

        return result;
    }
}