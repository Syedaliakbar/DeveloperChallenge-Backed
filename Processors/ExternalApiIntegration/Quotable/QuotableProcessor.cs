using Newtonsoft.Json;
using Processors.Enum;
using RestSharp;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors.ExternalApiIntegration.Quotable
{
    public class QuotableProcessor
    {
        private GenericProcessor genericProcessor;
        public QuotableProcessor()
        {
            genericProcessor = new GenericProcessor();
        }
        public Shared.Model.Quotable GetRendomQuaotable()
        {
            var result = new Shared.Model.Quotable();
            try
            {
                var response=  genericProcessor.Get(QuotableApiPaths.Base,QuotableApiPaths.Random);
                if(response != null)
                {
                    if(response.IsSuccessStatusCode)
                    {
                        if(!string.IsNullOrEmpty(response.Content))
                        {
                            result = JsonConvert.DeserializeObject<Shared.Model.Quotable>(response.Content);
                        }
                        result.IsSuccessfull = response.IsSuccessStatusCode;
                        result.StatusCode = response.StatusCode;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

            }
            catch(Exception ex) {
                throw ex;
            }
            return result;
        }
        public QuotableList GetQuaotableList(string authorName)
        {
            var result = new QuotableList();
            try
            {
                var response=  genericProcessor.Get(QuotableApiPaths.Base,QuotableApiPaths.Quotes,new { author = authorName });
                if(response != null)
                {
                    if(response.IsSuccessStatusCode)
                    {
                        if(!string.IsNullOrEmpty(response.Content))
                        {
                            result = JsonConvert.DeserializeObject<QuotableList>(response.Content);
                        }
                        result.IsSuccessfull = response.IsSuccessStatusCode;
                        result.StatusCode = response.StatusCode;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

            }
            catch(Exception ex) {
                throw ex;
            }
            return result;
        }
    }
}
