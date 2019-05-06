using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace URLLib
{
    /// <summary>
    /// Provides method that converts list of urls to xml document and saves it 
    /// </summary>
    public static class URLSerializer
    {
        /// <summary>
        /// Converts list of urls to xml document and saves it 
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="filePath"></param>
        public static void SaveXml(List<URL> urls, string filePath)
        {
            if (filePath == null)
                throw new ArgumentException("Invalid path");

            if (urls != null)
            {
                XElement root = new XElement("urlAddresses");
                XElement node;

                foreach (URL url in urls)
                {
                    node = new XElement("urlAdress");
                    node.Add(new XElement("host", new XAttribute("name", url.Host)));

                    if (url.Paths != null)
                    {
                        node.Add(new XElement("uri", url.Paths.Select(path => new XElement("segment", path))));
                    }

                    if (url.Parameters != null)
                    {
                        node.Add(new XElement("parameters", url.Parameters.Select(y => new XElement("parametr",
                                                                                        new XAttribute("value", y.Value),
                                                                                        new XAttribute("key", y.Key)))));
                    }

                    root.Add(node);
                }

                XDocument document = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), root);
                document.Save(filePath);
            }
        }
    }
}
