using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class Quotable:BaseModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
        [JsonProperty("authorSlug")]
        public string AuthorSlug { get; set; }
        [JsonProperty("length")]
        public int Length { get; set; }
        [JsonProperty("dateAdded")]
        public string DateAdded { get; set; }
        [JsonProperty("dateModified")]
        public string DateModified { get; set; }
    }
}
