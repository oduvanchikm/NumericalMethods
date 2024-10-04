using MatrixLibrary;
using System;
using System.Collections.Generic;

namespace GaussMethodSolveMatrix
{
    class MatrixSolverGaussMethod
    {
        public static void PrintMatrix(Matrix matrix)
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

        public static void PrintCurrentMatrixState(Matrix matrix)
        {
            Console.WriteLine("Current state of matrix: ");
            PrintMatrix(matrix);
            Console.WriteLine();
        }

        public static Matrix AddMatrix(Matrix matrix, Matrix vector)
        {
            int matrixRow = matrix.getRowSize();
            int matrixColumn = matrix.getColomnSize();
            int vectorRow = vector.getRowSize();
            int vectorColumn = vector.getColomnSize();
            List<double> VectorNew = vector.getVectorD();

            if (vectorColumn != 1)
            {
                throw new InvalidOperationException("The vector must have exactly one column.");
            }

            if (matrixRow != vectorRow)
            {
                throw new InvalidOperationException("The number of rows must be the same for both matrices");
            }

            Matrix result = new Matrix(matrixRow, matrixColumn + vectorColumn);

            for (int i = 0; i < matrixRow; ++i)
            {
                for (int j = 0; j < matrixColumn; ++j)
                {
                    result.getDataMatrix()[i][j] = matrix.getDataMatrix()[i][j];
                }

                result.getDataMatrix()[i][matrixColumn] = VectorNew[i];
            }

            PrintCurrentMatrixState(result);

            return result;
        }

        public static Matrix GaussMakingTriangular(Matrix matrixFinal, out int SwapCount)
        {
            SwapCount = 0;

            var n = matrixFinal.getRowSize();
            var m = matrixFinal.getColomnSize();

            for (var i = 0; i < n; ++i)
            {
                (double leadingElem, int indexLeadingElem) = FindLeadingElement(matrixFinal);
                
                // Console.WriteLine($"Leading elements: { leadingElem }");

                // Console.WriteLine($"Step {i + 1}, replacing lines for the leading element: {leadingElem}");
                // PrintCurrentMatrixState(matrixFinal);
                
                if (indexLeadingElem != i)
                {
                    matrixFinal.SwapRows(matrixFinal,indexLeadingElem, 0);
                    SwapCount++;
                }

                // matrixFinal.SwapRows(matrixFinal, indexLeadingElem, 0);
                // SwapCount++;

                for (var j = i + 1; j < n; ++j)
                {
                    double factor = matrixFinal.getDataMatrix()[j][i] / matrixFinal.getDataMatrix()[i][i];
                    matrixFinal.getDataMatrix()[j][i] = 0;

                    for (var k = i + 1; k < m; ++k)
                    {
                        matrixFinal.getDataMatrix()[j][k] -= factor * matrixFinal.getDataMatrix()[i][k];
                    }
                }

                // Console.WriteLine($"Step {i + 1}, after zeroing out the lower elements:");
                // PrintCurrentMatrixState(matrixFinal);
            }

            return matrixFinal;
        }

        public static List<double> GaussReverse(Matrix matrix)
        {
            int n = matrix.getRowSize();
            List<double> resultVector = new List<double>(new double[n]);

            for (int i = n - 1; i >= 0; i--)
            {
                resultVector[i] = matrix.getDataMatrix()[i][n] / matrix.getDataMatrix()[i][i];

                for (int k = i - 1; k >= 0; k--)
                {
                    matrix.getDataMatrix()[k][n] -= matrix.getDataMatrix()[k][i] * resultVector[i];
                }
            }

            return resultVector;
        }

        private static (double, int) FindLeadingElement(Matrix matrix)
        {
            var n = matrix.getRowSize();
            int indexMaxElem = 0;
            double maxElem = double.MinValue;

            for (var i = 0; i < n; ++i)
            {
                double currentValue = matrix.getDataMatrix()[i][0];
                if (currentValue > maxElem)
                {
                    maxElem = currentValue;
                    indexMaxElem = i;
                }
            }

            return (maxElem, indexMaxElem);
        }

        public static double FindDeterminantMatrix(Matrix matrix)
        {
            int SwapCount;
            
            Matrix NewMatrix = GaussMakingTriangular(matrix, out SwapCount);
            
            int n = NewMatrix.getRowSize();
            double determinant = 1;

            for (int i = 0; i < n; i++)
            {
                determinant *= NewMatrix.getDataMatrix()[i][i];
            }

            if (SwapCount % 2 == 0)
            {
                determinant = -determinant;
            }
            
            return determinant;
        }

        public static bool CheckInverseMatrix(Matrix matrix, Matrix inverseMatrix)
        {
            
            Matrix resultMatrix = matrix * inverseMatrix;
            
            Console.WriteLine("Inverse matrix: ");
            PrintCurrentMatrixState(resultMatrix);

            return resultMatrix.IsIdentityMatrix();
            
        }

        public static void CheckResult(Matrix matrix, List<double> Vector)
        {
            List<double> resultVector = matrix * Vector;
            
            Console.WriteLine("Final check matrix * vector: ");
            for (int i = 0; i < resultVector.Count; ++i)
            {
                Console.WriteLine($"Result {i + 1}: " + string.Join(", ", Math.Round(resultVector[i], 6)));
            }
        }

        public static void MainFunction()
        {
            string filename1 = "/Users/oduvanchik/NumericMethodsLabs/lab1/MatrixFiles/FirstMatrix.txt";
            Matrix matrix2 = new Matrix();
            matrix2.ReadMatrixFromFile(filename1);

            Matrix cloneMatrix = matrix2.DeepCope();
            Matrix clone2Matrix = matrix2.DeepCope();
            Matrix clone3Matrix = matrix2.DeepCope();

            string filename2 = "/Users/oduvanchik/NumericMethodsLabs/lab1/MatrixFiles/FirstVector.txt";
            Matrix vector2 = new Matrix();
            vector2.ReadDFromFile(filename2);

            int SwapCount;

            Matrix matrixFinal = AddMatrix(matrix2, vector2);
            Matrix NewMatrix = GaussMakingTriangular(matrixFinal, out SwapCount);
            
            
            List<double> result = GaussReverse(NewMatrix);
            for (int i = 0; i < result.Count; ++i)
            {
                Console.WriteLine($"Result X{i + 1}: " + string.Join(", ", Math.Round(result[i], 6)));
            }
            
            Console.WriteLine("Last matrix 1: ");
            PrintCurrentMatrixState(matrix2);

            double resDet = FindDeterminantMatrix(matrix2);
            Console.WriteLine($"Determinant matrix: {resDet}");

            Matrix InverseMatrix = cloneMatrix.Inverse();

            Matrix newMatrix = clone2Matrix * InverseMatrix;
            
            Console.WriteLine("Result matrix inverse * matrix");
            PrintCurrentMatrixState(newMatrix);

            if (!CheckInverseMatrix(clone2Matrix, InverseMatrix))
            {
                throw new InvalidOperationException("Wrong data in inverse matrix");
            }
            
            Console.WriteLine("Inverse matrix: ");
            PrintCurrentMatrixState(InverseMatrix);
            
            CheckResult(clone3Matrix, result);
        }
    }
}