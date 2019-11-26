using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Book_Store.Helpers
{
    public static class AlertMessage
    {
        public static void DisplayAlert(string message,bool isErrorMessage)
        {
            if(isErrorMessage)
            {
                System.Web.HttpContext.Current.Session["ErrorMessage"] = message;
            }
            else
            {
                System.Web.HttpContext.Current.Session["SucessMessage"] = message;
            }
            
        }
    }
}