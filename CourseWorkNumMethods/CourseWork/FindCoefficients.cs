namespace CourseWork;

public class FindCoefficients
{
    public static double FindPhiCoefficients(double[] coefficients, double temperature)
    {
        double temperatureNew = temperature / Math.Pow(10, 4);

        return coefficients[0] + coefficients[1] * Math.Log(temperatureNew)
                               + coefficients[2] * Math.Pow(temperatureNew, -2)
                               + coefficients[3] * Math.Pow(temperatureNew, -1)
                               + coefficients[4] * temperatureNew
                               + coefficients[5] * Math.Pow(temperatureNew, 2)
                               + coefficients[6] * Math.Pow(temperatureNew, 3);
    }

    public static double[] FindGCoefficients(double[] coefficients, double[] T)
    {
        // Console.WriteLine("11111The transformed polynomial coefficients are:");
        // Console.WriteLine(string.Join(", ", coefficients));

        int n = T.Length;
        double[] result = new double[n];

        for (int i = 0; i < n; i++)
        {
            var thermoData = ThermodynamicProperties.GetHValuesForTemperatureH2(T[i]);
            double phiValue = FindPhiCoefficients(coefficients, T[i]);
            result[i] = 432.068 - thermoData - T[i] * phiValue;
        }

        return result;
    }

    public static double[] FindSCoefficients(double[] G, double[] T)
    {
        if (G.Length != T.Length)
        {
            Console.WriteLine("G and T must be the same length");
        }

        int n = T.Length;
        double[] dGdT = new double[n];
        for (int i = 0; i < n - 1; i++)
        {
            dGdT[i] = -((G[i + 1] - G[i]) / (T[i + 1] - T[i]));
        }

        return dGdT;
    }

    // public static double[] FindHCoefficients(double[] G, double[] T)
    // {
    //     if (G.Length != T.Length)
    //     {
    //         Console.WriteLine("G and T must be the same length");
    //     }
    //
    //     int n = T.Length;
    //     double[] dG_dT = new double[n];
    //     for (int i = 0; i < n - 1; i++)
    //     {
    //         dG_dT[i] = (G[i + 1] - G[i]) / (T[i + 1] - T[i]);
    //     }
    //     
    //     double[] result = new double[dG_dT.Length];
    //
    //     for (int i = 0; i < n - 1; i++)
    //     {
    //         result[i] = G[i] - T[i] * dG_dT[i];
    //     }
    //     
    //     return result;
    // }
    // g + ts
    public static double[] FindHCoefficients(double[] G, double[] T, double[] S)
    {
        if (G.Length != T.Length)
        {
            Console.WriteLine("G and T must be the same length");
        }
        
        double[] result = new double[T.Length];

        for (int i = 0; i < T.Length; i++)
        {
            result[i] = G[i] + T[i] * S[i];
        }
        
        return result;
    }
    
    public static double[] FindCpCoefficients(double[] H, double[] T)
    {
        if (H.Length != T.Length)
        {
            Console.WriteLine("H and T must be the same length");
        }
        
        int n = T.Length;
        double[] dHdT = new double[n];
        for (int i = 0; i < n - 1; i++)
        {
            dHdT[i] = (H[i + 1] - H[i]) / (T[i + 1] - T[i]);
        }
        
        return dHdT;
    }
}