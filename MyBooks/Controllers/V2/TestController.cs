using Microsoft.AspNetCore.Mvc;

namespace MyBooks.Controllers.V2
{

	[ApiVersion("2.0")]
	[Route("api/[controller]")]
	//[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		[HttpGet("get-test-data")]
		public IActionResult Get()
		{
			return Ok("This is testController V2");
		}
	}
}



