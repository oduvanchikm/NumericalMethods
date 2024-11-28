namespace NumericalMethods;

// методами треугольника, трапеции, Симпсона
public class Integral
{
    private static double Function(double x) => 1 / (x * x + 4);

    private static double SecondDerivativeFunction(double x)
    {
        // The first derivative: f'(x) = -2x / (x^2 + 4)^2
        // The second derivative: f''(x) = 8x^2 / (x^2 + 4)^3 - 2 / (x^2 + 4)^2
        double denominator = (x * x + 4);
        return (8 * x * x) / (denominator * denominator * denominator) - (2 / (denominator * denominator));
    }

    private static double ErrorEstimateRectangleMethod(double h, double a, double b)
    {
        double M2 = Math.Max(Math.Abs(SecondDerivativeFunction(a)), Math.Abs(SecondDerivativeFunction(b)));
        return (1.0 / 24.0) * Math.Pow(h, 2) * M2 * (b - a);
    }
    
    private static double RectangleMethod(double a, double b, double h)
    {
        double sum = 0.0;
        int n = (int)Math.Ceiling((b - a) / h);
        
        for (int i = 0; i < n; i++)
        {
            double xi = a + i * h;
            double midpoint = xi + h / 2;
            sum += Function(midpoint);
        }
        
        return sum * h;
    }
    
    private static double ErrorEstimateTrapezoidMethod(double h, double a, double b)
    {
        double M2 = Math.Max(Math.Abs(SecondDerivativeFunction(a)), Math.Abs(SecondDerivativeFunction(b)));
        return ((b - a) / 12.0) * h 
                                * h * M2;
    }
    
    private static double TrapezoidMethod(double a, double b, double h)
    {
        int n = (int)Math.Ceiling((b - a) / h);
        double sum = 0.5 * (Function(a) + Function(b));

        for (int i = 1; i < n; i++)
        {
            double xi = a + i * h;
            sum += Function(xi);
        }

        return sum * h;
    }

    
    private static double SimpsonMethod(double a, double b, double h)
    {
        int n = (int)Math.Ceiling((b - a) / h);
        if (n % 2 == 1) n++; 

        double sum = Function(a) + Function(b);

        for (int i = 1; i < n; i++)
        {
            double xi = a + i * h;
            sum += (i % 2 == 0 ? 2 : 4) * Function(xi);
        }

        return (h / 3.0) * sum;
    }

    private static double FourthDerivativeFunction(double x)
    {
        double denominator = Math.Pow(x * x + 4, 3);
        return (48 * (x * x - 4)) / denominator;
    }

    private static double ErrorEstimateSimpsonMethod(double h, double a, double b)
    {
        double M4 = Math.Max(Math.Abs(FourthDerivativeFunction(a)), Math.Abs(FourthDerivativeFunction(b)));
        return ((b - a) / 180.0) * h * h * h * h * M4;
    }


    private static void CreateTable(double h, double x0, double x1)
    {
        int numberOfSteps = (int)Math.Ceiling(Math.Abs(x1 - x0) / h);

        Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.WriteLine(" i |  xi  |  yi  |  The rectangle method  |  The trapezoid method  |  Simpson's method  ");
        Console.WriteLine("----------------------------------------------------------------------------------------");

        for (int i = 0; i <= numberOfSteps; i++)
        {
            double xi = x0 + i * h;
            if (xi > x1)
            {
                break;
            } 

            double yi = Function(xi);
            double rectangleValue = RectangleMethod(x0, xi, h);
            double trapezoidValue = TrapezoidMethod(x0, xi, h);
            double simpsonValue = SimpsonMethod(x0, xi, h);

            Console.WriteLine($" {i,-2} | {xi,5:F2} | {yi,5:F2} | {rectangleValue,20:F5} | {trapezoidValue,20:F5} | {simpsonValue,20:F5} ");
        }

        Console.WriteLine("----------------------------------------------------------------------------------------");
        
        double errorEstimate1 = ErrorEstimateRectangleMethod(h, x0, x1);
        Console.WriteLine($"Error estimate in rectangle method: {errorEstimate1:F5}");
        
        double errorEstimate2 = ErrorEstimateTrapezoidMethod(h, x0, x1);
        Console.WriteLine($"Error estimate in trapezoid method: {errorEstimate2:F5}");
        
        double errorEstimate3 = ErrorEstimateSimpsonMethod(h, x0, x1);
        Console.WriteLine($"Error estimate in Simpson's method: {errorEstimate3:F5}");
    }

    private static double RungeRomberg(double I_h1, double I_h2, double p, double h1, double h2)
    {
        double denominator = Math.Pow((h1 / h2), p) - 1.0;
        if (Math.Abs(denominator) < 1e-12)
        {
            throw new ArgumentException("Знаменатель слишком мал, возможна деление на ноль.");
        }
        return (I_h2 - I_h1) / denominator;
    }


    public static void MainFunction()
    {
        double h1 = 1.0;
        double h2 = 0.5;
        double x0 = -2.0;
        double x1 = 2.0;
        
        double rectangleValue1 = RectangleMethod(x0, x1, h1);
        double rectangleValue2 = RectangleMethod(x0, x1, h2);
        double rectangleRunge = RungeRomberg(rectangleValue1, rectangleValue2, p:1, h1, h2);
        
        Console.WriteLine($"Rectangle Method");
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine($"rectangleValue1 = {rectangleValue1}");
        Console.WriteLine($"rectangleValue2 = {rectangleValue2}");
        Console.WriteLine($"Runge Romberg = {rectangleRunge}");
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine();
        
        double trapezoidValue1 = TrapezoidMethod(x0, x1, h1);
        double trapezoidValue2 = TrapezoidMethod(x0, x1, h2);
        double trapezoidRunge = RungeRomberg(trapezoidValue1, trapezoidValue2, p:2, h1, h2);
        
        Console.WriteLine($"Trapezoid Method");
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine($"trapezoidValue1 = {trapezoidValue1}");
        Console.WriteLine($"trapezoidValue2 = {trapezoidValue2}");
        Console.WriteLine($"Runge Romberg = {trapezoidRunge}");
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine();
        
        double simpsonValue1 = SimpsonMethod(x0, x1, h1);
        double simpsonValue2 = SimpsonMethod(x0, x1, h2);
        double simpsonRunge = RungeRomberg(simpsonValue1, simpsonValue2, p:4, h1, h2);
        
        
        Console.WriteLine($"Simpson Method");
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine($"simpsonValue1 = {simpsonValue1}");
        Console.WriteLine($"simpsonValue2 = {simpsonValue2}");
        Console.WriteLine($"Runge Romberg = {simpsonRunge}");
        Console.WriteLine($"--------------------------------------------");
        Console.WriteLine();
        
        Console.WriteLine("First:");
        CreateTable(h1, x0, x1);
        
        Console.WriteLine("Second:");
        CreateTable(h2, x0, x1);
        
        Console.WriteLine("Result integral:");
    }
}