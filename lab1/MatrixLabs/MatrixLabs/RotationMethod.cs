using MatrixLibrary;
using System;

namespace SolveRotationMethod
{
    class RotationMethodJacobi
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
        
        private static (int, int, double) FindMaxOffDiagonalElement(MyMatrix matrix)
        {
            int n = matrix.getRowSize();
            int p = 0, q = 1;
            double maxNotDiagonalElement = Math.Abs(matrix.getDataMatrix()[p][q]);

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double currentElement = Math.Abs(matrix.getDataMatrix()[i][j]);
                    if (currentElement > maxNotDiagonalElement)
                    {
                        maxNotDiagonalElement = currentElement;
                        p = i;
                        q = j;
                    }
                }
            }

            return (p, q, maxNotDiagonalElement);
        }

        private static void JacobiEigenvalueAlgorithm(MyMatrix matrix, double eps)
        {
            int n = matrix.getRowSize();
            MyMatrix eigenvectorsMatrix = IdentityMatrix(n, n);

            bool isDoneProgram = false;
            
            while (!isDoneProgram)
            {
                var (p, q, maxNotDiagonalElement) = FindMaxOffDiagonalElement(matrix);
                
                if (maxNotDiagonalElement < eps)
                {
                    isDoneProgram = true;
                }
                else
                {
                    double phi = 0.5 * Math.Atan(2 * matrix.getDataMatrix()[p][q] / (matrix.getDataMatrix()[p][p] - matrix.getDataMatrix()[q][q]));
                    MyMatrix uMatrix = SetMatrixDataForJacobiMethod(p, q, Math.Sin(phi), Math.Cos(phi), n);
                    matrix = uMatrix.Transpose() * matrix * uMatrix;
                    eigenvectorsMatrix *= uMatrix;
                }
            }

            Console.WriteLine("Eigenvalue Result:");
            for (int i = 0; i < matrix.getRowSize(); i++)
            {
                Console.WriteLine(matrix.getDataMatrix()[i][i]);
            }

            Console.WriteLine("Eigenvectors Result:");
            for (int i = 0; i < eigenvectorsMatrix.getRowSize(); i++)
            {
                Console.WriteLine("Vector:");
                for (int j = 0; j < eigenvectorsMatrix.getRowSize(); j++)
                {
                    Console.WriteLine((eigenvectorsMatrix.getDataMatrix()[j][i]));
                }
            }

            for (int i = 0; i < eigenvectorsMatrix.getRowSize(); i++)
            {
                for (int j = i + 1; j < eigenvectorsMatrix.getRowSize(); j++)
                {
                    double dotProduct = 0;

                    for (int k = 0; k < eigenvectorsMatrix.getRowSize(); k++)
                    {
                        dotProduct += eigenvectorsMatrix.getDataMatrix()[i][k] * eigenvectorsMatrix.getDataMatrix()[j][k];
                    }

                    Console.WriteLine($"Dot product: {dotProduct}");
                }
            }
        }
        
        public static void MainFunction()
        {
            const string filename1 = "/Users/oduvanchik/NumericMethodsLabs/lab1/MatrixFiles/FourthMatrix.txt";
            MyMatrix matrix = new MyMatrix();
            matrix.ReadMatrixFromFile(filename1);

            if (!CheckSymmetricMatrix(matrix))
            {
                throw new Exception("The matrix is not symmetric");
            }

            double eps = 0.3;
            JacobiEigenvalueAlgorithm(matrix, eps);
        }
    }
}
