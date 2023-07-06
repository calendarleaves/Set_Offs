using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Layout_2._1
{
    public class Custom
    {
        public static void ErrorHandle(Exception ex, HttpResponse Response)
        {
            // Determine the appropriate status code based on the exception
            int statusCode;
            if (ex is HttpException)
            {
                statusCode = 404; // File Not Found
            }
            else if (ex is UnauthorizedAccessException)
            {
                statusCode = 401; // Unauthorized
            }
            else if(ex is ThreadAbortException) 
            {
                statusCode = 200;
            }
            else
            {
                statusCode = 500; // Internal Server Error
            }

            //Set the response status code
            Response.StatusCode = statusCode;

            // Redirect to the corresponding error page based on the status code
            switch (statusCode)
            {
                case 200:
                    break;
                case 404:
                    Response.Redirect("~/Error Handler/Error404.aspx");
                    break;
                case 500:
                    Response.Redirect("~/Error Handler/Error500.aspx");
                    break;
                default:

                    Response.Redirect("~/Error Handler/Error.aspx");
                    break;
            }
        }
    }
}