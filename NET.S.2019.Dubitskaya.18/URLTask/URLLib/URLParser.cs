using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace URLLib
{
    /// <summary>
    /// Provides methods that parse URLS
    /// </summary>
    public static class URLParser
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Converts URLs array from string form to list of url class instances
        /// </summary>
        /// <param name="urls"></param>
        /// <returns>list of url class instances</returns>
        public static List<URL> Parse(string[] urls)
        {
            if (urls == null)
                throw new ArgumentNullException();

            List<URL> resultList = new List<URL>();

            foreach (string url in urls)
            {
                if (URLValidator.ValidateURL(url))
                {
                    resultList.Add(ParseUrl(url));
                }
            }

            return resultList;
        }

        /// <summary>
        /// Converts an URL from it's string form to url class instances
        /// </summary>
        /// <param name="stringUrl"></param>
        /// <returns>url class instances</returns>
        private static URL ParseUrl(string stringUrl)
        {
            Uri uri = new Uri(stringUrl);
            URL url = new URL();

            url.Host = uri.Host;
            url.Paths = GetPaths(uri.Segments);
            url.Parameters = GetParameters(uri.Query);

            return url;
        }

        /// <summary>
        /// Parses array or strings to url's segments form
        /// </summary>
        /// <param name="segmants"></param>
        /// <returns>list of strings</returns>
        private static List<string> GetPaths(string[] segments)
        {
            if (segments.Length > 1)
            {
                return segments
                    .Select(s => s.Trim('/'))
                    .ToList<string>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Parses array or strings to url's parameters form
        /// </summary>
        /// <param name="segmants"></param>
        /// <returns>list of strings</returns>
        private static Dictionary<string, string> GetParameters(string parameters)
        {
            if (parameters != string.Empty)
            {
                try
                {
                    return parameters
                        .Trim('?')
                        .Split('&')
                        .Select(p => p.Split('='))
                        .ToDictionary(pair => pair[0], pair => pair[1]);
                }
                catch
                {
                    logger.Error(String.Format("Incorrect parameters format: {0}", parameters));
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
