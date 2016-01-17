using System.Data.Entity;
using Library.DAL;
using Library.DAL.Api;
using Library.DAL.Repositories;
using Ninject.Modules;

namespace Library.Bootstrap
{
    /// <summary>
    /// The library module for Ninject.
    /// </summary>
    public class LibraryModule : NinjectModule
    {
        /// <summary>
        /// Register initialization.
        /// </summary>
        public override void Load()
        {
            this.InitializeRepositories();
        }

        /// <summary>
        /// Initialize repositories.
        /// </summary>
        private void InitializeRepositories()
        {
            Bind<DbContext>().To<LibraryContext>();
            Bind<IRepository>().To<Repository>();
        }
    }
}
