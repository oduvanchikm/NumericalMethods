namespace NumericalMethods;

public class CauchysTask
{
    private static double Function(double x, double y, double z)
        => -4 * x * z + (3 - 4 * x * x) * y + Math.Exp(x * x);

    private static double Solution(double x)
        => (Math.Exp(x) + Math.Exp(-x) - 1) * Math.Exp(x * x);

    private static void EulerMethodRungeRomberg(double[] xValues, double[] yValues, double[] zValues, double h)
    {
        Console.WriteLine("Euler Method");
        Console.WriteLine($"{"Step",-5} {"x",-10} {"y_h",-15} {"y_h/2",-15} {"Error",-15} {"z",-15} {"result",-15}");
        Console.WriteLine(new string('-', 95));

        int n = xValues.Length;
        double[] xValuesHalfStep = new double[2 * n - 1];
        double[] yValuesHalfStep = new double[2 * n - 1];
        double[] zValuesHalfStep = new double[2 * n - 1];

        xValuesHalfStep[0] = xValues[0];
        yValuesHalfStep[0] = yValues[0];
        zValuesHalfStep[0] = zValues[0];

        Console.WriteLine(
            $"{0,-5} {xValues[0],-10:F2} {yValues[0],-15:F6} {"-",15} {"-",15} {zValues[0],-15:F6} {Solution(xValues[0]),-15:F6}");

        for (var i = 1; i < xValues.Length; i++)
        {
            double xPrev = xValues[i - 1];
            double yPrev = yValues[i - 1];
            double zPrev = zValues[i - 1];

            yValues[i] = yPrev + h * zPrev;
            zValues[i] = zPrev + h * Function(xPrev, yPrev, zPrev);
            xValues[i] = xPrev + h;
        }

        double halfStep = h / 2.0;
        for (var i = 1; i < xValuesHalfStep.Length; i++)
        {
            double xPrev = xValuesHalfStep[i - 1];
            double yPrev = yValuesHalfStep[i - 1];
            double zPrev = zValuesHalfStep[i - 1];

            yValuesHalfStep[i] = yPrev + halfStep * zPrev;
            zValuesHalfStep[i] = zPrev + halfStep * Function(xPrev, yPrev, zPrev);
            xValuesHalfStep[i] = xPrev + halfStep;
        }

        for (var i = 1; i < xValues.Length; i++)
        {
            var yH = yValues[i];
            var yH2 = yValuesHalfStep[2 * i];

            double error = Math.Abs((yH2 - yH) / (Math.Pow(2, 2) - 1));

            Console.WriteLine(
                $"{i,-5} {xValues[i],-10:F2} {yH,-15:F6} {yH2,-15:F6} {error,-15:0.############} {zValues[i],-15:F6} {Solution(xValues[i]),-15:F6}");
        }
    }

