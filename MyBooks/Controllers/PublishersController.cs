using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBooks.Data.Services;
using MyBooks.Data.ViewModels;
using MyBooks.Exceptions;
using System;

namespace MyBooks.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PublishersController : ControllerBase
	{
		private readonly PublishersService _publishersService;
		private readonly ILogger<PublishersController> _logger;
		public PublishersController(PublishersService publishersService, ILogger<PublishersController> logger)
		{
			_publishersService = publishersService;
			_logger = logger;
		}

		[HttpGet("get-all-publishers")]
		public IActionResult GetAllPublishers(string sortBy, string searchString, int pageNumber)
		{
			//_logger.LogInformation("This is just a log in GetAllPublisher()");


			try
			{
				var _result = _publishersService.GetAllPublishers(sortBy, searchString, pageNumber);
				return Ok(_result);
			}
			catch (Exception)
			{
				return BadRequest("sorry, we could not load the publisher");
			}
		}


		[HttpPost("add-publisher")]
		public IActionResult AddPublisher([FromBody] PublisherVM publisher)
		{
			try
			{
				var newPublisher = _publishersService.AddPublisher(publisher);
				return Created(nameof(AddPublisher), newPublisher);
			}
			catch (PublisherNameException ex)
			{
				return BadRequest($"{ex.Message}, publisher name: {ex.PublisherName}");
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpGet("get-publisher-by-id/{id}")]
		public IActionResult GetPublisherById(int id)
		{

			var _response = _publishersService.GetPublisherById(id);
			if (_response != null)
			{
				return Ok(_response);
				//return _response;
				/*var _responseObject = new CustomActionResultVM()
				{
					Publisher = _response
				};
				return new CustomActionResult(_responseObject);*/
			}
			else
			{
				return NotFound();
				/*var _responseObject = new CustomActionResultVM()
				{
					Exception = new Exception("This exception is coming from the custom exception")
				};

				return new CustomActionResult(_responseObject);*/
			}
		}

		[HttpGet("get-publisher-books-with-authors/{id}")]
		public IActionResult GetPublisherData(int id)
		{
			var response = _publishersService.GetPublisherData(id);
			return Ok(response);
		}

		[HttpDelete("delete-publisher-id/{id}")]
		public IActionResult DeletePublisherById(int id)
		{
			try
			{


				_publishersService.DeletePublisherById(id);
				return Ok();
			}

			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

	}
}
