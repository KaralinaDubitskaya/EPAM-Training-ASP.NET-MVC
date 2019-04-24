using NUnit.Framework;
using System;
using System.Collections.Generic;
using BinaryTreeLib;

namespace BinaryTreeLib.Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void BinaryTree_IntDefaultComparer_ExpetedResult()
        {
            int[] array = { 27, 35, 14, 19, 10, 42, 31 };
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.AddElements(array);

            int[] expected = { 10, 14, 19, 27, 31, 35, 42 };

            int[] actual = new int[array.Length];
            int i = 0;
            foreach (int value in tree.InorderTraversal())
            {
                actual[i++] = value;
            }

            Assert.AreEqual(expected, actual);
        }

        private class StringCustomComparer : IComparer<string>
        {
            public int Compare(string s1, string s2)
            {
                return s1.Length - s2.Length;
            }
        }

        [Test]
        public void BinaryTree_StringCustomComparer_ExpetedResult()
        {
            string[] array = { "aaa", "a", "aa", "aaaa", "aaaaa" };
            StringCustomComparer comp = new StringCustomComparer();
            BinaryTree<string> tree = new BinaryTree<string>(comp.Compare);
            tree.AddElements(array);

            string[] expected = { "a", "aa", "aaa", "aaaa", "aaaaa" };

            string[] actual = new string[array.Length];
            int i = 0;
            foreach (string value in tree.InorderTraversal())
            {
                actual[i++] = value;
            }

            Assert.AreEqual(expected, actual);
        }

        private class Book : IComparable<Book>
        {
            public string name;
            public string author;
            public int year;
            public int price;

            public int CompareTo(Book book)
            {
                return this.price - book.price;
            }
        }

        [Test]
        public void BinaryTree_CustomTypeDefaultComparer_ExpetedResult()
        {
            Book b1 = new Book() { price = 322, author = "K", name = "M", year = 1998 };
            Book b2 = new Book() { price = 200, author = "K", name = "M", year = 1990 };
            Book b3 = new Book() { price = 144, author = "K", name = "D", year = 1900 };
            Book b4 = new Book() { price = 400, author = "K", name = "M", year = 1999 };

            Book[] books = { b1, b2, b3, b4 };

            BinaryTree<Book> tree = new BinaryTree<Book>();
            tree.AddElements(books);

            Book[] expected = { b3, b2, b1, b4 };

            Book[] actual = new Book[books.Length];
            int i = 0;
            foreach (Book b in tree.InorderTraversal())
            {
                actual[i++] = b;
            }

            Assert.AreEqual(expected, actual);
        }

        private struct Point
        {
            public int x;
            public int y;
            public int z;
        }

        private class PointComparer : IComparer<Point>
        {
            public int Compare(Point p1, Point p2)
            {
                return ((p1.x + p1.y + p1.z) - (p2.x + p2.y + p2.z));
            }
        }

        [Test]
        public void BinaryTree_CustomTypeCustomComparer_ExpetedResult()
        {
            Point p1 = new Point() { x = 7, y = 10, z = 10 };
            Point p2 = new Point() { x = 4, y = 5, z = 5 };
            Point p3 = new Point() { x = 5, y = 3, z = 2 };
            Point p4 = new Point() { x = 9, y = 4, z = 6 };
            Point p5 = new Point() { x = 7, y = 13, z = 15 };
            Point p6 = new Point() { x = 2, y = 22, z = 18 };
            Point p7 = new Point() { x = 13, y = 9, z = 9 };

            PointComparer comp = new PointComparer();
            BinaryTree<Point> tree = new BinaryTree<Point>(comp.Compare);

            tree.AddElement(p1);
            tree.AddElement(p2);
            tree.AddElement(p3);
            tree.AddElement(p4);
            tree.AddElement(p5);
            tree.AddElement(p6);
            tree.AddElement(p7);

            Point[] expected = { p3, p2, p4, p1, p7, p5, p6 };

            Point[] actual = new Point[expected.Length];
            int i = 0;
            foreach (Point point in tree.InorderTraversal())
            {
                actual[i++] = point;
            }

            Assert.AreEqual(expected, actual);
        }        
    }
}
