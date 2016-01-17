using System.Data.Entity;
using Library.DAL.Entities;
using Library.DAL.EntityMappings;

namespace Library.DAL
{
    /// <summary>
    /// The library context.
    /// </summary>
    public class LibraryContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryContext"/> class.
        /// </summary>
        public LibraryContext()
            : base("Library")
        {
        }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Handle event ModelCreating.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMapping());
        }
    }
}
