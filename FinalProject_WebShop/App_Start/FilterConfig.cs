﻿using System.Web;
using System.Web.Mvc;

namespace FinalProject_WebShop
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
