﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallenge.DLL.Exceptions
{
        public enum SystemExceptions
        {
            Err_ConnectionFail,
            Err_ObjectNotFound,
            Err_GetDataFromDBFailure,
            Err_InsertDataInDBFailure,
            Err_UpdateDataInDBFailure,
            Err_DeleteDataFromDBFailure,
            Err_SavingDataDBFailure,
            Err_ConversionDataError,
            Err_DataRepeatFailure,
            Err_CardOperationFailure,
            Err_UserOperationError,
            Err_DateError
        }
}
