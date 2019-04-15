using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.NUnitTests
{
    [TestFixture]
    public class BookExtensionsTests
    {
        public static readonly Book TestBook = new Book("0-8044-2957-X", "John Smith", "Some perfect book", "Really great publisher", 2019, 10000, 25.8);

        [Test]
        public void HarvardRefference()
        {
            Assert.That(TestBook.HarvardRefference, Is.EqualTo("John Smith (2019). Some perfect book. ed. Really great publisher, p.10000. 0-8044-2957-X. Price: 25.8."));
        }
    }
}
