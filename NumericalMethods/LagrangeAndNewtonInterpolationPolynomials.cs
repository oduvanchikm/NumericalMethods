namespace NumericalMethods;

public class LagrangeAndNewtonInterpolationPolynomials
{
    private static double Function(double x) => Math.Asin(x);
    
    private static double LagrangePolynomial(double[] xValues, double[] yValues, double x)
    {
        int n = xValues.Length;
        double result = 0.0;

        for (int i = 0; i < n; i++)
        {
            double term = yValues[i];
            for (int j = 0; j < n; j++)
            {
                if (i != j)
                {
                    term *= (x - xValues[j]) / (xValues[i] - xValues[j]);
                }
            }
            result += term;
        }

        return result;
    }

    private static double CalculateW(double xi, double[] xValues)
    {
        double result = 1.0;

        foreach (var x in xValues)
        {
            if (xi != x)
            {
                result *= (xi - x);
            }
        }

        return result;
    }

    private static void WritePolynomialLagrange(double[] xValues, double[] dividedFiWxiArray)
    {
        Console.WriteLine("L(x) = ");
    
        for (int i = 0; i < xValues.Length; i++)
        {
            Console.Write($"   {dividedFiWxiArray[i]:F4}");
        
            for (int j = 0; j < xValues.Length; j++)
            {
                if (j != i)
                {
                    Console.Write($" * (x - {xValues[j]:F2})");
                }
            }
        
            if (i < xValues.Length - 1)
            {
                Console.Write(" + ");
            }
        }
    
        Console.WriteLine();
    }

