using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task Initial()
        {
            var result = HackerRank.getNumberOfMovies("maze");

            Assert.AreEqual(97, result);
        }
    }

    public class HackerRank
    {
        public static int getNumberOfMovies(string substr)
        {
            /*
             * Endpoint: "https://jsonmock.hackerrank.com/api/movies/search/?Title=substr"
             */

            if (string.IsNullOrWhiteSpace(substr) || substr.Length > 20)
            {
                return 0;
            }

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://jsonmock.hackerrank.com/api/movies/search/", UriKind.Absolute);

            try
            {

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            var response = httpClient.GetAsync("?Title=" + Uri.EscapeDataString(substr)).Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var result = JsonConvert.DeserializeObject<PagedResult>(content);

            return result.TotalItems;
        }
    }

    public class PagedResult
    {
        [JsonProperty("page")]
        public int PageNumber { get; set; }

        [JsonProperty("per_page")]
        public int ItemsPerPage { get; set; }

        [JsonProperty("total")]
        public int TotalItems { get; set; }
    }
}
