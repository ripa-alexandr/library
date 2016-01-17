using System.Web.Mvc;

using Library.Web.Clients;
using Library.Web.Clients.Interfaces;

namespace Library.Web.Controllers
{
    /// <summary>
    /// The base controller.
    /// </summary>
    public abstract class BaseController : Controller 
    {
        /// <summary>
        /// The client.
        /// </summary>
        protected readonly IWebApiClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        protected BaseController()
        {
            this.client = new WebApiClient();
        }
	}
}