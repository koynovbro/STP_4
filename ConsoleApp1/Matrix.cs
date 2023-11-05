using System;

public class Matrix
{
    private int[,] data;

    public int Rows { get; }
    public int Columns { get; }

    public Matrix(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        data = new int[rows, columns];
    }

    public Matrix(int[,] array)
    {
        Rows = array.GetLength(0);
        Columns = array.GetLength(1);
        data = array;
    }

    public int this[int i, int j]
    {
        get
        {
            if (i < 0 || i >= Rows || j < 0 || j >= Columns)
            {
                throw new IndexOutOfRangeException("Invalid matrix indices.");
            }
            return data[i, j];
        }
    }

    public Matrix Add(Matrix b)
    {
        if (Rows != b.Rows || Columns != b.Columns)
        {
            throw new ArgumentException("Matrix dimensions must be the same for addition.");
        }

        int[,] result = new int[Rows, Columns];
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                result[i, j] = this[i, j] + b[i, j];
            }
        }

        return new Matrix(result);
    }

    public Matrix Subtract(Matrix b)
    {
        if (Rows != b.Rows || Columns != b.Columns)
        {
            throw new ArgumentException("Matrix dimensions must be the same for subtraction.");
        }

        int[,] result = new int[Rows, Columns];
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                result[i, j] = this[i, j] - b[i, j];
            }
        }

        return new Matrix(result);
    }

    public Matrix Multiply(Matrix b)
    {
        if (Columns != b.Rows)
        {
            throw new ArgumentException("The number of columns in the first matrix must be equal to the number of rows in the second matrix for multiplication.");
        }

        int[,] result = new int[Rows, b.Columns];
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < b.Columns; j++)
            {
                int sum = 0;
                for (int k = 0; k < Columns; k++)
                {
                    sum += this[i, k] * b[k, j];
                }
                result[i, j] = sum;
            }
        }

        return new Matrix(result);
    }

    public bool Equals(Matrix b)
    {
        if (Rows != b.Rows || Columns != b.Columns)
        {
            return false;
        }

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (this[i, j] != b[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public Matrix Transpose()
    {
        int[,] result = new int[Columns, Rows];
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                result[j, i] = this[i, j];
            }
        }

        return new Matrix(result);
    }

    public int FindMinimum()
    {
        int min = this[0, 0];
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (this[i, j] < min)
                {
                    min = this[i, j];
                }
            }
        }

        return min;
    }

    public override string ToString()
    {
        return ToString(false);
    }

    public string ToString(bool formatted)
    {
        if (formatted)
        {
            string result = "{";
            for (int i = 0; i < Rows; i++)
            {
                result += "{";
                for (int j = 0; j < Columns; j++)
                {
                    result += this[i, j];
                    if (j < Columns - 1)
                    {
                        result += ", ";
                    }
                }
                result += "}";
                if (i < Rows - 1)
                {
                    result += ",";
                }
            }
            result += "}";
            return result;
        }
        else
        {
            string result = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result += this[i, j] + " ";
                }
                result += "\n";
            }
            return result;
        }
    }

    public int GetElement(int i, int j)
    {
        if (i < 0 || i >= Rows || j < 0 || j >= Columns)
        {
            throw new IndexOutOfRangeException("Invalid matrix indices.");
        }
        return data[i, j];
    }

}
