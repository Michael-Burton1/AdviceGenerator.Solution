using System.Threading.Tasks;
using RestSharp;

namespace AdviceGenerator.Models
{
  class ApiHelper
  {
    public static async Task<string> ApiRandomCall(string apiKey)
    {
      RestClient client = new RestClient("https://quotes.rest/quote/");
      RestRequest request = new RestRequest($"random.json?api-key={apiKey}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> ApiSearchCall(string searchTerm, string apiKey)
    {
      RestClient client = new RestClient($"https://quotes.rest/quote/");
      RestRequest request = new RestRequest($"search?minlength=100&maxlength=300&query={searchTerm}&private=false&language=en&limit=1&sfw=false&api_key=${apiKey}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}