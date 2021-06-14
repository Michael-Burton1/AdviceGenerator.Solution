using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvcApiCall.Models
{
  public class Advice
  {
    public static List<Advice> GetAdvices(string apiKey)
    {
      var apiCallTask = ApiHelper.ApiRandomCall(apiKey);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Advice> AdviceList = JsonConvert.DeserializeObject<List<Advice>>(jsonResponse["results"].ToString());

      return AdviceList;
    }

    public static List<Advice> GetSearchedAdvices(string searchTerm, string apiKey)
    {
      var apiCallTask = ApiHelper.ApiSearchCall(searchTerm, apiKey);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Advice> AdviceList = JsonConvert.DeserializeObject<List<Advice>>(jsonResponse["results"].ToString());

      return AdviceList;
    }
  }
}