using Microsoft.AspNetCore.Mvc;
namespace MedicineAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MedicineController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
           message = "Medicine API is running!" 
        });
    }
}