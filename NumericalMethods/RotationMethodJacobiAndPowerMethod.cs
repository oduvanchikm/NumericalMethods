namespace NumericalMethods;

public class RotationMethodJacobiAndPowerMethod
{
    private static void PrintMatrix(MyMatrix matrix)
    {
        var data = matrix.getDataMatrix();
        for (int i = 0; i < matrix.getRowSize(); ++i)
        {
            for (int j = 0; j < matrix.getColomnSize(); ++j)
            {
                Console.Write($"{data[i][j]} ");
            }

            Console.WriteLine();
        }
    }

    private static void PrintCurrentMatrixState(MyMatrix matrix)
    {
        Console.WriteLine("Current state of matrix: ");
        PrintMatrix(matrix);
        Console.WriteLine();
    }

    private static bool CheckSymmetricMatrix(MyMatrix matrix)
    {
        MyMatrix matrixTranspose = matrix;
        return (matrix == matrixTranspose);
    }

    private static MyMatrix IdentityMatrix(int n, int m)
    {
        MyMatrix matrix = new MyMatrix(n, m);
        for (int i = 0; i < n; i++)
        {
            matrix.getDataMatrix()[i][i] = 1;
        }

        return matrix;
    }

    private static MyMatrix SetMatrixDataForJacobiMethod(int p, int q, double sin, double cos, int n)
    {
        MyMatrix uMatrix = IdentityMatrix(n, n);
        uMatrix.getDataMatrix()[p][p] = cos;
        uMatrix.getDataMatrix()[q][q] = cos;
        uMatrix.getDataMatrix()[p][q] = -sin;
        uMatrix.getDataMatrix()[q][p] = sin;
        return uMatrix;
    }

    private static (int, int, double, double) FindMaxOffDiagonalElement(MyMatrix matrix)
    {
        int n = matrix.getRowSize();
        double sumElem = 0;
        int p = 0, q = 1;
        double maxNotDiagonalElement = Math.Abs(matrix.getDataMatrix()[p][q]);

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                sumElem += (matrix.getDataMatrix()[i][j] * matrix.getDataMatrix()[i][j]);
                double currentElement = Math.Abs(matrix.getDataMatrix()[i][j]);
                if (currentElement > maxNotDiagonalElement)
                {
                    maxNotDiagonalElement = currentElement;
                    p = i;
                    q = j;
                }
            }
        }

        return (p, q, maxNotDiagonalElement, sumElem);
    }

    private static void JacobiMethodAlgorithm(MyMatrix matrix, double eps)
    {
        int n = matrix.getRowSize();
        MyMatrix eigenvectorsMatrix = IdentityMatrix(n, n);

        bool isDoneProgram = false;

        while (!isDoneProgram)
        {
            var (p, q, maxNotDiagonalElement, sumElem) = FindMaxOffDiagonalElement(matrix);

            if (maxNotDiagonalElement < eps)
            {
                isDoneProgram = true;
            }
            else
            {
                double phi = (matrix.getDataMatrix()[p][p] == matrix.getDataMatrix()[q][q])
                    ? Math.PI / 4
                    : 0.5 * Math.Atan(2 * matrix.getDataMatrix()[p][q] /
                                      (matrix.getDataMatrix()[p][p] - matrix.getDataMatrix()[q][q]));
                MyMatrix uMatrix = SetMatrixDataForJacobiMethod(p, q, Math.Sin(phi), Math.Cos(phi), n);
                matrix = uMatrix.Transpose() * matrix * uMatrix;
                eigenvectorsMatrix *= uMatrix;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Eigenvalue Result:");
        for (int i = 0; i < matrix.getRowSize(); i++)
        {
            Console.WriteLine(matrix.getDataMatrix()[i][i]);
        }

        Console.WriteLine();

        Console.WriteLine("Eigenvectors Result:");
        for (int i = 0; i < eigenvectorsMatrix.getRowSize(); i++)
        {
            Console.WriteLine("Vector:");
            for (int j = 0; j < eigenvectorsMatrix.getRowSize(); j++)
            {
                Console.WriteLine((eigenvectorsMatrix.getDataMatrix()[j][i]));
            }
        }

        Console.WriteLine();

        for (int i = 0; i < eigenvectorsMatrix.getRowSize(); i++)
        {
            for (int j = i + 1; j < eigenvectorsMatrix.getRowSize(); j++)
            {
                double dotProduct = 0;
                double eqdotProduct = 0;

                for (int k = 0; k < eigenvectorsMatrix.getRowSize(); k++)
                {
                    dotProduct += eigenvectorsMatrix.getDataMatrix()[i][k] *
                                  eigenvectorsMatrix.getDataMatrix()[j][k];
                }

                // Console.WriteLine($"Dot product: {dotProduct}");

                eqdotProduct = Math.Abs(dotProduct) < eps ? 0 : Math.Round(dotProduct);
                Console.WriteLine($"Dot product: {eqdotProduct}");

                if (eqdotProduct == 0)
                {
                    Console.WriteLine("Eigenvalue Result is equal to zero");
                }
            }
        }
    }

    static double PowerMethod(int maxIterations, double tolerance, MyMatrix matrix)
    {
        int n = matrix.getRowSize();
        double[] b_k = new double[n];
        double[] b_k1 = new double[n];

        for (int i = 0; i < n; i++)
        {
            b_k[i] = 1;
        }

        double eigenvalue = 0;
        double prevEigenvalue = 0;
        int iteration = 0;

        while (iteration < maxIterations)
        {
            for (int i = 0; i < n; i++)
            {
                b_k1[i] = 0;
                for (int j = 0; j < n; j++)
                {
                    b_k1[i] += matrix.getDataMatrix()[i][j] * b_k[j];
                }
            }

            double norm = 0;
            for (int i = 0; i < n; i++)
            {
                norm += b_k1[i] * b_k1[i];
            }

            norm = Math.Sqrt(norm);

            for (int i = 0; i < n; i++)
            {
                b_k1[i] /= norm;
            }

            eigenvalue = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    eigenvalue += b_k1[i] * matrix.getDataMatrix()[i][j] * b_k1[j];
                }
            }

            if (Math.Abs(eigenvalue - prevEigenvalue) < tolerance)
            {
                return eigenvalue;
            }

            Array.Copy(b_k1, b_k, n);
            prevEigenvalue = eigenvalue;
            iteration++;
        }

        throw new Exception("The method did not converge within the specified number of iterations");
    }

    public static void MainFunction()
    {
        const string filename1 = "/Users/oduvanchik/NumericalMethods/FilesForLabs/FourthMatrix.txt";
        MyMatrix matrix1 = new MyMatrix();
        matrix1.ReadMatrixFromFile(filename1);

        if (!CheckSymmetricMatrix(matrix1))
        {
            throw new Exception("The matrix is not symmetric");
        }

        double eps = 0.3;

        double maxEigenvalue = PowerMethod(1000, eps, matrix1);
        Console.WriteLine($"Maximum eigenvalue: {maxEigenvalue}");

        // JacobiMethodAlgorithm(matrix1, eps);
    }
}