using OTS.Model;
using System;
using OTS.DAL;

namespace OTS.code
{
    public class GenerateErrorLog
    {
        public static void AddLog(string error, int userID)
        {
            ErrorLog errorLog = new ErrorLog();
            errorLog.UserID = userID;
            errorLog.CreatedDate = DateTime.Now;
            errorLog.errorMsg = error;


            BLL.ErrorLog.Instance.Add(errorLog);


        }
    }
}