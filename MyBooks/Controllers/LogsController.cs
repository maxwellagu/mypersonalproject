using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.Services;
using System;

namespace MyBooks.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LogsController : ControllerBase
	{
		private readonly LogsServices _logsService;
		public LogsController(LogsServices logsService)
		{
			_logsService = logsService;
		}

		[HttpGet("get-all-logs-from-db")]
		public IActionResult GetAllLogsFromDB()
		{
			try
			{
				var allLogs = _logsService.GetAllLogsFromDB();
				return Ok(allLogs);
			}
			catch (Exception)
			{
				return BadRequest("Could not load logs from the dataBase");
			}
		}
	}
}
