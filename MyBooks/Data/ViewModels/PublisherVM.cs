using System.Collections.Generic;

namespace MyBooks.Data.ViewModels
{
	public class PublisherVM
	{
		public string Name { get; set; }
	}

	public class PublisherWithBooksAndAuthorsVM
	{
		public string Name { get; set; } //name of publisher
		public List<BookAuthorVM> BookAuthors { get; set; }

	}

	public class BookAuthorVM
	{
		public string BookName { get; set; }
		public List<string> BookAuthors { get; set; }
	}
}
