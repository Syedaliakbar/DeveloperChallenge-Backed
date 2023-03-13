using DeveloperChallenge.BLLContacts.Services;
using Processors.ExternalApiIntegration.Quotable;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallenge.BLL.Services
{
    public class QuotableService : IQuotableService
    {
        public QuotableProcessor quotableProcessor;

        public QuotableService() {
            quotableProcessor = new QuotableProcessor();
        }
        public Quotable GetRendom()
        {
            var random = new Quotable();  
            try
            {
                var response = quotableProcessor.GetRendomQuaotable();
                if(response != null)
                {
                    random= response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return random;
        }
        public QuotableList GetQuotableList(string authorName)
        {
            var random = new QuotableList();  
            try
            {
                var response = quotableProcessor.GetQuaotableList(authorName);
                if(response != null)
                {
                    random= response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return random;
        }
    }
}
