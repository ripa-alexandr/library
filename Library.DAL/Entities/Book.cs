using System.Collections.Generic;
using Library.DAL.Api;

namespace Library.DAL.Entities
{
    /// <summary>
    /// The book.
    /// </summary>
    public class Book : IBaseEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the author of book.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the book name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the isbn of book.
        /// </summary>
        public string Isbn { get; set; }

        /// <summary>
        /// Gets or sets the categories for book.
        /// </summary>
        public virtual ICollection<Category> Categories { get; set; }
    }
}
