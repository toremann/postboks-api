using Microsoft.AspNetCore.Mvc;

namespace PostboksApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostboksController : ControllerBase
    {
        private readonly Postboks _postboks;

        public PostboksController(Postboks postboks)
        {
            _postboks = postboks;
        }

        [HttpGet("{postboksNumber}")]
        public ActionResult<string> GetCity(string postboksNumber)
        {
            string city = _postboks.GetCity(postboksNumber);
            if (city == "City not found")
            {
                return NotFound();
            }
            else
            {
                return Ok(city);
            }
        }
    }
}
