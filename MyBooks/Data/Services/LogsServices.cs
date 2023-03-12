using MyBooks.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyBooks.Data.Services
{
	public class LogsServices
	{
		private AppDbContext _context;
		public LogsServices(AppDbContext context)
		{
			_context = context;
		}

		public List<Log> GetAllLogsFromDB() => _context.Logs.ToList();

	}
}
