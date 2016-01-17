using System.Web.Http;
using Library.Bootstrap;
using Library.DAL.Api;
using Ninject;

namespace Library.WebApi.Controllers
{
    /// <summary>
    /// The base controller.
    /// </summary>
    public abstract class BaseController : ApiController
    {
        /// <summary>
        /// The repository instance.
        /// </summary>
        protected readonly IRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        protected BaseController()
        {
            var ninject = Kernel.Initialize();

            this.repository = ninject.Get<IRepository>();
        }
    }
}
