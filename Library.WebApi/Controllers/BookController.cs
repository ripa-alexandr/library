using System.Linq;
using System.Web.Http;

using AutoMapper;

using Library.DAL.Entities;
using Library.Dto.Dto;

namespace Library.WebApi.Controllers
{
    /// <summary>
    /// The book controller.
    /// </summary>
    public class BookController : BaseCrudController<BookDto, Book>
    {
        /// <summary>
        /// Create book.
        /// </summary>
        /// <param name="bookDto">The book data transfer object.</param>
        [HttpPost]
        public override void Create(BookDto bookDto)
        {
            var book = Mapper.Map<Book>(bookDto);

            if (bookDto.Categories != null)
                book.Categories = bookDto.Categories.Select(i => repository.Get<Category>(i.Id)).ToList();

            repository.Add(book);

            repository.Save();
        }

        /// <summary>
        /// Update book.
        /// </summary>
        /// <param name="bookDto">The book data transfer object.</param>
        [HttpPut]
        public override void Update(BookDto bookDto)
        {
            var book = repository.Get<Book>(bookDto.Id);
            book.Categories.Clear();

            if (bookDto.Categories != null)
                book.Categories = bookDto.Categories.Select(i => repository.Get<Category>(i.Id)).ToList();

            Mapper.Map(bookDto, book);

            repository.Save();
        }

        /// <summary>
        /// The delete object.
        /// </summary>
        /// <param name="id">The id.</param>
        public override void Delete(int id)
        {
            var entity = this.repository.Get<Book>(id);
            entity.Categories.Clear();
            
            repository.Delete(entity);
            repository.Save();
        }
    }
}
