using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using AutoMapper;

using Library.Dto.Dto;
using Library.Web.Clients;
using Library.Web.ViewModel;

namespace Library.Web.Controllers
{
    /// <summary>
    /// The book controller.
    /// </summary>
    [Authorize]
    public class BookController : BaseController
    {
        /// <summary>
        /// Return page with books.
        /// </summary>
        public ActionResult Index()
        {
            var booksDto = this.client.Get<IEnumerable<BookDto>>(UrlProvider.WebApiBook);
            var booksViewModel = Mapper.Map<IEnumerable<BookDto>, IEnumerable<BookViewModel>>(booksDto);

            return View(booksViewModel);
        }

        /// <summary>
        /// Return page for book details.
        /// </summary>
        public ActionResult Details(int id)
        {
            var booksDto = this.client.Get<BookDto>(UrlProvider.WebApiBook + id);
            var booksViewModel = Mapper.Map<BookDto, BookViewModel>(booksDto);

            return View(booksViewModel);
        }

        /// <summary>
        /// Return page for create book.
        /// </summary>
        public ActionResult Create()
        {
            var bookViewModel = new BookViewModel();

            InitializeViewModel(bookViewModel);

            return View(bookViewModel);
        }

        /// <summary>
        /// Create book.
        /// </summary>
        [HttpPost]
        public ActionResult Create(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                InitializeViewModel(bookViewModel);

                return this.View(bookViewModel);
            }

            var bookDto = Mapper.Map<BookViewModel, BookDto>(bookViewModel);
            this.client.Create(UrlProvider.WebApiBook, bookDto);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Return page for edit book.
        /// </summary>
        public ActionResult Edit(int id)
        {
            var bookDto = this.client.Get<BookDto>(UrlProvider.WebApiBook + id);
            var bookViewModel = Mapper.Map<BookDto, BookViewModel>(bookDto);

            InitializeViewModel(bookViewModel);

            return View(bookViewModel);
        }

        /// <summary>
        /// Edit book.
        /// </summary>
        [HttpPost]
        public ActionResult Edit(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                InitializeViewModel(bookViewModel);

                return this.View(bookViewModel);
            }

            var bookDto = Mapper.Map<BookViewModel, BookDto>(bookViewModel);
            this.client.Update(UrlProvider.WebApiBook, bookDto);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Return page for delete book.
        /// </summary>
        public ActionResult Delete(int id)
        {
            var bookDto = this.client.Get<BookDto>(UrlProvider.WebApiBook + id);
            var bookViewModel = Mapper.Map<BookDto, BookViewModel>(bookDto);

            return View(bookViewModel);
        }

        /// <summary>
        /// Delete book.
        /// </summary>
        [HttpPost]
        public ActionResult Delete(BookViewModel bookViewModel)
        {
            this.client.Delete(UrlProvider.WebApiBook + bookViewModel.Id);

            return RedirectToAction("Index");
        }

        private void InitializeViewModel(BookViewModel bookViewModel)
        {
            var categoriesDto = this.client.Get<IEnumerable<CategoryDto>>(UrlProvider.WebApiCategory);
            var categoriesViewModel = Mapper.Map<IEnumerable<CategoryDto>, IEnumerable<CategoryViewModel>>(categoriesDto);

            bookViewModel.AllCategories = categoriesViewModel
                .Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString() })
                .ToList();
        }
    }
}
