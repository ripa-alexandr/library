namespace Library.Dto.Dto
{
    /// <summary>
    /// The report data transfer object.
    /// </summary>
    public class ReportDto
    {
        /// <summary>
        /// Gets or sets the book category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the amount books in the category.
        /// </summary>
        public int Amount { get; set; }
    }
}
