using MathNet.Numerics.LinearAlgebra;

namespace NumericalMethods;

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

    private static (double x, double y, int iterations) NewtonMethod(double x, double y, double epsilon)
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
        
        return (x, y, iterations);
    }
    
    private static double GetQ(double a1, double b1, double a2, double b2)
    {
        double maxDPhi1_Dx = 0; 
        double maxDPhi1_Dy = Math.Max(
            Math.Abs(DPhi1_Dy(a1, a2)),
            Math.Max(Math.Abs(DPhi1_Dy(b1, a2)), Math.Max(Math.Abs(DPhi1_Dy(a1, b2)), Math.Abs(DPhi1_Dy(b1, b2))))
        );

        double maxDPhi2_Dx = Math.Max(
            Math.Abs(DPhi2_Dx(a1, a2)),
            Math.Max(Math.Abs(DPhi2_Dx(b1, a2)), Math.Max(Math.Abs(DPhi2_Dx(a1, b2)), Math.Abs(DPhi2_Dx(b1, b2))))
        );
        double maxDPhi2_Dy = 0; 

        double Q1 = maxDPhi1_Dx + maxDPhi1_Dy;
        double Q2 = maxDPhi2_Dx + maxDPhi2_Dy;

        return Math.Max(Q1, Q2);
    }

    
    private static (double x, double y, int iterations) SimpleIterationsMethod(
        double initialX, double initialY,
        double a1, double b1, double a2, double b2,
        double epsilon, int maxIterations = 1000)
    {
        double x = initialX;
        double y = initialY;
        double xPrev, yPrev;
        int iterations = 0;

        double q = GetQ(a1, b1, a2, b2);

        if (q >= 1)
        {
            throw new ArgumentException("Convergence condition must be satisfied: q < 1");
        }

        do
        {
            xPrev = x;
            yPrev = y;

            try
            {
                x = Phi1(xPrev, yPrev);
                y = Phi2(xPrev, yPrev);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred during iteration. " + ex.Message);
            }

            iterations++;

            if (iterations > maxIterations)
            {
                throw new InvalidOperationException($"Method did not converge within {maxIterations} iterations.");
            }

        }
        while ((q / (1 - q)) * Math.Max(Math.Abs(x - xPrev), Math.Abs(y - yPrev)) > epsilon);
        return (x, y, iterations);
    }

    
    public static void MainFunction()
    {
        double initialX1 = 1.0;
        double initialY1 = 1.0;
        double a1 = -5, b1 = 5; 
        double a2 = -5, b2 = 5; 
        double epsilon = 0.001;
        
        // double initialX2 = -1.0;
        // double initialY2 = -1.0;
        // double a3 = -5, b3 = 0; 
        // double a4 = -5, b4 = 0; 

        try
        {
            var (x1, y1, iterations1) = SimpleIterationsMethod(initialX1, initialY1, a1, b1, a2, b2, epsilon);
            Console.WriteLine($"Solution found in {iterations1} iterations:");
            Console.WriteLine($"x = {x1:F6}");
            Console.WriteLine($"y = {y1:F6}");
            
            var (x2, y2, iterations2) = NewtonMethod(initialX1, initialY1, epsilon);
            Console.WriteLine($"Solution found in {iterations2} iterations:");
            Console.WriteLine($"x = {x2:F6}");
            Console.WriteLine($"y = {y2:F6}");
            
            // var (x3, y3, iterations3) = SimpleIterationsMethod(initialX2, initialY2, a3, b3, a4, b4, epsilon);
            // Console.WriteLine($"Solution found in {iterations3} iterations:");
            // Console.WriteLine($"x = {x3:F6}");
            // Console.WriteLine($"y = {y3:F6}");
            //
            // var (x4, y4, iterations4) = NewtonMethod(initialX2, initialY2, epsilon);
            // Console.WriteLine($"Solution found in {iterations4} iterations:");
            // Console.WriteLine($"x = {x4:F6}");
            // Console.WriteLine($"y = {y4:F6}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}
