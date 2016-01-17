using System;
using System.Net.Http;
using System.Net.Http.Headers;

using Library.Web.Clients.Interfaces;

namespace Library.Web.Clients
{
    /// <summary>
    /// The web api client.
    /// </summary>
    public class WebApiClient : IWebApiClient
    {
        /// <summary>
        /// The Http client.
        /// </summary>
        private readonly HttpClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiClient"/> class.
        /// </summary>
        public WebApiClient()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(UrlProvider.WebApiHost);
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <typeparam name="T">The data transfer type.</typeparam>
        /// <returns>The data transfer object.</returns>
        public T Get<T>(string url) where T : class
        {
            var result = default(T);
            var response = this.client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
                result = response.Content.ReadAsAsync<T>().Result;

            return result;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <param name="dto">The data transfer object.</param>
        /// <typeparam name="T">The data transfer type.</typeparam>
        /// <returns>The result of operation.</returns>
        public bool Create<T>(string url, T dto) where T : class
        {
            var response = this.client.PostAsJsonAsync(url, dto).Result;

            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <param name="dto">The data transfer object.</param>
        /// <typeparam name="T">The data transfer type.</typeparam>
        /// <returns>The result of operation.</returns>
        public bool Update<T>(string url, T dto) where T : class
        {
            var response = this.client.PutAsJsonAsync(url, dto).Result;

            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <returns>The result of operation.</returns>
        public bool Delete(string url)
        {
            var response = this.client.DeleteAsync(url).Result;

            return response.IsSuccessStatusCode;
        }
    }
}