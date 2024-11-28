namespace CourseWork;

public class OutputResult
{
    public static void OutputResultForH()
    {
        Func<double, double>[] functionArray = new Func<double, double>[]
        {
            x => 1,
            x => Math.Log(x),
            x => 1 / (x * x),
            x => 1 / x,
            x => x,
            x => x * x,
            x => x * x * x
        };

        double[] temperatureResultValuesH2 = ThermodynamicProperties.GetTemperatureValuesH2();

        double[] phiValuesForElement =
            temperatureResultValuesH2.Select(temp => ThermodynamicProperties.GetPhiValuesForTemperatureH2(temp))
                .ToArray();

        double[] transformedTemperatures =
            temperatureResultValuesH2.Select(t => t * (1 / (Math.Pow(10.0, 4)))).ToArray();

        double[] polynomialCoefficients =
            LeastSquareMethod.LSMethod(transformedTemperatures, phiValuesForElement, functionArray);
        Console.WriteLine("The transformed polynomial coefficients are:");
        Console.WriteLine(string.Join(", ", polynomialCoefficients));

        double[] phiPracticalResultH2 =
            temperatureResultValuesH2.Select(temp => FindCoefficients.FindPhiCoefficients(polynomialCoefficients, temp))
                .ToArray();
        double[] phiTheoreticalResultH2 = ThermodynamicProperties.GetPhiValuesH2();

        double[] gPracticalResultH2 = FindCoefficients.FindGCoefficients(polynomialCoefficients, temperatureResultValuesH2);

        double[] sPracticalResultH2 = FindCoefficients.FindSCoefficients(gPracticalResultH2, temperatureResultValuesH2);
        double[] sTheoreticalResultH2 = ThermodynamicProperties.GetSValuesH2().ToArray();

        // double[] hPracticalResultH2 = FindCoefficients.FindHCoefficients(gPracticalResultH2, temperatureResultValuesH2);
        double[] hPracticalResultH2 = FindCoefficients.FindHCoefficients(gPracticalResultH2, temperatureResultValuesH2, sPracticalResultH2);
        double[] hTheoreticalResultH2 = ThermodynamicProperties.GetHValuesH2().ToArray();

        double[] cpPracticalResultH2 = FindCoefficients.FindCpCoefficients(hPracticalResultH2, temperatureResultValuesH2);
        double[] cpTheoreticalResultH2 = ThermodynamicProperties.GetCpValuesH2().ToArray();

        CreateTableGForH2InFile(temperatureResultValuesH2, gPracticalResultH2);
        CreateTableCpForH2InFile(temperatureResultValuesH2, cpTheoreticalResultH2, cpPracticalResultH2);
        CreateTablePhiForH2InFile(temperatureResultValuesH2, phiTheoreticalResultH2, phiPracticalResultH2);
        CreateTableSForH2InFile(temperatureResultValuesH2, sTheoreticalResultH2, sPracticalResultH2);
        CreateTableHForH2InFile(temperatureResultValuesH2, hTheoreticalResultH2, hPracticalResultH2);
    }
    
    private static void CreateTableGForH2InFile(double[] temperatureResultValuesH2, double[] gPracticalResultH2)
    {
        using (StreamWriter writer =
               new StreamWriter("/Users/oduvanchik/CourseWorkNumMethods/CourseWork/output_results_H2.txt", append: true))
        {
            writer.WriteLine("".PadLeft(20) + "H2" + "".PadLeft(20));
            writer.WriteLine("".PadLeft(20) + "G" + "".PadLeft(20));
            writer.WriteLine(new string('-', 65));

            writer.WriteLine("{0,-15} | {1,-20} ", "Temperature (K)", "Practical G");
            writer.WriteLine(new string('-', 65));

            for (int i = 0; i < temperatureResultValuesH2.Length - 1; i++)
            {
                writer.WriteLine("{0,-15:F2} | {1,-20:F4} ",
                    temperatureResultValuesH2[i],
                    gPracticalResultH2[i]);
            }

            writer.WriteLine(new string('-', 65));
        }
    }

