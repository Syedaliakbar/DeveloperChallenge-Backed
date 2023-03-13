using Newtonsoft.Json;
using Processors.Enum;
using Processors.Extensions;
using Processors.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Processors.ExternalApiIntegration
{
    public class GenericProcessor
    {
        public ProcessorGetModel Get(string apiBasePath,string endPoint,object? parameter = null)
        {
            var response = new ProcessorGetModel();
            try {
                var client = new RestClient(apiBasePath);
                RestRequest request = new RestRequest(endPoint, Method.Get);
                if (parameter != null)
                {
                    foreach (PropertyInfo prop in parameter.GetType().GetProperties())
                    {
                        request.AddParameter(prop.Name, prop.GetValue(parameter, null)?.ToString());

                    }
                }
                response = client.Execute(request).ProcessorResult();
            }
            catch(Exception ex) {
                throw ex;
            }
            return response;
        }
    }
}
