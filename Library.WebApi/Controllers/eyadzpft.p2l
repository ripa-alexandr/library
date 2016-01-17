using Library.DAL.Entities;
using Library.Dto.Dto;

namespace Library.WebApi.Controllers
{
    /// <summary>
    /// The category controller.
    /// </summary>
    public class CategoryController : BaseCrudController<CategoryDto, Category>
    {
        /// <summary>
        /// The delete object.
        /// </summary>
        /// <param name="id">The id.</param>
        public override void Delete(int id)
        {
            var category = this.repository.Get<Category>(id);
            category.Books.Clear();

            repository.Delete(category);
            repository.Save();
        }
    }
}
