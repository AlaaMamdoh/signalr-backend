using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controllers.classes;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var three = new threeDTO
            {
                p1 = 1,
                p2 = 2,
                p3 = 3
            };
            DTOConverter converter = new DTOConverter();
            var x = converter.converter(three);
            return Ok(x);
        }
    }
}
