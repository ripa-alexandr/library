using System.Data.Entity.ModelConfiguration;
using Library.DAL.Entities;

namespace Library.DAL.EntityMappings
{
    /// <summary>
    /// The category mapping.
    /// </summary>
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryMapping"/> class.
        /// </summary>
        public CategoryMapping()
        {
            this.HasMany(c => c.Books)
                .WithMany(p => p.Categories)
                .Map(m =>
                {
                    m.ToTable("BooksCategories");
                    m.MapLeftKey("CategoryId");
                    m.MapRightKey("BookId");
                });
        }
    }
}
