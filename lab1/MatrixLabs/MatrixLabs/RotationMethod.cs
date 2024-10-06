using MatrixLibrary;
using System.Collections.Generic;
using System;

namespace SolveRotationMethod
{
    class RotationMethod
    {
        private static void PrintMatrix(Matrix matrix)
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

        private static void PrintCurrentMatrixState(Matrix matrix)
        {
            Console.WriteLine("Current state of matrix: ");
            PrintMatrix(matrix);
            Console.WriteLine();
        }

        private static bool CheckSymmetricMatrix(Matrix matrix)
        {
            Matrix matrixTranspose = matrix.Transpose();
            return (matrix == matrixTranspose);
        }

        private static double FindMaxNotDiagonalElements(Matrix matrix, ref int row, ref int col, ref double sum)
        {
            double maxValue = 0;
            var n = matrix.getRowSize();
            var dataMatrix = matrix.getDataMatrix();
            sum = 0;
        
            for (var i = 0; i < n; ++i)
            {
                for (var j = i + 1; j < n; ++j)
                {
                    sum += (dataMatrix[i][j] * dataMatrix[i][j]);
                    
                    if (Math.Abs(dataMatrix[i][j]) > maxValue)
                    {
                        maxValue = Math.Abs(dataMatrix[i][j]);
                        row = i;
                        col = j;
                    }
                }
            }
        
            return maxValue;
        }
        
        private static Matrix MakeIdentity(Matrix matrix)
        {
            int row = matrix.getRowSize();
            int column = matrix.getColomnSize();
        
            if (row != column)
            {
                throw new InvalidOperationException("Matrix must be square");
            }
        
            Matrix newMatrix = new Matrix(row, column);
            var dataMatrix = newMatrix.getDataMatrix();
        
            for (int i = 0; i < row; ++i)
            {
                dataMatrix[i][i] = 1;
            }
        
            return newMatrix;
        }
        
        private static Matrix SetMatrixDataForJacobiMethod(Matrix matrix, double sin, double cos, int p, int q)
        {
            Matrix newMatrix = MakeIdentity(matrix);
            newMatrix.setDataMatrix(p, p, cos);
            newMatrix.setDataMatrix(p, q, -sin);
            newMatrix.setDataMatrix(q, p, sin);
            newMatrix.setDataMatrix(q, q, cos);
            return newMatrix;
        }

        private static void JacobiEigenvalueMethod(Matrix matrix, out List<double> eigenvalues,
            out List<List<double>> eigenvectors, double epsilon, out int countIterations)
        { 
            var n = matrix.getRowSize();
            eigenvalues = new List<double>();
            eigenvectors = new List<List<double>>();

            var dataMatrix = matrix.getDataMatrix();
            int p = 0;
            int q = 0;
            double sum = 0;

            Matrix eigenvectorMatrix = MakeIdentity(matrix);
            double maxNotDiagonalElement = FindMaxNotDiagonalElements(matrix, ref p, ref q, ref sum);
            countIterations = 0;

            while (double.Sqrt(sum) > epsilon)
            {
                double phi = (dataMatrix[p][p] == dataMatrix[q][q])
                    ? Math.PI / 4
                    : 0.5 * Math.Atan(2 * dataMatrix[p][q]) / (dataMatrix[p][p] - dataMatrix[q][q]);
                Matrix u = SetMatrixDataForJacobiMethod(matrix, Math.Sin(phi), Math.Cos(phi), p, q);
                Matrix middleM = u.Transpose() * matrix;
                matrix = middleM * u;
                eigenvectorMatrix = eigenvectorMatrix * u;
                maxNotDiagonalElement = FindMaxNotDiagonalElements(matrix, ref p, ref q, ref sum);
                countIterations++;
            }

            for (int i = 0; i < n; ++i)
            {
                eigenvalues.Add(matrix.getDataMatrix()[i][i]);
            }

            var eigenvectorData = eigenvectorMatrix.getDataMatrix();


            for (int i = 0; i < n; ++i)
            {
                List<double> eigenvector = new List<double>();

                for (int j = 0; j < n; ++j)
                {
                    eigenvector.Add(eigenvectorData[j][i]);
                }

                eigenvectors.Add(eigenvector);
            }

            // Console.WriteLine("Matrix U final");
            // PrintCurrentMatrixState(eigenvectorMatrix);
        }

        public static void MainFunction()
        {
            const string filename1 = "/Users/oduvanchik/NumericMethodsLabs/lab1/MatrixFiles/FourthMatrix.txt";
            Matrix matrix4 = new Matrix();
            matrix4.ReadMatrixFromFile(filename1);

            if (!CheckSymmetricMatrix(matrix4))
            {
                throw new Exception("The matrix is not symmetric");
            }

            double epsilon = 0.3;
            JacobiEigenvalueMethod(matrix4, out List<double> eigenvalues, out List<List<double>> eigenvectors,
                epsilon, out int countIterations);

            Console.WriteLine($"Count of iterations: {countIterations}");

            for (int i = 0; i < eigenvalues.Count; ++i)
            {
                Console.Write("Eigenvalue: " + eigenvalues[i] + "; Eigenvector: [");

                for (int j = 0; j < eigenvectors[i].Count; ++j)
                {
                    Console.Write(eigenvectors[i][j]);
                    if (j < eigenvectors[i].Count - 1)
                    {
                        Console.Write(", ");
                    }
                }

                Console.WriteLine("]");
            }
        }
    }
}
