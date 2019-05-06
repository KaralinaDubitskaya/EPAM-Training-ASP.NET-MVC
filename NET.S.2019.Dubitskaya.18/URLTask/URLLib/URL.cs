using System;
using System.Collections.Generic;

namespace URLLib
{
    /// <summary>
    /// Represents URL address abstraction
    /// </summary>
    public class URL
    {
        public string Host { get; set; }

        public List<string> Paths { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
    }
}
