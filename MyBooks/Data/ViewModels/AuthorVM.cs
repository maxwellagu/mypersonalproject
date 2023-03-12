using System.Collections.Generic;

namespace MyBooks.Data.ViewModels
{
	public class AuthorVM
	{
		public string FullName { get; set; }
	}

	//to get the list of books an author wrote
	public class AuthorWithBooksVM
	{
		public string FullName { get; set; }

		public List<string> BookTitle { get; set; }
	}

}
