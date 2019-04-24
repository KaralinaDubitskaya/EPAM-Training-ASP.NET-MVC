using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLib.Matrices;
using MatrixLib;

namespace MatrixLib.Tests
{
    [TestClass]
    public class MatricesTests
    {
        private static bool test = false;

        [TestMethod]
        public void CreatingMatrix_IndexatorWork_ChangingElement_CorrectParams_ExpectedResult()
        {
            int[,] arr = { { 1, 2 }, { 2, 4 } };
            SymmetricMatrix<int> s = new SymmetricMatrix<int>(arr);
            s.NewElement(1, 1, 10);

            int expected = 10;

            int actual = s[1, 1];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SummingMatrices_CorrectParams_ExpectedResult()
        {
            int[,] arr1 = { { 1, 2 }, { 2, 4 } };
            SymmetricMatrix<int> m1 = new SymmetricMatrix<int>(arr1);

            int[,] arr2 = { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            SquareMatrix<int> m2 = new SquareMatrix<int>(arr2);

            Matrix<int> matrix = m1.SumMatrices(m2);
            int expected = 6;

            int actual = matrix[1, 1];

            Assert.AreEqual(expected, actual);
        }

        private static void TestMethod(object sender, MatrixElementChangedEventArgs e)
        {
            test = true;
        }

        [TestMethod]
        public void EventWork_CorrectParams_ExpectedResult()
        {
            int[,] arr1 = { { 1, 2 }, { 2, 4 } };
            SymmetricMatrix<int> m1 = new SymmetricMatrix<int>(arr1);
            m1.MatrixElementChanged += TestMethod;

            bool expected = true;

            m1.NewElement(1, 1, 10);
            bool actual = test;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NewElement_IncorrectParams_TrowsExeption()
        {
            int[,] arr1 = { { 1, 2 }, { 2, 4 } };
            SymmetricMatrix<int> m1 = new SymmetricMatrix<int>(arr1);
            
            m1.NewElement(10, 10, 88);
        }
    }
}