    private static void RungeKuttaMethod(double[] xValues, double[] yValues, double[] zValues, double h)
    {
        Console.WriteLine();
        Console.WriteLine("Runge Kutta Method");
        Console.WriteLine($"{"Step",-5} {"x",-10} {"y_h",-15} {"y_h/2",-15} {"Error",-15} {"z",-15} {"result",-15}");
        Console.WriteLine(new string('-', 100));

        int xValuesSize = xValues.Length;

        Console.WriteLine(
            $"{0,-5} {xValues[0],-10:F2} {yValues[0],-15:F6} {"-",15} {"-",15} {zValues[0],-15:F6} {Solution(xValues[0]),-15:F6}");

        for (var i = 1; i < xValuesSize; ++i)
        {
            double x = xValues[i - 1];
            double y = yValues[i - 1];
            double z = zValues[i - 1];

            double k1_y = h * z;
            double L1_z = h * Function(x, y, z);

            double k2_y = h * (z + 0.5 * L1_z);
            double L2_z = h * Function(x + 0.5 * h, y + 0.5 * k1_y, z + 0.5 * L1_z);

            double k3_y = h * (z + 0.5 * L2_z);
            double L3_z = h * Function(x + 0.5 * h, y + 0.5 * k2_y, z + 0.5 * L2_z);

            double k4_y = h * (z + L3_z);
            double L4_z = h * Function(x + h, y + k3_y, z + L3_z);

            double y_h = y + (k1_y + 2 * k2_y + 2 * k3_y + k4_y) / 6.0;
            double z_h = z + (L1_z + 2 * L2_z + 2 * L3_z + L4_z) / 6.0;

            double x_h = x + h;

            double h2 = h / 2.0;
            double y_halfStep1 = y;
            double z_halfStep1 = z;

            k1_y = h2 * z_halfStep1;
            L1_z = h2 * Function(x, y_halfStep1, z_halfStep1);

            k2_y = h2 * (z_halfStep1 + 0.5 * L1_z);
            L2_z = h2 * Function(x + 0.5 * h2, y_halfStep1 + 0.5 * k1_y, z_halfStep1 + 0.5 * L1_z);

            k3_y = h2 * (z_halfStep1 + 0.5 * L2_z);
            L3_z = h2 * Function(x + 0.5 * h2, y_halfStep1 + 0.5 * k2_y, z_halfStep1 + 0.5 * L2_z);

            k4_y = h2 * (z_halfStep1 + L3_z);
            L4_z = h2 * Function(x + h2, y_halfStep1 + k3_y, z_halfStep1 + L3_z);

            double y_halfStep2 = y_halfStep1 + (k1_y + 2 * k2_y + 2 * k3_y + k4_y) / 6.0;
            double z_halfStep2 = z_halfStep1 + (L1_z + 2 * L2_z + 2 * L3_z + L4_z) / 6.0;

            x += h2;
            k1_y = h2 * z_halfStep2;
            L1_z = h2 * Function(x, y_halfStep2, z_halfStep2);

            k2_y = h2 * (z_halfStep2 + 0.5 * L1_z);
            L2_z = h2 * Function(x + 0.5 * h2, y_halfStep2 + 0.5 * k1_y, z_halfStep2 + 0.5 * L1_z);

            k3_y = h2 * (z_halfStep2 + 0.5 * L2_z);
            L3_z = h2 * Function(x + 0.5 * h2, y_halfStep2 + 0.5 * k2_y, z_halfStep2 + 0.5 * L2_z);

            k4_y = h2 * (z_halfStep2 + L3_z);
            L4_z = h2 * Function(x + h2, y_halfStep2 + k3_y, z_halfStep2 + L3_z);

            double y_h2 = y_halfStep2 + (k1_y + 2 * k2_y + 2 * k3_y + k4_y) / 6.0;

            double error = Math.Abs(y_h - y_h2) / (Math.Pow(2, 4) - 1);

            yValues[i] = y_h;
            zValues[i] = z_h;
            xValues[i] = x_h;

            Console.WriteLine(
                $"{i,-5} {xValues[i],-10:F2} {y_h,-15:F6} {y_h2,-15:F6} {error,-15:0.############} {zValues[i],-15:F6} {Solution(xValues[i]),-15:F6}");
        }
    }

