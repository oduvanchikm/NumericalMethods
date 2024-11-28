namespace CourseWork;

public class LeastSquareMethod
{
    public static double[] LSMethod(double[] xArr, double[] yArr, Func<double, double>[] functionArray)
    {
        int n = xArr.Length;

        double[,] matrix = new double[functionArray.Length, functionArray.Length];
        double[] vector = new double[functionArray.Length];

        for (int i = 0; i < functionArray.Length; i++)
        {
            for (int j = 0; j < functionArray.Length; j++)
            {
                matrix[i, j] = CompositionX(xArr, functionArray[i], functionArray[j]);
            }

            vector[i] = CompositionY(xArr, yArr, functionArray[i]);
        }

        double[] coefficients = SolveLinearSystem(matrix, vector);
        return coefficients;
    }

    private static double CompositionY(double[] xArray, double[] yArray, Func<double, double> function)
    {
        double result = 0;
        for (int k = 0; k < xArray.Length; k++)
        {
            result += function(xArray[k]) * yArray[k];
        }

        return result;
    }

    private static double CompositionX(double[] xArray, Func<double, double> function1, Func<double, double> function2)
    {
        double result = 0;
        for (int k = 0; k < xArray.Length; k++)
        {
            result += function1(xArray[k]) * function2(xArray[k]);
        }

        return result;
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
}