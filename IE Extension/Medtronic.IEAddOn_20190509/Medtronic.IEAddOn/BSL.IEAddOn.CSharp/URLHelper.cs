using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medtronic_IEAddOn
{
    public static class URLHelper
    {
        public static string ToUrl(this string baseUrl, Dictionary<string, string> source)
        {
            return baseUrl + "?" + String.Join("&", source.Select(kvp => String.Format("{0}={1}",
                                HttpUtility.UrlEncode(kvp.Key),
                                HttpUtility.UrlEncode(kvp.Value))).ToArray());
        }
    }
}
