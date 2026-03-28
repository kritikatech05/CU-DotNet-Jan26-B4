using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Models;

[Route("api/[controller]")]
[ApiController]
public class TrackingController : ControllerBase
{
    [Authorize(Roles = "Manager")]
    [HttpGet("gps")]
    public IActionResult GetGps()
    {
        var data = new
        {
            TruckId = "TRK123",
            Longitude = 34.333,
            Latitude = 23.223,
            Speed = 76.54,
            TimeStamp = DateTime.Now


        };
        return Ok(data);
    }
}