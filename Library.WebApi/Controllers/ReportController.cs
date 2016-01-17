using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Library.DAL.Entities;
using Library.Dto.Dto;

namespace Library.WebApi.Controllers
{
    /// <summary>
    /// The report controller.
    /// </summary>
    public class ReportController : BaseController
    {
        /// <summary>
        /// Get reports.
        /// </summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<ReportDto> Get()
        {
            var categories = repository.Get<Category>().Include(i => i.Books);
            var books = repository.Get<Book>().Include(i => i.Categories).Where(i => !i.Categories.Any());

            var report = categories.GroupBy(i => i.Id)
                .Select(i => new ReportDto { Category = i.FirstOrDefault().Name, Amount = i.FirstOrDefault().Books.Count })
                .ToList();

            if (books.Any())
                report.Add(new ReportDto { Category = "[Unknown]", Amount = books.Count() });

            return report;
        }
    }
}
