using Microsoft.AspNetCore.Mvc;

namespace MyBooks.Controllers.V1
{
	[ApiVersion("1.0")]
	[ApiVersion("1.2")]
	[ApiVersion("1.9")]
	[Route("api/[controller]")]
	//[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		[HttpGet("get-test-data")]
		public IActionResult GetV1()
		{
			return Ok("this is a testController V1");
		}

		[HttpGet("get-test-data"), MapToApiVersion("1.2")]
		public IActionResult GetV12()
		{
			return Ok("this is a testController V1.2");
		}

		[HttpGet("get-test-data"), MapToApiVersion("1.9")]
		public IActionResult GetV19()
		{
			return Ok("this is a testController V1.9");
		}
	}
}
