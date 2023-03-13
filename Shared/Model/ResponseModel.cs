using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            this.Data = new object();
            MessageEng = string.Empty;
            MessageAr = string.Empty;
            StatusCode = (int)HttpStatusCode.OK;
        }
        public int StatusCode { get; set; }
        public string MessageEng { get; set; }
        public string MessageAr { get; set; }
        public object Data { get; set; }
        public object Exception { get; set; }
    }
}
