using System.Collections.Generic;

using Library.Dto.Api;

namespace Library.Dto.Dto
{
    /// <summary>
    /// The book data transfer object.
    /// </summary>
    public class BookDto : IBaseDto
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
        public ICollection<CategoryDto> Categories { get; set; }
    }
}
