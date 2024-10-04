using System.ComponentModel;
using MatrixLibrary;
using System;
using System.Collections.Generic;

namespace MethodOfSimpleIterationsAndSeidel
{
    internal class MethodSimpleIterationsAndSeidel
    {
        static private bool CheckQuadraticMatrix(Matrix matrix)
        {
            int row = matrix.getRowSize();
            int column = matrix.getColomnSize();

            if (row != column)
            {
                return false;
            }

            return true;
        }

        static private bool CheckIterationCondition(Matrix matrix)
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

        static public List<double> SeidelMethod(Matrix alpha, Matrix beta, double epsilon)
        {
            if (!CheckQuadraticMatrix(alpha))
            {
                throw new WarningException("The matrix must be square.");
            }

            int n = alpha.getRowSize();
            List<double> currentResult = new List<double>(new double[n]);
            List<double> previousResult = new List<double>(new double[n]);

            for (var i = 0; i < beta.getRowSize(); ++i)
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
                        if (i != j)
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

                for (int i = 0; i < n; i++)
                {
                    previousResult[i] = currentResult[i];
                }

                iteration++;
            }

            if (iteration == maxIterations)
            {
                Console.WriteLine("The simple iteration method did not converge in the given number of iterations");
            }

            Console.WriteLine($"Number of iterations: {iteration}");

            return currentResult;
        }
        
        static bool IsDiagonallyDominant(Matrix matrix)
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

        static public List<double> SimpleIterationMethod(Matrix matrix, Matrix vector, double epsilon)
        {
            if (!CheckQuadraticMatrix(matrix) || !CheckIterationCondition(matrix))
            {
                throw new WarningException("The conditions for calculating the matrix are not met");
            }

            int n = matrix.getRowSize();
            List<double> prevResult = new List<double>(new double[n]);
            List<double> newResult = new List<double>(new double[n]);

            int maxIterations = 1000;
            int iteration = 0;
            bool checkConv = false;

            while (!checkConv && iteration < maxIterations)
            {
                checkConv = true;

                for (int i = 0; i < n; ++i)
                {
                    newResult[i] = vector.getVectorD()[i];
                    for (int j = 0; j < n; ++j)
                    {
                        if (j != i)
                        {
                            newResult[i] -= matrix.getDataMatrix()[i][j] * prevResult[j];
                        }
                    }

                    newResult[i] /= matrix.getDataMatrix()[i][i];

                    if (Math.Abs(newResult[i] - prevResult[i]) > epsilon)
                    {
                        checkConv = false;
                    }

                    Console.WriteLine("x" + (i + 1) + " = " + newResult[i]);
                }

                for (int i = 0; i < n; i++)
                {
                    prevResult[i] = newResult[i];
                }

                iteration++;
            }

            if (iteration == maxIterations)
            {
                Console.WriteLine("The simple iteration method did not converge in a given number of iterations");
            }

            Console.WriteLine($"Number of iterations: {iteration}");

            return newResult;
        }

        public static void MainFunction()
        {
            string filename1 = "/Users/oduvanchik/NumericMethodsLabs/lab1/MatrixFiles/ThirdMatrix.txt";
            Matrix matrix = new Matrix();
            matrix.ReadMatrixFromFile(filename1);

            string filename2 = "/Users/oduvanchik/NumericMethodsLabs/lab1/MatrixFiles/ThirdVector.txt";
            Matrix vector = new Matrix();
            vector.ReadDFromFile(filename2);

            if (!IsDiagonallyDominant(matrix))
            {
                throw new ArithmeticException("Did not pass the test for the diagonal predominance of the matrix");
            }

            Console.WriteLine("Please enter epsilon: ");
            string input = Console.ReadLine();

            double epsilon;
            if (double.TryParse(input, out epsilon))
            {
                Console.WriteLine("Epsilon entered: " + epsilon);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");


                // Method Sendel

                List<double> result1 = SeidelMethod(matrix, vector, epsilon);
                Console.WriteLine($"Result method simple iteration: {string.Join(", ", result1)}");

                // Method Simple Iterations

                List<double> result2 = SimpleIterationMethod(matrix, vector, epsilon);
                Console.WriteLine($"Result method simple iteration: {string.Join(", ", result2)}");
            }
        }
    }
}