using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitsFiltering.Tests
{
    [TestFixture]
    public class DigitsFilterTests
    {
        [TestCase(new int[] { 1, 4, 23, 346, 7, 23, 87, 71, 77 }, 7, ExpectedResult = new int[] { 7, 87, 71, 77 })]
        [TestCase(new int[] { 345, 4, 0, 90, 709 }, 0, ExpectedResult = new int[] { 0, 90, 709})]
        public IEnumerable<int> FilterDigits_NumbersContainDigit(int[] numbers, byte digit)
            => DigitsFilter.FilterDigits(numbers, digit);

        [TestCase(new int[] { 1, 4, 222, 9302 }, 7, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 345, 4, 354, 25, 5 }, 0, ExpectedResult = new int[] { })]
        public IEnumerable<int> FilterDigits_NumbersNotContainDigit(int[] numbers, byte digit)
            => DigitsFilter.FilterDigits(numbers, digit);
        
        [TestCase(new int[] { }, 0, ExpectedResult = new int[] { })]
        public IEnumerable<int> FilterDigits_EmptyList(int[] numbers, byte digit)
            => DigitsFilter.FilterDigits(numbers, digit);

        [Test]
        public void FilterDigits_NullNumbers_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() =>
            {
                int[] test = DigitsFilter.FilterDigits(null, 3).ToArray();
            });

        [Test]
        public void FilterDigits_InvalidDigit_ArgumentException()
            => Assert.Throws<ArgumentException>(() => 
            {
                int[] test = DigitsFilter.FilterDigits(new int[] { 10, 5 }, 10).ToArray();
            });
    }
}
