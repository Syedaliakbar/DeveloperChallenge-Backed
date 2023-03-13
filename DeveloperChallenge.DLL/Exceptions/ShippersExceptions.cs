using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallenge.DLL.Exceptions
{
    public class ShippersExceptions : Exception
    {
        public string QueryCauseError;
        public string ActualErrorMessage;
        public int ErrorCode;

        public ShippersExceptions(string errMessage, int errorCode, string causedQuery, Exception errorHappen)
            : base(errMessage, errorHappen)
        {
            ErrorCode = errorCode;
            QueryCauseError = causedQuery;
            ActualErrorMessage = errorHappen.Message;
        }
        public ShippersExceptions(string errMessage, int errorCode, Exception errorHappen)
            : base(errMessage, errorHappen)
        {
            ErrorCode = errorCode;
            QueryCauseError = "User Entry";
            ActualErrorMessage = errorHappen.Message;
        }
        public ShippersExceptions(string errMessage, int errorCode, string causedQuery)
            : base(errMessage)
        {
            ErrorCode = errorCode;
            QueryCauseError = causedQuery;
            ActualErrorMessage = "";
        }
        public ShippersExceptions(string errMessage, int errorCode)
            : base(errMessage)
        {
            ErrorCode = errorCode;
            QueryCauseError = "User Entry";
            ActualErrorMessage = "";
        }
        public override string ToString()
        {
            return "Error: " + Message + " Returned Error:" + ActualErrorMessage + " Code: " + ErrorCode + " WhatCauseTheError: " + QueryCauseError;
        }
        public string ToSmallString()
        {
            return "خطأ " + ErrorCode + " : " + Message;
        }
    }
}