    private static void CreateTableCpForH2InFile(double[] temperatureResultValuesH2,
        double[] cpTheoreticalResultH2,
        double[] cpPracticalResultH2)
    {
        using (StreamWriter writer =
               new StreamWriter("/Users/oduvanchik/CourseWorkNumMethods/CourseWork/output_results_H2.txt", append: true))
        {
            writer.WriteLine("".PadLeft(20) + "Cp" + "".PadLeft(20));
            writer.WriteLine(new string('-', 65));

            writer.WriteLine("{0,-15} | {1,-20} | {2,-20}", "Temperature (K)", "Cp Result", "Practical Cp");
            writer.WriteLine(new string('-', 65));

            for (int i = 0; i < temperatureResultValuesH2.Length - 1; i++)
            {
                writer.WriteLine("{0,-15:F2} | {1,-20:F4} | {2,-20:F4}",
                    temperatureResultValuesH2[i],
                    cpTheoreticalResultH2[i],
                    cpPracticalResultH2[i]);
            }

            writer.WriteLine(new string('-', 65));
        }
    }

    private static void CreateTablePhiForH2InFile(double[] temperatureResultValuesH2,
        double[] phiTheoreticalResultH2,
        double[] phiPracticalResultH2)
    {
        using (StreamWriter writer =
               new StreamWriter("/Users/oduvanchik/CourseWorkNumMethods/CourseWork/output_results_H2.txt", append: true))
        {
            writer.WriteLine("".PadLeft(20) + "Phi" + "".PadLeft(20));
            writer.WriteLine(new string('-', 65));

            writer.WriteLine("{0,-15} | {1,-20} | {2,-20}", "Temperature (K)", "Phi Result", "Practical Phi");
            writer.WriteLine(new string('-', 65));

            for (int i = 0; i < temperatureResultValuesH2.Length - 1; i++)
            {
                writer.WriteLine("{0,-15:F2} | {1,-20:F4} | {2,-20:F4}",
                    temperatureResultValuesH2[i],
                    phiTheoreticalResultH2[i],
                    phiPracticalResultH2[i]);
            }

            writer.WriteLine(new string('-', 65));
        }
    }
    
    private static void CreateTableSForH2InFile(double[] temperatureResultValuesH2,
        double[] sTheoreticalResultH2,
        double[] sPracticalResultH2)
    {
        using (StreamWriter writer =
               new StreamWriter("/Users/oduvanchik/CourseWorkNumMethods/CourseWork/output_results_H2.txt", append: true))
        {
            writer.WriteLine("".PadLeft(20) + "S" + "".PadLeft(20));
            writer.WriteLine(new string('-', 65));

            writer.WriteLine("{0,-15} | {1,-20} | {2,-20}", "Temperature (K)", "S Result", "Practical S");
            writer.WriteLine(new string('-', 65));

            for (int i = 0; i < temperatureResultValuesH2.Length - 1; i++)
            {
                writer.WriteLine("{0,-15:F2} | {1,-20:F4} | {2,-20:F4}",
                    temperatureResultValuesH2[i],
                    sTheoreticalResultH2[i],
                    sPracticalResultH2[i]);
            }
            writer.WriteLine(new string('-', 65));
        }
    }
    
    private static void CreateTableHForH2InFile(double[] temperatureResultValuesH2,
        double[] hTheoreticalResultH2,
        double[] hPracticalResultH2)
    {
        using (StreamWriter writer =
               new StreamWriter("/Users/oduvanchik/CourseWorkNumMethods/CourseWork/output_results_H2.txt", append: true))
        {
            writer.WriteLine("".PadLeft(20) + "H" + "".PadLeft(20));
            writer.WriteLine(new string('-', 65));

            writer.WriteLine("{0,-15} | {1,-20} | {2,-20}", "Temperature (K)", "H Result", "Practical H");
            writer.WriteLine(new string('-', 65));

            for (int i = 0; i < temperatureResultValuesH2.Length - 1; i++)
            {
                writer.WriteLine("{0,-15:F2} | {1,-20:F4} | {2,-20:F4}",
                    temperatureResultValuesH2[i],
                    hTheoreticalResultH2[i],
                    hPracticalResultH2[i]);
            }
            writer.WriteLine(new string('-', 65));
        }
    }
}