using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.Services;
using MyBooks.Data.ViewModels;

namespace MyBooks.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private readonly AuthorsService _authorsService;
		public AuthorsController(AuthorsService authorsService)
		{
			_authorsService = authorsService;
		}

		[HttpPost("add-author")]
		public IActionResult AddAuthor([FromBody] AuthorVM author)
		{
			_authorsService.AddAuthor(author);
			return Ok();
		}

		[HttpGet("get-author-with-books-by-id/{id}")]
		public IActionResult GetAuthorWithBooks(int id)
		{
			var response = _authorsService.GetAuthorWithBooks(id);
			return Ok(response);
		}
	}
}
