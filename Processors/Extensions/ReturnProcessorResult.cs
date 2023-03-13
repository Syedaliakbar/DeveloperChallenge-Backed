using Newtonsoft.Json;
using Processors.Model;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Processors.Extensions
{
    public static class ReturnProcessorResult
    {
        public static ProcessorGetModel ProcessorResult(this RestResponse restResponse)
        {
            var model = new ProcessorGetModel();
            if(restResponse != null)
            {
                model.StatusCode = restResponse.StatusCode;
                model.Content = restResponse.Content;
                model.ContentType = restResponse.ContentType;
                model.ContentLength = restResponse.ContentLength;
                model.IsSuccessStatusCode = restResponse.IsSuccessStatusCode;
                model.ContentEncoding = restResponse.ContentEncoding;
            }
            return model;
        }
    }
}
