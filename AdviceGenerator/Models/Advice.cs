using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdviceGenerator.Models
{
  public class Advice
  {
    public string Quote { get; set; }
    public string Contents {get; set;}

    public string Author { get; set; }
    public static Advice GetAdvices(string apiKey)
    {
      var apiCallTask = ApiHelper.ApiRandomCall(apiKey);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Advice MyAdvice = JsonConvert.DeserializeObject<Advice>(jsonResponse.ToString());

      return MyAdvice;
    }
    // public static Animal GetDetails(int id)
    // {
    //   var apiCallTask = ApiHelper.Get(id);
    //   var result = apiCallTask.Result;

    //   JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
    //   Animal animal = JsonConvert.DeserializeObject<Animal>(jsonResponse.ToString());

    //   return animal;
    // }

    public static Advice GetSearchableAdvices(string searchTerm, string apiKey)
    {
      var apiCallTask = ApiHelper.ApiSearchCall(searchTerm, apiKey);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Advice MyAdvice = JsonConvert.DeserializeObject<Advice>(jsonResponse.ToString());

      return MyAdvice;
    }
  }
}