    private static void CreateTableLagrange(double[] xValues, double[] yValues, double x)
    {
        double[] dividedFiWxiArray = new double[4];
        
        Console.WriteLine("-----------------------------------------------------------------------------------------");
        Console.WriteLine("                        Lagrange Polynomial Function");
        Console.WriteLine("-----------------------------------------------------------------------------------------");
        Console.WriteLine("  i   |      x_i     |     f_i     |      w(x_i)      |      f_i / w(x_i)     |    X - xi   ");
        Console.WriteLine("-----------------------------------------------------------------------------------------");
        for (int i = 0; i < xValues.Length; i++)
        {
            double xi = xValues[i];
            double fi = yValues[i];
            double wxi = CalculateW(xi, xValues);
            double dividedFiWxi = fi / wxi;
            dividedFiWxiArray[i] = dividedFiWxi;
            double xMinusXi = x - xi;

            Console.WriteLine($"  {i}   |    {xi,6:F2}    |   {fi,6:F2}    |   {wxi,10:F4}     |   {dividedFiWxi,15:F4}     |   {xMinusXi,6:F2}   ");
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------");
        
        WritePolynomialLagrange(xValues, dividedFiWxiArray);
    }
    
    private static double[,] DividedDifferenceTable(double[] x, double[] y)
    {
        int n = x.Length;
        double[,] table = new double[n, n];
        
        for (int i = 0; i < n; i++)
        {
            table[i, 0] = y[i];
        }

        for (int j = 1; j < n; j++)
        {
            for (int i = 0; i < n - j; i++)
            {
                table[i, j] = (table[i + 1, j - 1] - table[i, j - 1]) / (x[i + j] - x[i]);
            }
        }

        return table;
    }

    private static double NewtonPolynomial(double[] x, double[] y, double value)
    {
        int n = x.Length;
        double[,] table = DividedDifferenceTable(x, y);

        double result = table[0, 0];
        double product = 1.0;

        for (int i = 1; i < n; i++)
        {
            product *= (value - x[i - 1]);
            result += table[0, i] * product;
        }

        return result;
    }
    
    private static double FirstColumn(double[] f, double[] x, int i)
    {
        return (f[i + 1] - f[i]) / (x[i + 1] - x[i]);
    }

    private static double SecondColumn(double[] f, double[] x, int i)
    {
        double f_i1_i2 = FirstColumn(f, x, i + 1);
        double f_i_i1 = FirstColumn(f, x, i);
        return (f_i1_i2 - f_i_i1) / (x[i + 2] - x[i]);
    }

    private static double ThirdColumn(double[] f, double[] x)
    {
        double second1 = SecondColumn(f, x, 1);
        double second0 = SecondColumn(f, x, 0);
        return (second1 - second0) / (x[3] - x[0]);
    }

    private static void WritePolynomialNewton(double[] xValues, double[] dividedFiWxiArray)
    {
        Console.Write($"P(x) = {dividedFiWxiArray[0]:F4}");
        
        for (int i = 1; i < dividedFiWxiArray.Length; i++)
        {
            Console.Write(" + " + $"{dividedFiWxiArray[i]:F4}");

            for (int j = 0; j < i; j++)
            {
                Console.Write($"(x - {xValues[j]:F2})");
            }
        }
        Console.WriteLine();
    }

    private static void CreateTableNewton(double[] xValues, double[] yValues, double x)
    {
        double[] dividedFiWxiArray = new double[4]; 
        dividedFiWxiArray[0] = yValues[0];
        dividedFiWxiArray[1] = FirstColumn(yValues, xValues, 0); 
        dividedFiWxiArray[2] = SecondColumn(yValues, xValues, 0); 
        dividedFiWxiArray[3] = ThirdColumn(yValues, xValues);

        Console.WriteLine("-----------------------------------------------------------------------------------------");
        Console.WriteLine("                        Таблица разделенных разностей Ньютона");
        Console.WriteLine("-----------------------------------------------------------------------------------------");
        Console.WriteLine("  i   |      x_i     |     f_i     |    f(x_i,x_i+1)   |  f(x_i,x_i+1,x_i+2) | f(x_i,x_i+1,x_i+2,x_i+3)");
        Console.WriteLine("-----------------------------------------------------------------------------------------");
        for (int i = 0; i < xValues.Length; i++)
        {
            double xi = xValues[i];
            double fi = yValues[i];

            string firstCol = i < xValues.Length - 1 ? $"{FirstColumn(yValues, xValues, i):F4}" : "";
            string secondCol = i < xValues.Length - 2 ? $"{SecondColumn(yValues, xValues, i):F4}" : "";
            string thirdCol = i < xValues.Length - 3 ? $"{ThirdColumn(yValues, xValues):F4}" : "";

            Console.WriteLine($"  {i}   |    {xi,6:F2}    |   {fi,6:F2}    |  {firstCol,12}  |  {secondCol,12}  |  {thirdCol,12}  ");
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------");

        WritePolynomialNewton(xValues, dividedFiWxiArray);
    }


    public static void MainFunction()
    {
        // Lagrange Polynomial
        
        double[] xValues1 = { -0.4, -0.1, 0.2, 0.5 };

        double[] yValues1 = { Function(-0.4), Function(-0.1), Function(0.2), Function(0.5) };

        for (int i = 0; i < yValues1.Length; i++)
        {
            Console.WriteLine($"{xValues1[i]}, {yValues1[i]}");
        }
        
        CreateTableLagrange(xValues1, yValues1, 0.1);
        double result1 = LagrangePolynomial(xValues1, yValues1, 0.1);
        Console.WriteLine($"Result in 0.1: {result1}");
        double lnResult1 = Function(0.1);
        Console.WriteLine($"Result ln in 0.1: {lnResult1}");
        Console.WriteLine($"Difference between result and ln result in 0.1: {Math.Abs(lnResult1) - Math.Abs(result1)}");
        
        // Newton Polynomial
        
        double[] xValues2 = { -0.4, 0, 0.2, 0.5 };

        double[] yValues2 = { Function(-0.4), Function(0), Function(0.2), Function(0.5) };

        for (int i = 0; i < yValues1.Length; i++)
        {
            Console.WriteLine($"{xValues1[i]}, {yValues1[i]}");
        }
        
        CreateTableNewton(xValues2, yValues2, 0.1);
        
        double result2 = NewtonPolynomial(xValues2, yValues2, 0.1);
        Console.WriteLine($"Result in 0.1: {result2}");
        double lnResult2 = Function(0.1);
        Console.WriteLine($"Result ln in 0.1: {lnResult2}");
        Console.WriteLine($"Difference between result and ln result in 0.1: {Math.Abs(lnResult2) - Math.Abs(result2)}");
        
    }
}
