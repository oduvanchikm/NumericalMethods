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

    public static double[] FindGCoefficientsH2(double[] coefficients, double[] T)
    {
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
    
    public static double[] FindGCoefficientsH2O(double[] coefficients, double[] T)
    {
        int n = T.Length;
        double[] result = new double[n];

        for (int i = 0; i < n; i++)
        {
            var thermoData = ThermodynamicProperties.GetHValuesForTemperatureH2O(T[i]);
            double phiValue = FindPhiCoefficients(coefficients, T[i]);
            result[i] = 917.764 - thermoData - T[i] * phiValue;
        }

        return result;
    }
    
    public static double[] FindGCoefficientsO2(double[] coefficients, double[] T)
    {
        int n = T.Length;
        double[] result = new double[n];

        for (int i = 0; i < n; i++)
        {
            var thermoData = ThermodynamicProperties.GetHValuesForTemperatureO2(T[i]);
            double phiValue = FindPhiCoefficients(coefficients, T[i]);
            result[i] = 493.566 - thermoData - T[i] * phiValue;
        }

        return result;
    }
    
    public static double[] FindGCoefficientsOH(double[] coefficients, double[] T)
    {
        int n = T.Length;
        double[] result = new double[n];

        for (int i = 0; i < n; i++)
        {
            var thermoData = ThermodynamicProperties.GetHValuesForTemperatureOH(T[i]);
            double phiValue = FindPhiCoefficients(coefficients, T[i]);
            result[i] = 423.720 - thermoData - T[i] * phiValue;
        }

        return result;
    }
    
    public static double[] FindGCoefficientsH(double[] coefficients, double[] T)
    {
        int n = T.Length;
        double[] result = new double[n];

        for (int i = 0; i < n; i++)
        {
            var thermoData = ThermodynamicProperties.GetHValuesForTemperatureH(T[i]);
            double phiValue = FindPhiCoefficients(coefficients, T[i]);
            result[i] = -619.6395 - thermoData - T[i] * phiValue;
        }

        return result;
    }
    
    public static double[] FindGCoefficientsO(double[] coefficients, double[] T)
    {
        int n = T.Length;
        double[] result = new double[n];

        for (int i = 0; i < n; i++)
        {
            var thermoData = ThermodynamicProperties.GetHValuesForTemperatureO(T[i]);
            double phiValue = FindPhiCoefficients(coefficients, T[i]);
            result[i] = -586.37 - thermoData - T[i] * phiValue;
        }

        return result;
    }

    // -dG/dT
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

    // g + ts or second dG/dT
    public static double[] FindHCoefficients(double[] G, double[] T)
    {
        if (G.Length != T.Length)
        {
            Console.WriteLine("G and T must be the same length");
        }
    
        int n = T.Length;
        double[] dG_dT = new double[n];
        for (int i = 0; i < n - 1; i++)
        {
            dG_dT[i] = (G[i + 1] - G[i]) / (T[i + 1] - T[i]);
        }
        
        double[] result = new double[dG_dT.Length];
    
        for (int i = 0; i < n - 1; i++)
        {
            result[i] = G[i] - T[i] * dG_dT[i];
        }
        
        return result;
    }
    
    // dH/dT
    public static double[] FindCpCoefficients(double[] H, double[] T)
    {
        int n = T.Length;
        double[] dHdT = new double[n];
    
        for (int i = 1; i < n - 1; i++)
        {
            dHdT[i] = (H[i + 1] - H[i - 1]) / (T[i + 1] - T[i - 1]);
        }
    
        dHdT[0] = (H[1] - H[0]) / (T[1] - T[0]);
        dHdT[n - 1] = (H[n - 1] - H[n - 2]) / (T[n - 1] - T[n - 2]);
        
        return dHdT;
    }
}
