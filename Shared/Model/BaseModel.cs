using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class BaseModel
    {
        public bool IsSuccessfull { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
