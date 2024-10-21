namespace NumericalMethods;
using System.Globalization;
using System;
using MathNet.Numerics.LinearAlgebra;

// x1^2 + x2^2 - 3^2 = 0
// x1 - e^x2 + 3 = 0

public class NonlinearSecondTask
{
    private static double F1(double x, double y) => x * x + y * y - 9;
    private static double F2(double x, double y) => x - Math.Exp(y) + 3;
    
    private static double DF1_Dx(double x, double y) => 2 * x;
    private static double DF1_Dy(double x, double y) => 2 * y;

    private static double DF2_Dx(double x, double y) => 1;
    private static double DF2_Dy(double x, double y) => -Math.Exp(y);
    
    private static double Phi1(double x, double y) => Math.Sqrt(9 - y * y);
    private static double Phi2(double x, double y) => Math.Log(x + 3);
    
    private static double DPhi1_Dx(double x, double y) => 1;
    private static double DPhi1_Dy(double x, double y) => -y / Math.Sqrt(9 - y * y);
    
    private static double DPhi2_Dx(double x, double y) => 1 / (x + 3);
    private static double DPhi2_Dy(double x, double y) => 0;
    
    private static Matrix<double> JacobiMatrix(double x, double y)
    {
        return Matrix<double>.Build.DenseOfArray(new double[,]
        {
            { DF1_Dx(x, y), DF1_Dy(x, y) },
            { DF2_Dx(x, y), DF2_Dy(x, y) }
        });
    }

    private static void NewtonMethod(double x, double y, double epsilon)
    {
        double xPrev, yPrev;
        int iterations = 0;

        do
        {
            xPrev = x;
            yPrev = y;
            
            var J = JacobiMatrix(x, y);
            var F = Vector<double>.Build.DenseOfArray(new double[]
            {
                F1(x, y),
                F2(x, y)
            });
            
            double det = J.Determinant();
            
            var JInverse = J.Inverse();
            var delta = JInverse * F;
            x = xPrev - delta[0];
            y = yPrev - delta[1];

            if (Math.Abs(det) < epsilon)
            {
                throw new ArgumentException("Det mustn't be < epsilon");
            }
            
            iterations++;
        }
        while (Math.Abs(x - xPrev) > epsilon || Math.Abs(y - yPrev) > epsilon);
        
        Console.WriteLine($"Newton Method: {iterations}");
        Console.WriteLine($"X: {x}, Y: {y}");
    }
    
    private static void SimpleIterationsMethod(double x, double y, double epsilon)
    {
        double xPrev, yPrev;
        int iterations = 0;
        
        double q1 = Math.Abs(DPhi1_Dx(x, y)) + Math.Abs(DPhi1_Dy(x, y));
        double q2 = Math.Abs(DPhi2_Dx(x, y)) + Math.Abs(DPhi2_Dy(x, y));
        
        double q = Math.Max(q1, q2);

        if (q >= 1)
        {
            throw new ArgumentException("q must be < 1");
        }

        do
        {
            xPrev = x;
            yPrev = y;
            
            x = Phi1(xPrev, yPrev);
            y = Phi2(xPrev, yPrev);
            
            iterations++;
        } 
        while (q / (1 - q) * Math.Max(Math.Abs(x - xPrev), Math.Abs(y - yPrev)) > epsilon);
        
        Console.WriteLine($"Simple iterations Method: {iterations}");
        Console.WriteLine($"X: {x}, Y: {y}");
    }
    
    public static void MainFunction()
    {
        var epsilon = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        
        NewtonMethod(-3, 0, epsilon);
        NewtonMethod(2.1, 2.6, epsilon);
        
        SimpleIterationsMethod(-3, 0, epsilon);
        SimpleIterationsMethod(2.1, 2.6, epsilon);
    }
}