    private static void AdamsMethod(double[] xValues, double[] yValues, double[] zValues, double h)
    {
        int xValuesSize = xValues.Length;

        if (xValuesSize < 4)
        {
            throw new ArgumentException("The array size should be at least 4 for the Adams method.");
        }

        Console.WriteLine("Adams Method");
        Console.WriteLine(
            $"{"Step",-5} {"x",-10} {"y_h",-15} {"y_h (corrected)",-20} {"Error",-15} {"z",-15} {"result",-15}");
        Console.WriteLine(new string('-', 95));

        Console.WriteLine(
            $"{0,-5} {xValues[0],-10:F2} {yValues[0],-15:F6} {"-",20} {"-",15} {zValues[0],-15:F6} {Solution(xValues[0]),-15:F6}");

        // Первые 4 шага методом Рунге-Кутта
        for (int i = 1; i < 4; ++i)
        {
            (xValues[i], yValues[i], zValues[i]) = RungeKuttaStep(
                xValues[i - 1], yValues[i - 1], zValues[i - 1], h
            );

            Console.WriteLine(
                $"{i,-5} {xValues[i],-10:F2} {yValues[i],-15:F6} {"-",-20} {"-",-15} {zValues[i],-15:F6} {"-",-15}"
            );
        }

        // Основной цикл метода Адамса
        for (int i = 4; i < xValuesSize; ++i)
        {
            double y_h = yValues[i - 1] + h * (
                55 * zValues[i - 1] - 59 * zValues[i - 2]
                + 37 * zValues[i - 3] - 9 * zValues[i - 4]
            ) / 24.0;

            double z_h = zValues[i - 1] + h * (
                55 * Function(xValues[i - 1], yValues[i - 1], zValues[i - 1])
                - 59 * Function(xValues[i - 2], yValues[i - 2], zValues[i - 2])
                + 37 * Function(xValues[i - 3], yValues[i - 3], zValues[i - 3])
                - 9 * Function(xValues[i - 4], yValues[i - 4], zValues[i - 4])
            ) / 24.0;

            double y_h_corrected = yValues[i - 1] + h * (
                9 * z_h + 19 * zValues[i - 1]
                - 5 * zValues[i - 2] + zValues[i - 3]
            ) / 24.0;

            double z_h_corrected = zValues[i - 1] + h * (
                9 * Function(xValues[i - 1] + h, y_h, z_h)
                + 19 * Function(xValues[i - 1], yValues[i - 1], zValues[i - 1])
                - 5 * Function(xValues[i - 2], yValues[i - 2], zValues[i - 2])
                + Function(xValues[i - 3], yValues[i - 3], zValues[i - 3])
            ) / 24.0;

            double error = Math.Abs(y_h_corrected - y_h) / (Math.Pow(2, 4) - 1);

            yValues[i] = y_h_corrected;
            zValues[i] = z_h_corrected;
            xValues[i] = xValues[i - 1] + h;

            Console.WriteLine(
                $"{i,-5} {xValues[i],-10:F2} {y_h,-15:F6} {y_h_corrected,-20:F6} {error,-15:0.############} {zValues[i],-15:F6} {Solution(xValues[i]),-15:F6}");
        }
    }

    private static (double x_next, double y_next, double z_next) RungeKuttaStep(
        double x, double y, double z, double h)
    {
        double k1_y = h * z;
        double L1_z = h * Function(x, y, z);

        double k2_y = h * (z + 0.5 * L1_z);
        double L2_z = h * Function(x + 0.5 * h, y + 0.5 * k1_y, z + 0.5 * L1_z);

        double k3_y = h * (z + 0.5 * L2_z);
        double L3_z = h * Function(x + 0.5 * h, y + 0.5 * k2_y, z + 0.5 * L2_z);

        double k4_y = h * (z + L3_z);
        double L4_z = h * Function(x + h, y + k3_y, z + L3_z);

        double y_next = y + (k1_y + 2 * k2_y + 2 * k3_y + k4_y) / 6.0;
        double z_next = z + (L1_z + 2 * L2_z + 2 * L3_z + L4_z) / 6.0;

        double x_next = x + h;

        return (x_next, y_next, z_next);
    }

    public static void MainFunction()
    {
        double x0 = 0.0;
        double xEnd = 1.0;
        double y0 = 1.0;
        double z0 = 0.0;
        double h = 0.1;
        int n = (int)((xEnd - x0) / h) + 1;

        double[] xEuler = new double[n];
        double[] yEuler = new double[n];
        double[] zEuler = new double[n];

        xEuler[0] = x0;
        yEuler[0] = y0;
        zEuler[0] = z0;

        double[] xRunge = new double[n];
        double[] yRunge = new double[n];
        double[] zRunge = new double[n];

        xRunge[0] = x0;
        yRunge[0] = y0;
        zRunge[0] = z0;

        double[] xAdams = new double[n];
        double[] yAdams = new double[n];
        double[] zAdams = new double[n];

        xAdams[0] = x0;
        yAdams[0] = y0;
        zAdams[0] = z0;

        EulerMethodRungeRomberg(xEuler, yEuler, zEuler, h);
        RungeKuttaMethod(xRunge, yRunge, zRunge, h);
        AdamsMethod(xAdams, yAdams, zAdams, h);
    }
}