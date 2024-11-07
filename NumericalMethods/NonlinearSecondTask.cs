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
    
    private static double DPhi1_Dx(double x, double y) => 0;
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
        int numSamples = 1000;
        double stepY = (b2 - a2) / numSamples;
        double maxDPhi1_Dy = 0;
        
        for (int i = 0; i <= numSamples; i++)
        {
            double y = a2 + i * stepY;

            if (Math.Abs(y) > b1)
            {
                continue;
            } 
        
            double currentDPhi1_Dy = Math.Abs(DPhi1_Dy(a1, y));
            if (currentDPhi1_Dy > maxDPhi1_Dy)
            {
                maxDPhi1_Dy = currentDPhi1_Dy;
            }
        }
        double maxDPhi2_Dx = Math.Abs(DPhi2_Dx(a1, a2));
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
    
        Console.WriteLine($"Value of q: {q}");

        if (q >= 1)
        {
            throw new ArgumentException("Условие сходимости должно выполняться: q < 1");
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
                throw new InvalidOperationException("Произошла ошибка во время итерации: " + ex.Message);
            }

            iterations++;

            if (iterations > maxIterations)
            {
                throw new InvalidOperationException($"Метод не сошелся за {maxIterations} итераций.");
            }

        }
        while ((q / (1 - q)) * Math.Max(Math.Abs(x - xPrev), Math.Abs(y - yPrev)) > epsilon);

        return (x, y, iterations);
    }

    
    public static void MainFunction()
    {
        double initialX1 = 1.0;
        double initialY1 = 1.0;
        double a1 = 0, b1 = 3; 
        double a2 = 0, b2 = 2; 
        double epsilon = 0.001;

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

        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}
