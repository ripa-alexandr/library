namespace Library.Web.Clients.Interfaces
{
    /// <summary>
    /// The WebApiClient interface.
    /// </summary>
    public interface IWebApiClient
    {
        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <typeparam name="T">The data transfer type.</typeparam>
        /// <returns>The data transfer object.</returns>
        T Get<T>(string url) where T : class;

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <param name="dto">The data transfer object.</param>
        /// <typeparam name="T">The data transfer type.</typeparam>
        /// <returns>The result of operation.</returns>
        bool Create<T>(string url, T dto) where T : class;

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <param name="dto">The data transfer object.</param>
        /// <typeparam name="T">The data transfer type.</typeparam>
        /// <returns>The result of operation.</returns>
        bool Update<T>(string url, T dto) where T : class;

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <returns>The result of operation.</returns>
        bool Delete(string url);
    }
}