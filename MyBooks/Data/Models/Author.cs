using System.Collections.Generic;

namespace MyBooks.Data.Models
{
	public class Author
	{
		public int Id { get; set; }
		public string FullName { get; set; }

		//Navigation property
		//we need to add a join model
		public List<Book_Author> Book_Authors { get; set; }
	}
}
