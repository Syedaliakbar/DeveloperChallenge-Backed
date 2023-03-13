using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class QuotableList:BaseModel { 
        public QuotableList() { 
            Results = new List<Quotable>();
        }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }
        [JsonProperty("lastItemIndex")]
        public int LastItemIndex { get; set; }
        [JsonProperty("results")]
        public List<Quotable> Results { get; set; }
    }
}
