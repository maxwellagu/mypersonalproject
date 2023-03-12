using MyBooks.Data.Models;
using System;

namespace MyBooks.Data.ViewModels
{
	public class CustomActionResultVM
	{
		public Exception Exception { get; set; }
		public Publisher Publisher { get; set; }
	}
}
