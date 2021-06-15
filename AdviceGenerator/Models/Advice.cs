using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdviceGenerator.Models
{
  public class Advice
  {
    public JObject Contents { get; set; }
    public JArray Quotes { get; set; }
    public string Quote { get; set; }
    public string Query { get; set; }

    public static Advice GetAdvices()
    {
      var apiCallTask = ApiHelper.ApiCall();
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Advice adviceList = JsonConvert.DeserializeObject<Advice>(jsonResponse.ToString());
      return adviceList;
    }

    // public static Advice GetSearchableAdvices(string searchTerm, string apiKey)
    // {
    //   var apiCallTask = ApiHelper.ApiSearchCall(searchTerm, apiKey);
    //   var result = apiCallTask.Result;

    //   JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
    //   Advice MyAdvice = JsonConvert.DeserializeObject<Advice>(jsonResponse.ToString());

    //   return MyAdvice;
    // }
  
  }
}