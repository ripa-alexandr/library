using System;

using Library.Dto.Api;

namespace Library.Dto.Dto
{
    /// <summary>
    /// The category data transfer object.
    /// </summary>
    public class CategoryDto : IBaseDto
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
    }
}
