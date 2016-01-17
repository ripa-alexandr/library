using System;
using System.Collections.Generic;
using System.Web.Mvc;

using AutoMapper;

using Library.Dto.Dto;
using Library.Web.Clients;
using Library.Web.ViewModel;

namespace Library.Web.Controllers
{
    /// <summary>
    /// The category controller.
    /// </summary>
    [Authorize]
    public class CategoryController : BaseController
    {
        /// <summary>
        /// Return page with categories.
        /// </summary>
        public ActionResult Index()
        {
            var categoriesDto = this.client.Get<IEnumerable<CategoryDto>>(UrlProvider.WebApiCategory);
            var categoriesViewModel = Mapper.Map<IEnumerable<CategoryDto>, IEnumerable<CategoryViewModel>>(categoriesDto);

            return View(categoriesViewModel);
        }

        /// <summary>
        /// Return page for category details.
        /// </summary>
        public ActionResult Details(int id)
        {
            var categoryDto = this.client.Get<CategoryDto>(UrlProvider.WebApiCategory + id);
            var categoryViewModel = Mapper.Map<CategoryDto, CategoryViewModel>(categoryDto);

            return View(categoryViewModel);
        }

        /// <summary>
        /// Return page for create category.
        /// </summary>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create category.
        /// </summary>
        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
                return this.View(categoryViewModel);

            categoryViewModel.CreationDate = DateTime.UtcNow;
            var categoryDto = Mapper.Map<CategoryViewModel, CategoryDto>(categoryViewModel);
            this.client.Create(UrlProvider.WebApiCategory, categoryDto);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Return page for edit category.
        /// </summary>
        public ActionResult Edit(int id)
        {
            var categoryDtoDto = this.client.Get<CategoryDto>(UrlProvider.WebApiCategory + id);
            var categoryViewModel = Mapper.Map<CategoryDto, CategoryViewModel>(categoryDtoDto);

            return View(categoryViewModel);
        }

        /// <summary>
        /// Edit category.
        /// </summary>
        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
                return this.View(categoryViewModel);

            var categoryDto = Mapper.Map<CategoryViewModel, CategoryDto>(categoryViewModel);
            this.client.Update(UrlProvider.WebApiCategory, categoryDto);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Return page for delete category.
        /// </summary>
        public ActionResult Delete(int id)
        {
            var categoryDto = this.client.Get<CategoryDto>(UrlProvider.WebApiCategory + id);
            var categoryViewModel = Mapper.Map<CategoryDto, CategoryViewModel>(categoryDto);

            return View(categoryViewModel);
        }

        /// <summary>
        /// Delete category.
        /// </summary>
        [HttpPost]
        public ActionResult Delete(CategoryViewModel categoryViewModel)
        {
            this.client.Delete(UrlProvider.WebApiCategory + categoryViewModel.Id);

            return RedirectToAction("Index");
        }
    }
}
