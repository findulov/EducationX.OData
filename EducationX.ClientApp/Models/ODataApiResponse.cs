using Newtonsoft.Json;
using System.Collections.Generic;

namespace EducationX.ClientApp.Models
{
    public class ODataApiResponse<T>
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("value")]
        public T Value { get; set; }
    }
}
