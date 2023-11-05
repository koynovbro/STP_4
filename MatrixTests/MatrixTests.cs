using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp1;

namespace MatrixTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void TestAdd()
        {
            // Путь 1: Тест на добавление матриц с разными размерами
            Matrix a = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            Matrix b = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            try
            {
                Matrix result1 = a.Add(b);
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException)
            {
                // Ожидаемое исключение
            }

            // Путь 2: Тест на сложение матриц с одинаковыми размерами
            a = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            b = new Matrix(new int[,] { { 5, 6 }, { 7, 8 } });
            Matrix expected = new Matrix(new int[,] { { 6, 8 }, { 10, 12 } });
            Matrix result = a.Add(b);
            Assert.AreEqual(expected.ToString(true), result.ToString(true));
        }

        [TestMethod]
        public void TestSubtract()
        {
            // Путь 1: Тест на вычитание матриц с разными размерами
            Matrix a = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            Matrix b = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            try
            {
                Matrix result1 = a.Subtract(b);
                Assert.Fail("Expected ArgumentException");
            }
            catch (ArgumentException)
            {
                // Ожидаемое исключение
            }

            // Путь 2: Тест на вычитание матриц с одинаковыми размерами
            a = new Matrix(new int[,] { { 5, 6 }, { 7, 8 } });
            b = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            Matrix expected = new Matrix(new int[,] { { 4, 4 }, { 4, 4 } });
            Matrix result = a.Subtract(b);
            Assert.AreEqual(expected.ToString(true), result.ToString(true));
        }

        [TestMethod]
        public void TestMultiply_ValidMatrix()
        {
            // Arrange
            Matrix a = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            Matrix b = new Matrix(new int[,] { { 5, 6 }, { 7, 8 } });
            Matrix expected = new Matrix(new int[,] { { 19, 22 }, { 43, 50 } });

            // Act
            Matrix result = a.Multiply(b);

            // Assert
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMultiply_InvalidMatrix()
        {
            // Arrange
            Matrix a = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            Matrix b = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });

            // Act
            a.Multiply(b);
        }




        [TestMethod]
        public void TestEquals()
        {
            // Путь 1: Тест на сравнение матриц с разными размерами
            Matrix a = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            Matrix b = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            bool result = a.Equals(b);
            Assert.IsFalse(result);

            // Путь 2: Тест на сравнение равных матриц
            a = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            b = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            result = a.Equals(b);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestTranspose()
        {
            // Путь 1: Тест на транспонирование матрицы
            Matrix a = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            Matrix expected = new Matrix(new int[,] { { 1, 4 }, { 2, 5 }, { 3, 6 } });
            Matrix result = a.Transpose();
            Assert.AreEqual(expected.ToString(true), result.ToString(true));
        }

        [TestMethod]
        public void TestFindMinimum()
        {
            // Путь 1: Тест на поиск минимального элемента в матрице
            Matrix a = new Matrix(new int[,] { { 3, 1 }, { 2, 4 } });
            int result = a.FindMinimum();
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestToString()
        {
            // Путь 1: Тест на строковое представление матрицы без форматирования
            Matrix a = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            string expected1 = "1 2 \n3 4 \n";
            string result1 = a.ToString();
            Assert.AreEqual(expected1, result1);

            // Путь 2: Тест на строковое представление матрицы с форматированием
            string expected2 = "{{1, 2},{3, 4}}";
            string result2 = a.ToString(true);
            Assert.AreEqual(expected2, result2);
        }




        [TestMethod]
        public void TestGetElement()
        {
            // Путь 1: Тест на получение элемента по индексам
            Matrix a = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            int result = a.GetElement(1, 1);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestGetRows()
        {
            // Путь 1: Тест на получение числа строк в матрице
            Matrix a = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            int result = a.Rows;
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestGetColumns()
        {
            // Путь 1: Тест на получение числа столбцов в матрице
            Matrix a = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            int result = a.Columns;
            Assert.AreEqual(2, result);
        }
    }
}
