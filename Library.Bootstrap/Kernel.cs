using Ninject;

namespace Library.Bootstrap
{
    /// <summary>
    /// The kernel.
    /// </summary>
    public static class Kernel
    {
        /// <summary>
        /// The initialize ninject.
        /// </summary>
        /// <returns>The <see cref="StandardKernel"/>.</returns>
        public static StandardKernel Initialize()
        {
            return new StandardKernel(new LibraryModule());
        }
    }
}
