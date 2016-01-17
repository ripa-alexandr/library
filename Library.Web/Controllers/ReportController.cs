using System.Collections.Generic;
using System.Web.Mvc;

using AutoMapper;

using Library.Dto.Dto;
using Library.Web.Clients;
using Library.Web.ViewModel;

namespace Library.Web.Controllers
{
    /// <summary>
    /// The report controller.
    /// </summary>
    [Authorize]
    public class ReportController : BaseController
    {
        /// <summary>
        /// Return page with report.
        /// </summary>
        public ActionResult Index()
        {
            var reportsDto = this.client.Get<IEnumerable<ReportDto>>(UrlProvider.WebApiReport);
            var reportsViewModel = Mapper.Map<IEnumerable<ReportDto>, IEnumerable<ReportViewModel>>(reportsDto);

            return View(reportsViewModel);
        }
	}
}