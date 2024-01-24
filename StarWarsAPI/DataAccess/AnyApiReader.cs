using System;
namespace StarWarsAPI
{
    /// <summary>
    /// Represents a class that reads data from any API.
    /// </summary>
    public class AnyApiReader : IAnyApiReader
    {
        /// <summary>
        /// Reads data from the specified API.
        /// </summary>
        /// <param name="baseUrl">The base URL of the API.</param>
        /// <param name="requestApi">The API endpoint to request data from.</param>
        /// <returns>The content retrieved from the API.</returns>
        public async Task<string> Read(string baseUrl, string requestApi)
        {
            using var client = new HttpClient();

            client.BaseAddress = new Uri(baseUrl);

            var response = await client.GetAsync(requestApi);

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();

            return content;

        }
    }
}

