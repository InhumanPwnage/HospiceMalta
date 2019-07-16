using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class UIHelpers
    {
        public static string UserFullName
        {
            get
            {
                if (HttpContext.Current.Session["UserFullName"] != null)
                    return HttpContext.Current.Session["UserFullName"].ToString();

                return string.Empty;
            }
            set
            {
                HttpContext.Current.Session["UserFullName"] = value;
            }
        }

        public static string UserUsername
        {
            get
            {
                if (HttpContext.Current.Session["UserUsername"] != null)
                    return HttpContext.Current.Session["UserUsername"].ToString();

                return string.Empty;
            }
            set
            {
                HttpContext.Current.Session["UserUsername"] = value;
            }
        }
    }
}