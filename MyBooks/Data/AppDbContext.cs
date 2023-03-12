using Microsoft.EntityFrameworkCore;
using MyBooks.Data.Models;

namespace MyBooks.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		//using fluent API to configure the many to many relationship in order for entity frame work to be able to map it 

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book_Author>()
				.HasOne(b => b.Book)
				.WithMany(ba => ba.Book_Authors)
				.HasForeignKey(bi => bi.BookId);

			modelBuilder.Entity<Book_Author>()
				.HasOne(b => b.Author)
				.WithMany(ba => ba.Book_Authors)
				.HasForeignKey(bi => bi.AuthorId);

			modelBuilder.Entity<Log>().HasKey(n => n.Id);
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book_Author> Book_Authors { get; set; }
		public DbSet<Publisher> Publishers { get; set; }

		public DbSet<Log> Logs { get; set; }
	}
}
