using System;
using NUnit.Framework;

namespace BookService.NUnitTests
{
    [TestFixture]
    public class BookTests
    {
        public static readonly Book TestBook = new Book("0-8044-2957-X", "John Smith", "Some perfect book", "Really great publisher", 2019, 10000, 25.8);

        [Test]
        public void ToStringTest_EmptyFormat_DefaultFormat()
        {
            Assert.That(TestBook.ToString(), Is.EqualTo("John Smith, \"Some perfect book\", 2019."));
        }

        [Test]
        public void ToStringTest_ValidFormat()
        {
            Assert.That(TestBook.ToString("I"), Is.EqualTo("0-8044-2957-X."));
            Assert.That(TestBook.ToString("A"), Is.EqualTo("John Smith."));
            Assert.That(TestBook.ToString("T"), Is.EqualTo("\"Some perfect book\"."));
            Assert.That(TestBook.ToString("E"), Is.EqualTo("Really great publisher."));
            Assert.That(TestBook.ToString("Y"), Is.EqualTo("2019."));
            Assert.That(TestBook.ToString("p"), Is.EqualTo("10000 pages."));
            Assert.That(TestBook.ToString("P"), Is.EqualTo("25.8."));
            Assert.That(TestBook.ToString("IATEYPp"), Is.EqualTo("0-8044-2957-X, John Smith, \"Some perfect book\", Really great publisher, 2019, 25.8, 10000 pages."));
            Assert.That(TestBook.ToString("ATY"), Is.EqualTo("John Smith, \"Some perfect book\", 2019."));
            Assert.That(TestBook.ToString("IATP"), Is.EqualTo("0-8044-2957-X, John Smith, \"Some perfect book\", 25.8."));
        }

        [Test]
        public void ToString_IcorrectFormat_FormatException()
        {
            Assert.That(() => TestBook.ToString("Ai"), Throws.TypeOf<FormatException>());
        }
    }
}
