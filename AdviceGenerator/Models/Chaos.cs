using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdviceGenerator.Models
{
  public class Chaos
  {
    public JValue Word { get; set; }
    public static List<Chaos> GetChaosWord(string searchTerm)
    {
      var apiCallTask = ApiHelper.GetChaos(searchTerm);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Chaos> chaosList = JsonConvert.DeserializeObject<List<Chaos>>(jsonResponse.ToString());

      return chaosList;
    }
  }
}
