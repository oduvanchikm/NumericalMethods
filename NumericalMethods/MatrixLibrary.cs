namespace NumericalMethods;
using System.Data;

public class MyMatrix
{
    private readonly List<List<double>> _dataMatrix;
    private int _rowSize;
    private int _colomnSize;
    private List<double> _vectorD;
    private readonly List<double> _dataVector;
    private static double epsilon = 1e-9;

    public MyMatrix()
    {
        _dataMatrix = new List<List<double>>();
        _vectorD = new List<double>();
        _rowSize = 0;
        _colomnSize = 0;
        _vectorD = new List<double>();
    }

    public MyMatrix(int rowSize, int colomnSize)
    {
        _rowSize = rowSize;
        _colomnSize = colomnSize;
        _dataMatrix = new List<List<double>>();
        for (int i = 0; i < rowSize; ++i)
        {
            _dataMatrix.Add(new List<double>(new double[colomnSize]));
        }

        _vectorD = new List<double>(rowSize);
    }

    public int getRowSize() => _rowSize;
    public int getColomnSize() => _colomnSize;

    public List<List<double>> getDataMatrix() => _dataMatrix;

    public List<double> getDataVector() => _dataVector;

    public List<double> getVectorD() => _vectorD;

    public int setRowSize(int rowSize)
    {
        return _rowSize = rowSize;
    }

    public int setColomnSize(int colomnSize)
    {
        return _colomnSize = colomnSize;
    }

    public void SwapRows(MyMatrix A, int indexRow1, int indexRow2)
    {
        (A._dataMatrix[indexRow1], A._dataMatrix[indexRow2]) = (A._dataMatrix[indexRow2], A._dataMatrix[indexRow1]);
    }

    public void setDataMatrix(int row, int col, double value)
    {
        if (row >= 0 && row < _rowSize && col >= 0 && col < _colomnSize)
        {
            _dataMatrix[row][col] = value;
        }
        else
        {
            throw new IndexOutOfRangeException("Row or column indexes are outside the matrix dimensions");
        }

    }

