using System;
using System.IO;

namespace URLLib
{
    /// <summary>
    /// Represents urls's container abstraction and provides it's methods
    /// </summary>
    public class URLsContainer
    {
        private string[] urls;

        public string[] URLs
        {
            get
            {
                return urls;
            }
        }

        /// <summary>
        /// Initializes a new instance of the URLsContainer class.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>instance</returns>
        public URLsContainer(string filePath)
        {
            if (filePath == null)
                throw new ArgumentException("Invalid path");
            SetUrls(filePath);
        }

        /// <summary>
        /// Reades all lines from file to string array
        /// </summary>
        /// <param name="filePath"></param>
        private void SetUrls(string filePath)
        {
            if (!File.Exists(filePath))
                throw new ArgumentException("Incorrect file path");

            urls = File.ReadAllLines(filePath);
        }
    }
}
