using System;
using System.Collections.Generic;

namespace ArkEcosystem.Client.Helpers
{
    public static class QueryBuilder
    {
        public static string Build(string uri, Dictionary<string, string> parameters)
        {
            if (parameters == null)
            {
                return uri;
            }

            var result = new List<string>();

            foreach (var item in parameters)
            {
                result.Add(item.Key + "=" + item.Value);
            }

            return string.Format("{0}?{1}", uri, String.Join("&", result));
        }
    }
}

