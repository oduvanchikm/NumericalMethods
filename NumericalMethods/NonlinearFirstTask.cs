namespace NumericalMethods;
using System.Globalization;

public class NonlinearFirstTask
{
    private static double Function(double x) => Math.Log(x + 1) - 2 * x * x + 1;
    
    private static double DerivativeOfFunction(double x) => 1.0 / (x + 1) - 4 * x;
    
    private static double SecondDerivativeOfFunction(double x) => -1 / (x + 1) * (x + 1) - 4;
    
    private static double PhiFunction(double x) => Math.Sqrt((Math.Log(x + 1) + 1) / 2);
    
    private static double DerivativeOfPhiFunction(double x) => 1 / (2 * Math.Sqrt(2) * (x + 1) * Math.Sqrt(Math.Log(x + 1) + 1));

    private static double FindPrevResult(double firstBoundary, double secondBoundary)
    {
        double previousX;

        if (Function(firstBoundary) * SecondDerivativeOfFunction(firstBoundary) > 0)
        {
            previousX = firstBoundary;
        }
        else if (Function(secondBoundary) * SecondDerivativeOfFunction(secondBoundary) > 0)
        {
            previousX = secondBoundary;
        }
        else
        {
            previousX = (firstBoundary + secondBoundary) / 2;
        }

        return previousX;
    }

    private static void CheckDiffSign(double firstBoundary, double secondBoundary)
    {
        if (Function(firstBoundary) * Function(secondBoundary) > 0)
        {
            throw new ArithmeticException("No root found in the provided interval.");
        }
    }

    private static void CheckFunctions(double firstBoundary, double secondBoundary)
    {
        if (DerivativeOfFunction(firstBoundary) == 0 || SecondDerivativeOfFunction(firstBoundary) == 0 ||
            DerivativeOfFunction(secondBoundary) == 0 || SecondDerivativeOfFunction(secondBoundary) == 0)
        {
            throw new ArithmeticException("Derivative of functions are not compatible");
        }
    }

    private static double DichotomyMethod(double firstBoundary, double secondBoundary, double epsilon)
    {
        CheckDiffSign(firstBoundary, secondBoundary);

        double middle = firstBoundary;

        while ((secondBoundary - firstBoundary) / 2 > epsilon)
        {
            middle = (firstBoundary + secondBoundary) / 2;

            if (Math.Abs(Function(middle)) < epsilon)
            {
                return middle;
            }

            if (Function(firstBoundary) * Function(middle) < 0)
            {
                secondBoundary = middle;
            }
            else
            {
                firstBoundary = middle;
            }
        }

        return (firstBoundary + secondBoundary) / 2;
    }

    private static double NewtonMethod(double firstBoundary, double secondBoundary, double epsilon)
    {
        CheckDiffSign(firstBoundary, secondBoundary);
        CheckFunctions(firstBoundary, secondBoundary);

        double previousX = FindPrevResult(firstBoundary, secondBoundary);
        double currentX = previousX - Function(previousX) / DerivativeOfFunction(previousX);

        while (Math.Abs(currentX - previousX) >= epsilon)
        {
            previousX = currentX;

            double derivativeValue = DerivativeOfFunction(previousX);

            if (Math.Abs(derivativeValue) < epsilon)
            {
                throw new ArithmeticException("Derivative is too close to zero, may lead to divergence");
            }

            currentX = previousX - Function(previousX) / derivativeValue;
        }

        return currentX;
    }

    private static double SimpleIterationMethod(double firstBoundary, double secondBoundary, double epsilon)
    {
        CheckDiffSign(firstBoundary, secondBoundary);

        double previousX = (firstBoundary + secondBoundary) / 2.0;
        double nextX = PhiFunction(previousX);
        double q = Math.Abs(DerivativeOfPhiFunction(nextX));

        while (q / (1 - q) * Math.Abs(nextX - previousX) > epsilon)
        {
            q = Math.Abs(DerivativeOfPhiFunction(nextX));

            if (q >= 1)
            {
                throw new ArithmeticException("q >= 1");
            }

            previousX = nextX;
            nextX = PhiFunction(previousX);
        }

        return nextX;
    }

    private static double SecantMethod(double firstBoundary, double secondBoundary, double epsilon)
    {
        CheckDiffSign(firstBoundary, secondBoundary);

        double previousX = FindPrevResult(firstBoundary, secondBoundary);
        double x = previousX + epsilon;
        double nextX = x - Function(x) * (x - previousX) / (Function(x) - Function(previousX));

        while (Math.Abs(nextX - x) >= epsilon)
        {
            previousX = x;
            x = nextX;

            nextX = x - Function(x) * (x - previousX) / (Function(x) - Function(previousX));

            if (Math.Abs(nextX - x) < epsilon)
            {
                break;
            }
        }

        return nextX;
    }

    public static void MainFunction()
    {
        double epsilon = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        // ln(x + 1) => x + 1 > 0 => x > -1

        Console.WriteLine(
            "-------------------------------------Dichotomy Method---------------------------------------------");
        double root1 = DichotomyMethod(0.8, 1, epsilon);
        Console.WriteLine($"First root: {root1}");
        double root2 = DichotomyMethod(-0.5, 0, epsilon);
        Console.WriteLine($"Second root: {root2}");
        Console.WriteLine(
            "----------------------------------------Newton Method---------------------------------------------");
        double root3 = NewtonMethod(0.8, 1, epsilon);
        Console.WriteLine($"First root: {root3}");
        double root4 = NewtonMethod(-0.99, -0.2, epsilon);
        Console.WriteLine($"Second root: {root4}");
        Console.WriteLine(
            "----------------------------------Simple Iteration Method-----------------------------------------");
        double root5 = SimpleIterationMethod(0.8, 1, epsilon);
        Console.WriteLine($"First root: {root5}");
        double root6 = SimpleIterationMethod(-0.99, -0.2, epsilon);
        Console.WriteLine($"Second root: {root6}");
        Console.WriteLine(
            "---------------------------------------Secant Method----------------------------------------------");
        double root7 = SecantMethod(0.8, 1, epsilon);
        Console.WriteLine($"First root: {root7}");
        double root8 = SecantMethod(-0.5, 0, epsilon);
        Console.WriteLine($"Second root: {root8}");
    }
}
