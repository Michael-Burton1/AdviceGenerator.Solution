using System.Threading.Tasks;
using RestSharp;

namespace AdviceGenerator.Models
{
  class ApiHelper
  {
    public static async Task<string> ApiCall()
    {
      RestClient client = new RestClient("https://quotes.rest");
      RestRequest request = new RestRequest($"quote/random.json?api_key={EnvironmentVariables.ApiKeyQuote}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> ApiSearchCall(string searchTerm)
    {
      RestClient client = new RestClient($"https://quotes.rest");
      RestRequest request = new RestRequest($"quote/search?minlength=100&maxlength=300&query={searchTerm}&private=false&language=en&limit=1&sfw=false&api_key={EnvironmentVariables.ApiKeyQuote}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}