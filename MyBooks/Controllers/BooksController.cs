using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.Services;
using MyBooks.Data.ViewModels;

namespace MyBooks.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		public readonly BooksService _bookService;
		public BooksController(BooksService bookService)
		{
			_bookService = bookService;
		}

		[HttpGet("get-all-books")]
		public IActionResult GetAllBooks()
		{
			var allBooks = _bookService.GetAllBooks();
			return Ok(allBooks);
		}

		[HttpGet("get-book-by-books/{id}")]
		public IActionResult GetBooksById(int id)
		{
			var book = _bookService.GetBooksById(id);
			return Ok(book);
		}

		[HttpPost("add-books-with-authors")]
		public IActionResult AddBooks([FromBody] BookVM books)
		{
			_bookService.AddBooksWithAuthors(books);
			return Ok();
		}

		[HttpPut("update-book-by-id/{id}")]
		public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
		{
			var updateBook = _bookService.UpdateBookById(id, book);
			return Ok(updateBook);
		}

		[HttpDelete("delete-book-by-id/{id}")]
		public IActionResult DeleteBookById(int id)
		{
			_bookService.DeleteBookById(id);
			return Ok();
		}

	}
}
