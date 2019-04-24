using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueLib;

namespace QueueLib.Tests
{
    [TestFixture]
    public class CustomQueueTests
    {
        [Test]
        public void Enqueue_CorrectParamsInt_CountIncrements()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            CustomQueue<int> queue = new CustomQueue<int>(arr);

            int expected = 6;

            queue.Enqueue(6);
            int actual = queue.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Dequeue_CorrectParamsSting_CountDecrements()
        {
            string[] arr = { "af", "re", "lo" };
            CustomQueue<string> queue = new CustomQueue<string>(arr);

            int expected = 2;

            queue.Dequeue();
            int actual = queue.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Peek_CorrectParamsSting_ReturnsFirstValue()
        {
            string[] arr = { "af", "re", "lo" };
            CustomQueue<string> queue = new CustomQueue<string>(arr);

            string expected = "af";

            string actual = queue.Peek ();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Contains_CorrectParamsInt_ReturnsTrueIfContains()
        {
            List<int> list = new List<int> { 1, 2, 3, 4 };
            CustomQueue<int> queue = new CustomQueue<int>(list);

            bool expected = true;

            bool actual = queue.Contains(3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Clear_CorrectParamsSting_CountBecomesZero()
        {
            string[] arr = { "af", "re", "lo" };
            CustomQueue<string> queue = new CustomQueue<string>(arr);

            int expected = 0;

            queue.Clear();
            int actual = queue.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CopyTo_CorrectParamsInt_FillsArrayWithQueueElements()
        {
            List<int> list = new List<int> { 1, 2, 3, 4 };
            CustomQueue<int> queue = new CustomQueue<int>(list);

            int expected = 1;

            int[] arr = { 88, 88, 88, 88, 88, 88 };
            queue.CopyTo(arr, 0);
            int actual = arr[0];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetEnumerator_CorrectParamsSting_RetrunsEnumerator()
        {
            string[] arr = { "af", "re", "lo" };
            CustomQueue<string> queue = new CustomQueue<string>(arr);

            List<string> expected = new List<string> { "af", "re", "lo" };

            List<string> actual = new List<string>();
            foreach (string element in queue)
                actual.Add(element);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Peek_IncorrectParams_ThrowsExeption()
        {
            CustomQueue<int> queue = null;
            Assert.Throws<NullReferenceException>(() => queue.Peek());
        }

        [Test]
        public void Constructor_IncorrectParams_ThrowsExeption()
        {
            string[] arr = new string[10];
            CustomQueue<int> queue = new CustomQueue<int>();
            Assert.Throws<ArgumentException>(() => queue.CopyTo(arr, 0));
        }

        [Test]
        public void Dequeue_IncorrectParams_ThrowsExeption()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }
    }
}
