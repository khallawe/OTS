using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTS.code
{
    public class GenerateErrorLog
    {
        public static void AddLog(string error,int userID)
        {
            ErrorLog errorLog = new ErrorLog();
            errorLog.UserID = userID;
            errorLog.CreatedDate = DateTime.Now;
            errorLog.errorMsg = error;
            
        }
    }
}