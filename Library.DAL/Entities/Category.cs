using System;
using System.Collections.Generic;
using Library.DAL.Api;

namespace Library.DAL.Entities
{
    /// <summary>
    /// The category.
    /// </summary>
    public class Category : IBaseEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        public virtual ICollection<Book> Books { get; set; }
    }
}
