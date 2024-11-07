using static NumericalMethods.GaussMethod;
using MathNet.Numerics.LinearAlgebra;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace NumericalMethods;

public class LeastSquareMethod
{
    private static double[] LSMethodFirstPower(double[] x, double[] y)
    {
        int n = x.Length;
        double sumXElements = x.Sum();
        double sumYElements = y.Sum();
        double sumX2Elements = x.Select(v => v * v).Sum();
        double sumXYElements = x.Zip(y, (xi, yi) => xi * yi).Sum();

        double a1 = (n * sumXYElements - sumXElements * sumYElements) /
                    (n * sumX2Elements - sumXElements * sumXElements);
        double a0 = (sumYElements - a1 * sumXElements) / n;

        return new double[] { a0, a1 };
    }

    private static double SumSquaredErrorsFirst(double[] xResult, double[] x, double[] y)
    {
        double result = 0;

        double[] functionF = new double[x.Length];

        for (int i = 0; i < x.Length; i++)
        {
            functionF[i] = xResult[1] * x[i] + xResult[0];
        }

        for (int i = 0; i < x.Length; i++)
        {
            result += Math.Pow((functionF[i] - y[i]), 2);
        }

        return result;
    }

    private static double[] LSMethodSecondPower(double[] x, double[] y)
    {
        int n = x.Length;
        double sumX = x.Sum();
        double sumY = y.Sum();
        double sumX2 = x.Select(v => v * v).Sum();
        double sumX3 = x.Select(v => v * v * v).Sum();
        double sumX4 = x.Select(v => v * v * v * v).Sum();
        double sumXY = x.Zip(y, (xi, yi) => xi * yi).Sum();
        double sumX2Y = x.Zip(y, (xi, yi) => xi * xi * yi).Sum();

        var matrixA = new double[,]
        {
            { n, sumX, sumX2 },
            { sumX, sumX2, sumX3 },
            { sumX2, sumX3, sumX4 }
        };

        var vectorB = new double[] { sumY, sumXY, sumX2Y };
        var coefficients = SolveLinearSystem(matrixA, vectorB);

        return coefficients;
    }

    private static double[] SolveLinearSystem(double[,] matrix, double[] vector)
    {
        int n = vector.Length;
        double[] result = new double[n];

        var augmentedMatrix = new double[n, n + 1];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                augmentedMatrix[i, j] = matrix[i, j];
            }

            augmentedMatrix[i, n] = vector[i];
        }

        for (int i = 0; i < n; i++)
        {
            for (int k = i + 1; k < n; k++)
            {
                if (Math.Abs(augmentedMatrix[k, i]) > Math.Abs(augmentedMatrix[i, i]))
                {
                    for (int j = 0; j <= n; j++)
                    {
                        var temp = augmentedMatrix[i, j];
                        augmentedMatrix[i, j] = augmentedMatrix[k, j];
                        augmentedMatrix[k, j] = temp;
                    }
                }
            }

            for (int k = i + 1; k < n; k++)
            {
                double factor = augmentedMatrix[k, i] / augmentedMatrix[i, i];
                for (int j = i; j <= n; j++)
                {
                    augmentedMatrix[k, j] -= factor * augmentedMatrix[i, j];
                }
            }
        }

        for (int i = n - 1; i >= 0; i--)
        {
            result[i] = augmentedMatrix[i, n];
            for (int j = i + 1; j < n; j++)
            {
                result[i] -= augmentedMatrix[i, j] * result[j];
            }

            result[i] /= augmentedMatrix[i, i];
        }

        return result;
    }
    
    private static double SumSquaredErrorsSecond(double[] xResult, double[] x, double[] y)
    {
        double result = 0;

        double[] functionF = new double[x.Length];

        for (int i = 0; i < x.Length; i++)
        {
            functionF[i] = xResult[2] * x[i] * x[i] + xResult[1] * x[i] + xResult[0];
        }

        for (int i = 0; i < x.Length; i++)
        {
            result += Math.Pow((functionF[i] - y[i]), 2);
        }

        return result;
    }


    public static void MainFunction()
    {
        double[] xValues = { 0.0, 1.7, 3.4, 5.1, 6.8, 8.5 };
        double[] yValues = { 0.0, 1.3038, 1.8439, 2.2583, 2.6077, 2.9155 };

        double[] resultX1 = LSMethodFirstPower(xValues, yValues);
        Console.WriteLine("Solving a system of equations:");
        for (int i = 0; i < resultX1.Length; i++)
        {
            Console.WriteLine(resultX1[i]);
        }

        Console.WriteLine("----------------------------------------------------------------------------------");
        Console.WriteLine($"A polynomial of the 1st degree: {resultX1[1]}x + {resultX1[0]}");
        Console.WriteLine("----------------------------------------------------------------------------------");
        Console.WriteLine($"Sum of squared errors: {SumSquaredErrorsFirst(resultX1, xValues, yValues)}");
        Console.WriteLine("----------------------------------------------------------------------------------");
        
        double[] resultX2 = LSMethodSecondPower(xValues, yValues);
        Console.WriteLine("Solving a system of equations:");
        for (int i = 0; i < resultX2.Length; i++)
        {
            Console.WriteLine(resultX2[i]);
        }
        Console.WriteLine("----------------------------------------------------------------------------------");
        Console.WriteLine($"A polynomial of the 1st degree: {resultX2[2]}x^2 + {resultX2[1]}x + {resultX2[0]}");
        Console.WriteLine("----------------------------------------------------------------------------------");
        Console.WriteLine($"Sum of squared errors: {SumSquaredErrorsSecond(resultX2, xValues, yValues)}");
        Console.WriteLine("----------------------------------------------------------------------------------");
    }
}
