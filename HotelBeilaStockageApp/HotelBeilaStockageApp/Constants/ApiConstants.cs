using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBeilaStockageApp.Constants
{
    class ApiConstants
    {
        public const string BaseApiUrl = "http://192.168.150.205:8081";

        public static string UserByNameEndpoint(string name)
        {
            return "/user/name/" + name;
        }

        public static string ItemByAreaEndpoint(string area)
        {
            return "/product/item/" + area;
        }

        public static string AllItemsEndpoint()
        {
            return "/items";
        }
    }
}
