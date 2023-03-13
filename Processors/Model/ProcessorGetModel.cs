using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Processors.Model
{
    public class ProcessorGetModel
    {
            public string? ContentType { get; set; }
            public long? ContentLength { get; set; }
            public ICollection<string> ContentEncoding { get; set; } = new List<string>();
            public string? Content { get; set; }
            public HttpStatusCode StatusCode { get; set; }
            public bool IsSuccessStatusCode { get; set; }
    }
}