    public void ReadMatrixFromFile(string filename)
    {
        var lines = File.ReadAllLines(filename);
        if (lines.Length == 0)
        {
            throw new InvalidOperationException("Wrong count of elements");
        }

        var firstLineElements = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

        if (firstLineElements.Length > 1)
        {
            _rowSize = lines.Length;
            _colomnSize = firstLineElements.Length;
            _dataMatrix.Clear();

            for (var i = 0; i < _rowSize; ++i)
            {
                var elements = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s =>
                    {
                        double value;
                        if (double.TryParse(s, out value))
                        {
                            return value;
                        }
                        else
                        {
                            throw new FormatException("Invalid number format");
                        }
                    })
                    .ToArray();

                if (elements.Length != _colomnSize)
                {
                    throw new InvalidOperationException("Wrong matrix structure");
                }

                _dataMatrix.Add(new List<double>(elements));
            }

            Console.WriteLine("Matrix:");
            foreach (var row in _dataMatrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
        else
        {
            throw new InvalidExpressionException("Wrong matrix structure");
        }
    }

    public void ReadDFromFile(string filename)
    {
        var lines = File.ReadAllLines(filename);
        if (lines.Length == 0)
        {
            throw new InvalidOperationException("Wrong count of elements");
        }

        _colomnSize = 1;
        _rowSize = lines.Length;
        _vectorD.Clear();

        foreach (var line in lines)
        {
            if (double.TryParse(line, out double number))
            {
                _vectorD.Add(number);
            }
            else
            {
                throw new FormatException("Wrong vector structure");
            }
        }

        Console.WriteLine("Vector:" + string.Join(" ", _vectorD));
    }

    public static MyMatrix operator +(MyMatrix A, MyMatrix B)
    {
        if (A._rowSize != B._rowSize || A._colomnSize != B._colomnSize)
        {
            throw new InvalidOperationException("can't add up the matrices");
        }

        var resultMatrix = new MyMatrix(A._rowSize, A._colomnSize);
        for (var i = 0; i < A._rowSize; ++i)
        {
            for (var j = 0; j < B._colomnSize; ++j)
            {
                resultMatrix._dataMatrix[i][j] = A._dataMatrix[i][j] + B._dataMatrix[i][j];
            }
        }

        return resultMatrix;
    }

    // разность двух матриц
    public static MyMatrix operator -(MyMatrix A, MyMatrix B)
    {
        if (A._rowSize != B._rowSize || A._colomnSize != B._colomnSize)
        {
            throw new InvalidOperationException("can't calculate the difference between two matrices");
        }

        var resultMatrix = new MyMatrix(A._rowSize, A._colomnSize);
        for (var i = 0; i < A._rowSize; ++i)
        {
            for (var j = 0; j < B._colomnSize; ++j)
            {
                resultMatrix._dataMatrix[i][j] = A._dataMatrix[i][j] - B._dataMatrix[i][j];
            }
        }

        return resultMatrix;
    }

    public static List<double> operator *(MyMatrix A, List<double> Vector)
    {
        List<double> result = new List<double>(A._rowSize);

        for (int i = 0; i < A._rowSize; ++i)
        {
            double sum = 0;
            for (int j = 0; j < A._colomnSize; ++j)
            {
                sum += A._dataMatrix[i][j] * Vector[j];
            }

            result.Add(sum);
        }

        return result;
    }

    public static double[] operator *(MyMatrix A, double[] Vector)
    {
        double[] result = new double[A._rowSize];

        for (int i = 0; i < A._rowSize; ++i)
        {
            double sum = 0;
            for (int j = 0; j < A._colomnSize; ++j)
            {
                sum += A._dataMatrix[i][j] * Vector[j];
            }

            result[i] = sum;
        }

        return result;
    }

    // умножение двух матриц 
    public static MyMatrix operator *(MyMatrix A, MyMatrix B)
    {
        if (A._colomnSize != B._rowSize)
        {
            throw new InvalidOperationException(
                "The number of columns in the first matrix must be equal to the number of rows in the second matrix.");
        }

        var resultMatrix = new MyMatrix(A._rowSize, B._colomnSize);

        for (var i = 0; i < A._rowSize; ++i)
        {
            for (var j = 0; j < B._colomnSize; ++j)
            {
                resultMatrix._dataMatrix[i][j] = 0;
                for (var k = 0; k < A._colomnSize; ++k)
                {
                    resultMatrix._dataMatrix[i][j] += A._dataMatrix[i][k] * B._dataMatrix[k][j];
                }
            }
        }

        return resultMatrix;
    }

    // public static double RoundWithEpsilon(double value)
    // {
    //     return Math.Abs(value) < epsilon ? 0 : Math.Round(value);
    // }

    public bool IsIdentityMatrix()
    {
        double epsilon = 1e-9;

        if (_rowSize != _colomnSize)
        {
            return false;
        }

        for (var i = 0; i < _rowSize; ++i)
        {
            for (var j = 0; j < _colomnSize; ++j)
            {
                if (i == j)
                {
                    if (Math.Abs(_dataMatrix[i][j] - 1) > epsilon)
                    {
                        return false;
                    }
                }
                else
                {
                    if (Math.Abs(_dataMatrix[i][j]) > epsilon)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }


    // умножение матрицы на число
    public static MyMatrix operator *(MyMatrix A, double number)
    {
        var resultMatrix = new MyMatrix(A._rowSize, A._colomnSize);
        for (var i = 0; i < A._rowSize; ++i)
        {
            for (var j = 0; j < A._colomnSize; ++j)
            {
                resultMatrix._dataMatrix[i][j] = A._dataMatrix[i][j] * number;
            }
        }

        return resultMatrix;
    }

    public static MyMatrix operator *(double number, MyMatrix A)
    {
        return A * number;
    }

    public static bool operator ==(MyMatrix A, MyMatrix B)
    {
        if (A._rowSize != B._rowSize || B._colomnSize != A._colomnSize)
        {
            return false;
        }

        for (var i = 0; i < A._rowSize; ++i)
        {
            for (var j = 0; j < A._colomnSize; ++j)
            {
                if (A._dataMatrix[i][j] != B._dataMatrix[i][j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool operator !=(MyMatrix A, MyMatrix B)
    {
        return !(A == B);
    }

    public MyMatrix Transpose()
    {
        int row = this._rowSize;
        int column = this._colomnSize;

        if (row != column)
        {
            throw new InvalidOperationException("Wrong count of elements");
        }

        MyMatrix transposeMatrix = new MyMatrix(row, column);

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                transposeMatrix._dataMatrix[j][i] = this._dataMatrix[i][j];
            }
        }

        return transposeMatrix;
    }

    public MyMatrix Inverse()
    {
        int row = this._rowSize;
        int column = this._colomnSize;

        if (row != column)
        {
            throw new InvalidOperationException("Wrong count of elements");
        }

        MyMatrix workMatrix = new MyMatrix(row, column * 2);

        for (int i = 0; i < row; ++i)
        {
            for (int j = 0; j < column; ++j)
            {
                workMatrix._dataMatrix[i][j] = this._dataMatrix[i][j];
            }

            workMatrix._dataMatrix[i][i + row] = 1;
        }

        for (int i = 0; i < row; i++)
        {
            double pivot = workMatrix._dataMatrix[i][i];

            if (Math.Abs(pivot) < 1e-10)
            {
                throw new InvalidOperationException("Matrix doesn't have inverse");
            }

            for (int j = 0; j < 2 * column; j++)
            {
                workMatrix._dataMatrix[i][j] /= pivot;
            }

            for (int k = 0; k < row; k++)
            {
                if (k != i)
                {
                    double factor = workMatrix._dataMatrix[k][i];
                    for (int j = 0; j < 2 * column; j++)
                    {
                        workMatrix._dataMatrix[k][j] -= factor * workMatrix._dataMatrix[i][j];
                    }
                }
            }
        }

        MyMatrix inverseMatrix = new MyMatrix(row, column);

        for (int i = 0; i < row; ++i)
        {
            for (int j = 0; j < column; ++j)
            {
                inverseMatrix._dataMatrix[i][j] = workMatrix._dataMatrix[i][j + row];
            }
        }

        return inverseMatrix;
    }

    public MyMatrix DeepCope()
    {
        int row = this._rowSize;
        int column = this._colomnSize;
        MyMatrix cloneMatrix = new MyMatrix(row, column);

        for (int i = 0; i < row; ++i)
        {
            for (int j = 0; j < column; ++j)
            {
                cloneMatrix._dataMatrix[i][j] = this._dataMatrix[i][j];
            }
        }

        return cloneMatrix;
    }

    public MyMatrix CreateIdentityMatrix()
    {
        int row = _rowSize;
        int column = _colomnSize;

        if (row != column)
        {
            throw new InvalidOperationException("Wrong count of elements");
        }

        MyMatrix newMatrix = new MyMatrix(row, column);

        for (int i = 0; i < row; ++i)
        {
            for (int j = 0; j < column; ++j)
            {
                if (i == j)
                {
                    newMatrix._dataMatrix[i][j] = 1;
                }
                else
                {
                    newMatrix._dataMatrix[i][j] = 0;
                }
            }
        }

        Console.WriteLine("matrix is created");
        for (int i = 0; i < newMatrix._rowSize; ++i)
        {
            for (int j = 0; j < newMatrix._colomnSize; ++j)
            {
                Console.Write($"{newMatrix._dataMatrix[i][j]} ");
            }

            Console.WriteLine();
        }

        return newMatrix;
    }
}
