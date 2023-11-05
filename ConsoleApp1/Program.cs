using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix a = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Matrix b = new Matrix(new int[,] { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } });

            Matrix sum = a.Add(b);
            Matrix difference = a.Subtract(b);
            Matrix product = a.Multiply(b);
            bool isEqual = a.Equals(b);
            Matrix transposed = a.Transpose();
            int minimum = a.FindMinimum();

            Console.WriteLine("Matrix A:\n" + a.ToString());
            Console.WriteLine("Matrix B:\n" + b.ToString());
            Console.WriteLine("Sum of A and B:\n" + sum.ToString());
            Console.WriteLine("Difference of A and B:\n" + difference.ToString());
            Console.WriteLine("Product of A and B:\n" + product.ToString());
            Console.WriteLine("A is equal to B: " + isEqual);
            Console.WriteLine("\nTranspose of A:\n" + transposed.ToString());
            Console.WriteLine("Minimum element in A: " + minimum);
            Console.WriteLine("\nMatrix A (string format):\n" + a.ToString(true));
            Console.WriteLine("\nElement at (1, 2): " + a.GetElement(1, 2));
            Console.WriteLine("\nNumber of rows: " + a.Rows);
            Console.WriteLine("\nNumber of columns: " + a.Columns);

        }
    }
}
