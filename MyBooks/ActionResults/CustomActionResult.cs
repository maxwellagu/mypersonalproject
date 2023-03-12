using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.ViewModels;
using System.Threading.Tasks;

namespace MyBooks.ActionResults
{
	public class CustomActionResult : IActionResult
	{
		//creating a custom actionResult
		private readonly CustomActionResultVM _result;

		public CustomActionResult(CustomActionResultVM result)
		{
			_result = result;
		}

		public async Task ExecuteResultAsync(ActionContext context)
		{
			var objectResult = new ObjectResult(_result.Exception ?? _result.Publisher as object)
			{
				StatusCode = _result.Exception != null ? StatusCodes.Status500InternalServerError :
				StatusCodes.Status200OK
			};

			await objectResult.ExecuteResultAsync(context);
		}
	}
}
