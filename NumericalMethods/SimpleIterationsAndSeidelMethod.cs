namespace NumericalMethods;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Data;


public class SimpleIterationsAndSeidelMethod
{
    private static bool CheckQuadraticMatrix(MyMatrix matrix)
    {
        int row = matrix.getRowSize();
        int column = matrix.getColomnSize();

        if (row != column)
        {
            return false;
        }

        return true;
    }

    private static bool CheckIterationCondition(MyMatrix matrix)
    {
        double diagonalSumm = 0;
        double totalSumm = 0;

        for (int i = 0; i < matrix.getRowSize(); ++i)
        {
            for (int j = 0; j < matrix.getRowSize(); ++j)
            {
                totalSumm += Math.Abs(matrix.getDataMatrix()[i][j]);
                if (i == j)
                {
                    diagonalSumm += Math.Abs(matrix.getDataMatrix()[i][j]);
                }
            }
        }

        double otherElementsSumm = totalSumm - diagonalSumm;

        if (otherElementsSumm < diagonalSumm)
        {
            return true;
        }

        return false;
    }

    private static List<double> SeidelMethod(MyMatrix alpha, MyMatrix beta, double epsilon)
    {
        if (!CheckQuadraticMatrix(alpha))
        {
            throw new ArithmeticException("The matrix must be square.");
        }

        int n = alpha.getRowSize();
        List<double> currentResult = new List<double>(new double[n]);
        List<double> previousResult = new List<double>(new double[n]);

        for (var i = 0; i < n; ++i)
        {
            previousResult[i] = beta.getVectorD()[i];
        }

        int maxIterations = 1000;
        int iteration = 0;
        bool hasConverged = false;

        while (!hasConverged && iteration < maxIterations)
        {
            hasConverged = true;

            for (int i = 0; i < n; ++i)
            {
                double sum = 0;

                for (int j = 0; j < n; ++j)
                {
                    if (i > j)
                    {
                        sum += alpha.getDataMatrix()[i][j] * currentResult[j];
                    }
                    else if (i < j)
                    {
                        sum += alpha.getDataMatrix()[i][j] * previousResult[j];
                    }
                }

                currentResult[i] = (beta.getVectorD()[i] - sum) / alpha.getDataMatrix()[i][i];

                if (Math.Abs(currentResult[i] - previousResult[i]) > epsilon)
                {
                    hasConverged = false;
                }
            }

            for (int i = 0; i < n; ++i)
            {
                previousResult[i] = currentResult[i];
            }

            iteration++;
        }

        if (!hasConverged)
        {
            Console.WriteLine("The simple iteration method did not converge in the given number of iterations");
        }

        Console.WriteLine($"Number of iterations: {iteration}");

        return currentResult;
    }

    private static bool IsDiagonallyDominant(MyMatrix matrix)
    {
        int n = matrix.getRowSize();

        for (int i = 0; i < n; i++)
        {
            double rowSum = 0;

            for (int j = 0; j < n; j++)
            {
                if (i != j)
                {
                    rowSum += Math.Abs(matrix.getDataMatrix()[i][j]);
                }
            }

            if (Math.Abs(matrix.getDataMatrix()[i][i]) <= rowSum)
            {
                return false;
            }
        }

        return true;
    }

    private static MyMatrix CreateNewMatrix(MyMatrix matrix)
    {
        int n = matrix.getRowSize();
        int m = matrix.getColomnSize();

        MyMatrix result = new MyMatrix(n, m);

        for (int i = 0; i < n; ++i)
        {
            double diagonalElement = matrix.getDataMatrix()[i][i];
            for (int j = 0; j < m; ++j)
            {
                if (i != j)
                {
                    result.getDataMatrix()[i][j] = matrix.getDataMatrix()[i][j] / diagonalElement;
                }
                else
                {
                    result.getDataMatrix()[i][j] = 0;
                }
            }
        }

        return result;
    }

    private static bool CheckConvergenceCondition(MyMatrix alpha)
    {
        var listData = alpha.getDataMatrix();

        int rows = listData.Count;
        int cols = listData[0].Count;
        double[,] arrayData = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                arrayData[i, j] = listData[i][j];
            }
        }

        var alphaMatrix = DenseMatrix.OfArray(arrayData);
        double alphaNorm = alphaMatrix.InfinityNorm();

        Console.WriteLine($"Norm of alpha matrix: {alphaNorm}");

        return alphaNorm < 1;
    }

    private static List<double> SimpleIterationMethod(MyMatrix alpha, MyMatrix beta, double epsilon)
    {
        if (!CheckQuadraticMatrix(alpha) || !CheckIterationCondition(alpha))
        {
            throw new ArithmeticException("The conditions for calculating the matrix are not met");
        }

        int n = alpha.getRowSize();
        List<double> prevResult = new List<double>(new double[n]);
        List<double> newResult = new List<double>(new double[n]);

        for (var i = 0; i < beta.getRowSize(); ++i)
        {
            prevResult[i] = beta.getVectorD()[i];
        }

        int maxIterations = 1000;
        int iteration = 0;
        bool checkConv = false;

        while (!checkConv && iteration < maxIterations)
        {
            checkConv = true;

            for (int i = 0; i < n; ++i)
            {
                double sum = 0;

                for (int j = 0; j < n; ++j)
                {
                    if (j != i)
                    {
                        sum += alpha.getDataMatrix()[i][j] * prevResult[j];
                    }
                }

                double newValue = (beta.getVectorD()[i] - sum) / alpha.getDataMatrix()[i][i];

                if (Math.Abs(newValue - prevResult[i]) > epsilon)
                {
                    checkConv = false;
                }

                newResult[i] = newValue;
            }

            for (int i = 0; i < n; i++)
            {
                prevResult[i] = newResult[i];
            }

            iteration++;
        }

        if (iteration == maxIterations)
        {
            Console.WriteLine("The simple iteration method did not converge in the given number of iterations");
        }

        Console.WriteLine($"Number of iterations: {iteration}");

        return newResult;
    }

    public static void MainFunction()
    {
        string filename1 = "/Users/oduvanchik/NumericalMethods/FilesForLabs/ThirdMatrix.txt";
        MyMatrix matrix = new MyMatrix();
        matrix.ReadMatrixFromFile(filename1);
        MyMatrix cloneMatrix = matrix.DeepCope();

        cloneMatrix = CreateNewMatrix(cloneMatrix);

        string filename2 = "/Users/oduvanchik/NumericalMethods/FilesForLabs/ThirdVector.txt";
        MyMatrix vector = new MyMatrix();
        vector.ReadDFromFile(filename2);

        if (!IsDiagonallyDominant(matrix))
        {
            throw new ArithmeticException("Did not pass the test for the diagonal predominance of the matrix");
        }

        if (!CheckConvergenceCondition(cloneMatrix))
        {
            throw new ArithmeticException("The conditions for calculating the matrix are not met");
        }

        Console.WriteLine("Please enter epsilon: ");
        string input = Console.ReadLine();

        double epsilon;
        double.TryParse(input, out epsilon);

        // Method Seidel

        List<double> result1 = SeidelMethod(matrix, vector, epsilon);
        Console.WriteLine($"Result method simple iteration: {string.Join(", ", result1)}");

        // Method Simple Iterations

        List<double> result2 = SimpleIterationMethod(matrix, vector, epsilon);
        Console.WriteLine($"Result method simple iteration: {string.Join(", ", result2)}");
    }
}