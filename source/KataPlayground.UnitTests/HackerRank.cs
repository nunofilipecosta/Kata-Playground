using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace KataPlayground.UnitTests
{
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
            var response = httpClient.GetStringAsync("?Title="+ Uri.EscapeDataString(substr)).GetAwaiter().GetResult();
            //response.EnsureSuccessStatusCode();
            //var content = response.Content.ToString();

            var result = JsonConvert.DeserializeObject<PagedResult>(response);

            return result.TotalItems;
        }
    }

    public class HackerRankTests
    {
        [Fact]
        public async Task Initial()
        {
            var result =  HackerRank.getNumberOfMovies("maze");

            Assert.Equal(97, result);
        }

        [Fact]
        public async Task Initial2()
        {
            var result =  HackerRank.getNumberOfMovies("harry");

            Assert.Equal(573, result);
        }

        [Fact]
        public async Task MovieName_Null()
        {
            var result =  HackerRank.getNumberOfMovies(null);

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task MovieName_EmptyOrWhiteSpace()
        {
            var result =  HackerRank.getNumberOfMovies(string.Empty);

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task MovieName_Over20()
        {
            var result =  HackerRank.getNumberOfMovies("mazedasd dasd asdas da das das");

            Assert.Equal(0, result);
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
