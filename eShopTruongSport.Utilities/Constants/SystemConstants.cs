using System;
using System.Collections.Generic;
using System.Text;

namespace eShopTruongSport.Utilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "eShopTruongSportDb";
        public const string CartSession = "CartSession";
        public class AppSettings
        {
            public const string DefaultLanguageID = "DefaultLanguageID";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";

            public static string DefaultLanguageId { get; set; }
        }
        public class ProductSettings
        {
            public const int NumberOfFeaturedProducts = 16;
            public const int NumberOfLatestProducts = 10;
        }
        public class ProductConstants
        {
            public const string NA = "N/A";
        }
    }
}
