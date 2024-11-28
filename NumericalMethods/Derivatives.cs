namespace NumericalMethods;

public class Derivatives
{
    private static (double, double, double, double) CalculateDerivatives(List<(double, double)> points, double x)
    {
        int index = 0;
        for (int i = 1; i < points.Count - 2; i++)
        {
            if (points[i].Item1 <= x && x <= points[i + 1].Item1)
            {
                index = i;
                break;
            }
        }

        double leftHandedDerivative = (points[index + 1].Item2 - points[index].Item2) /
                                      (points[index + 1].Item1 - points[index].Item1);
        double rightHandedDerivative = (points[index + 2].Item2 - points[index + 1].Item2) /
                                       (points[index + 2].Item1 - points[index + 1].Item1);
        double firstDer = leftHandedDerivative +
                          ((rightHandedDerivative - leftHandedDerivative) /
                           (points[index + 2].Item1 - points[index].Item1)) *
                          (2.0 * x - points[index].Item1 - points[index + 1].Item1);
        double secondDer = 2.0 * (rightHandedDerivative - leftHandedDerivative) /
                           (points[index + 2].Item1 - points[index].Item1);

        return (leftHandedDerivative, rightHandedDerivative, firstDer, secondDer);
    }

    public static void MainFunction()
    {
        double[] xValues = { -1.0, 0.0, 1.0, 2.0, 3.0 };
        double[] yValues = { -0.7854, 0.0, 0.7854, 1.1071, 1.249 };

        List<(double, double)> inputPoints = new List<(double, double)>();
        for (int i = 0; i < xValues.Length; i++)
        {
            inputPoints.Add((xValues[i], yValues[i]));
        }

        double xToEvaluate = 1.0;

        var derivatives = CalculateDerivatives(inputPoints, xToEvaluate);

        Console.WriteLine($"Left-handed derivative: {derivatives.Item1}");
        Console.WriteLine($"Right-handed derivative: {derivatives.Item2}");
        Console.WriteLine($"First derivative: {derivatives.Item3}");
        Console.WriteLine($"Second derivative: {derivatives.Item4}");
        
        Console.WriteLine($"Check: {(derivatives.Item1 + derivatives.Item2) / 2}");
    }
}