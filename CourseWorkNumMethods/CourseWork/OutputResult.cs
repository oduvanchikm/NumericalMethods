namespace CourseWork;

public class OutputResult
{
    public static void OutputResultForH2(Func<double, double>[] functionArray)
    {
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
            temperatureResultValuesH2
                .Select(temp => FindCoefficients.FindPhiCoefficients(polynomialCoefficients, temp))
                .ToArray();
        double[] phiTheoreticalResultH2 = ThermodynamicProperties.GetPhiValuesH2();

        double[] gPracticalResultH2 =
            FindCoefficients.FindGCoefficientsH2(polynomialCoefficients, temperatureResultValuesH2);

        double[] sPracticalResultH2 =
            FindCoefficients.FindSCoefficients(gPracticalResultH2, temperatureResultValuesH2);
        double[] sTheoreticalResultH2 = ThermodynamicProperties.GetSValuesH2().ToArray();

        // double[] hPracticalResultH2 =
        //     FindCoefficients.FindHCoefficients(gPracticalResultH2, temperatureResultValuesH2, sPracticalResultH2);
        double[] hPracticalResultH2 =
            FindCoefficients.FindHCoefficients(gPracticalResultH2, temperatureResultValuesH2);
        double[] hTheoreticalResultH2 = ThermodynamicProperties.GetHValuesH2().ToArray();

        double[] cpPracticalResultH2 =
            FindCoefficients.FindCpCoefficients(hPracticalResultH2, temperatureResultValuesH2);
        double[] cpTheoreticalResultH2 = ThermodynamicProperties.GetCpValuesH2().ToArray();

        string path = "/Users/oduvanchik/CourseWorkNumMethods/CourseWork/output_results_H2.txt";
        using (var fileStream = new FileStream(path, FileMode.Create))
        {
        }

        CreateTableGInFile(temperatureResultValuesH2, gPracticalResultH2, path);
        CreateTableCpInFile(temperatureResultValuesH2, cpTheoreticalResultH2, cpPracticalResultH2, path);
        CreateTablePhiInFile(temperatureResultValuesH2, phiTheoreticalResultH2, phiPracticalResultH2, path);
        CreateTableSInFile(temperatureResultValuesH2, sTheoreticalResultH2, sPracticalResultH2, path);
        CreateTableHInFile(temperatureResultValuesH2, hTheoreticalResultH2, hPracticalResultH2, path);
    }

    public static void OutputResultForO2(Func<double, double>[] functionArray)
    {
        double[] temperatureResultValuesO2 = ThermodynamicProperties.GetTemperatureValuesO2();

        double[] phiValuesForElement =
            temperatureResultValuesO2.Select(temp => ThermodynamicProperties.GetPhiValuesForTemperatureO2(temp))
                .ToArray();

        double[] transformedTemperatures =
            temperatureResultValuesO2.Select(t => t * (1 / (Math.Pow(10.0, 4)))).ToArray();

        double[] polynomialCoefficients =
            LeastSquareMethod.LSMethod(transformedTemperatures, phiValuesForElement, functionArray);
        Console.WriteLine("The transformed polynomial coefficients are:");
        Console.WriteLine(string.Join(", ", polynomialCoefficients));

        double[] phiPracticalResultO2 =
            temperatureResultValuesO2
                .Select(temp => FindCoefficients.FindPhiCoefficients(polynomialCoefficients, temp))
                .ToArray();
        double[] phiTheoreticalResultO2 = ThermodynamicProperties.GetPhiValuesO2();

        double[] gPracticalResultO2 =
            FindCoefficients.FindGCoefficientsO2(polynomialCoefficients, temperatureResultValuesO2);

        double[] sPracticalResultO2 =
            FindCoefficients.FindSCoefficients(gPracticalResultO2, temperatureResultValuesO2);
        double[] sTheoreticalResultO2 = ThermodynamicProperties.GetSValuesO2().ToArray();

        // double[] hPracticalResultO2 =
        //     FindCoefficients.FindHCoefficients(gPracticalResultO2, temperatureResultValuesO2, sPracticalResultO2);
        double[] hPracticalResultO2 =
            FindCoefficients.FindHCoefficients(gPracticalResultO2, temperatureResultValuesO2);
        double[] hTheoreticalResultO2 = ThermodynamicProperties.GetHValuesH2().ToArray();

        double[] cpPracticalResultO2 =
            FindCoefficients.FindCpCoefficients(hPracticalResultO2, temperatureResultValuesO2);
        double[] cpTheoreticalResultO2 = ThermodynamicProperties.GetCpValuesH2().ToArray();

        string path = "/Users/oduvanchik/CourseWorkNumMethods/CourseWork/output_results_O2.txt";
        using (var fileStream = new FileStream(path, FileMode.Create))
        {
        }

        CreateTableGInFile(temperatureResultValuesO2, gPracticalResultO2, path);
        CreateTableCpInFile(temperatureResultValuesO2, cpTheoreticalResultO2, cpPracticalResultO2, path);
        CreateTablePhiInFile(temperatureResultValuesO2, phiTheoreticalResultO2, phiPracticalResultO2, path);
        CreateTableSInFile(temperatureResultValuesO2, sTheoreticalResultO2, sPracticalResultO2, path);
        CreateTableHInFile(temperatureResultValuesO2, hTheoreticalResultO2, hPracticalResultO2, path);
    }

    public static void OutputResultForH2O(Func<double, double>[] functionArray)
    {
        double[] temperatureResultValuesH2O = ThermodynamicProperties.GetTemperatureValuesH2O();

        double[] phiValuesForElement =
            temperatureResultValuesH2O.Select(temp => ThermodynamicProperties.GetPhiValuesForTemperatureH2O(temp))
                .ToArray();

        double[] transformedTemperatures =
            temperatureResultValuesH2O.Select(t => t * (1 / (Math.Pow(10.0, 4)))).ToArray();

        double[] polynomialCoefficients =
            LeastSquareMethod.LSMethod(transformedTemperatures, phiValuesForElement, functionArray);
        Console.WriteLine("The transformed polynomial coefficients are:");
        Console.WriteLine(string.Join(", ", polynomialCoefficients));

        double[] phiPracticalResultH2O =
            temperatureResultValuesH2O
                .Select(temp => FindCoefficients.FindPhiCoefficients(polynomialCoefficients, temp))
                .ToArray();
        double[] phiTheoreticalResultH2O = ThermodynamicProperties.GetPhiValuesH2O();

        double[] gPracticalResultH2O =
            FindCoefficients.FindGCoefficientsH2O(polynomialCoefficients, temperatureResultValuesH2O);

        double[] sPracticalResultH2O =
            FindCoefficients.FindSCoefficients(gPracticalResultH2O, temperatureResultValuesH2O);
        double[] sTheoreticalResultH2O = ThermodynamicProperties.GetSValuesH2O().ToArray();

        // double[] hPracticalResultH2O =
        // FindCoefficients.FindHCoefficients(gPracticalResultH2O, temperatureResultValuesH2O, sPracticalResultH2O);
        double[] hPracticalResultH2O =
            FindCoefficients.FindHCoefficients(gPracticalResultH2O, temperatureResultValuesH2O);

        double[] hTheoreticalResultH2O = ThermodynamicProperties.GetHValuesH2O().ToArray();

        double[] cpPracticalResultH2O =
            FindCoefficients.FindCpCoefficients(hPracticalResultH2O, temperatureResultValuesH2O);
        double[] cpTheoreticalResultH2O = ThermodynamicProperties.GetCpValuesH2O().ToArray();

        string path = "/Users/oduvanchik/CourseWorkNumMethods/CourseWork/output_results_H2O.txt";
        using (var fileStream = new FileStream(path, FileMode.Create))
        {
        }

        CreateTableGInFile(temperatureResultValuesH2O, gPracticalResultH2O, path);
        CreateTableCpInFile(temperatureResultValuesH2O, cpTheoreticalResultH2O, cpPracticalResultH2O, path);
        CreateTablePhiInFile(temperatureResultValuesH2O, phiTheoreticalResultH2O, phiPracticalResultH2O, path);
        CreateTableSInFile(temperatureResultValuesH2O, sTheoreticalResultH2O, sPracticalResultH2O, path);
        CreateTableHInFile(temperatureResultValuesH2O, hTheoreticalResultH2O, hPracticalResultH2O, path);
    }

    public static void OutputResultForOH(Func<double, double>[] functionArray)
    {
        double[] temperatureResultValuesOH = ThermodynamicProperties.GetTemperatureValuesOH();

        double[] phiValuesForElement =
            temperatureResultValuesOH.Select(temp => ThermodynamicProperties.GetPhiValuesForTemperatureOH(temp))
                .ToArray();

        double[] transformedTemperatures =
            temperatureResultValuesOH.Select(t => t * (1 / (Math.Pow(10.0, 4)))).ToArray();

        double[] polynomialCoefficients =
            LeastSquareMethod.LSMethod(transformedTemperatures, phiValuesForElement, functionArray);
        Console.WriteLine("The transformed polynomial coefficients are:");
        Console.WriteLine(string.Join(", ", polynomialCoefficients));

        double[] phiPracticalResultOH =
            temperatureResultValuesOH
                .Select(temp => FindCoefficients.FindPhiCoefficients(polynomialCoefficients, temp))
                .ToArray();
        double[] phiTheoreticalResultOH = ThermodynamicProperties.GetPhiValuesOH();

        double[] gPracticalResultOH =
            FindCoefficients.FindGCoefficientsOH(polynomialCoefficients, temperatureResultValuesOH);

        double[] sPracticalResultOH =
            FindCoefficients.FindSCoefficients(gPracticalResultOH, temperatureResultValuesOH);
        double[] sTheoreticalResultOH = ThermodynamicProperties.GetSValuesOH().ToArray();

        // double[] hPracticalResultOH =
        //     FindCoefficients.FindHCoefficients(gPracticalResultOH, temperatureResultValuesOH, sPracticalResultOH);
        double[] hPracticalResultOH =
            FindCoefficients.FindHCoefficients(gPracticalResultOH, temperatureResultValuesOH);
        double[] hTheoreticalResultOH = ThermodynamicProperties.GetHValuesOH().ToArray();

        double[] cpPracticalResultOH =
            FindCoefficients.FindCpCoefficients(hPracticalResultOH, temperatureResultValuesOH);
        double[] cpTheoreticalResultOH = ThermodynamicProperties.GetCpValuesOH().ToArray();

        string path = "/Users/oduvanchik/CourseWorkNumMethods/CourseWork/output_results_OH.txt";
        using (var fileStream = new FileStream(path, FileMode.Create))
        {
        }

        CreateTableGInFile(temperatureResultValuesOH, gPracticalResultOH, path);
        CreateTableCpInFile(temperatureResultValuesOH, cpTheoreticalResultOH, cpPracticalResultOH, path);
        CreateTablePhiInFile(temperatureResultValuesOH, phiTheoreticalResultOH, phiPracticalResultOH, path);
        CreateTableSInFile(temperatureResultValuesOH, sTheoreticalResultOH, sPracticalResultOH, path);
        CreateTableHInFile(temperatureResultValuesOH, hTheoreticalResultOH, hPracticalResultOH, path);
    }

    public static void OutputResultForH(Func<double, double>[] functionArray)
    {
        double[] temperatureResultValuesH = ThermodynamicProperties.GetTemperatureValuesH();

        double[] phiValuesForElement =
            temperatureResultValuesH.Select(temp => ThermodynamicProperties.GetPhiValuesForTemperatureH(temp))
                .ToArray();

        double[] transformedTemperatures =
            temperatureResultValuesH.Select(t => t * (1 / (Math.Pow(10.0, 4)))).ToArray();

        double[] polynomialCoefficients =
            LeastSquareMethod.LSMethod(transformedTemperatures, phiValuesForElement, functionArray);
        Console.WriteLine("The transformed polynomial coefficients are:");
        Console.WriteLine(string.Join(", ", polynomialCoefficients));

        double[] phiPracticalResultH =
            temperatureResultValuesH
                .Select(temp => FindCoefficients.FindPhiCoefficients(polynomialCoefficients, temp))
                .ToArray();
        double[] phiTheoreticalResultH = ThermodynamicProperties.GetPhiValuesH();

        double[] gPracticalResultH =
            FindCoefficients.FindGCoefficientsH(polynomialCoefficients, temperatureResultValuesH);

        double[] sPracticalResultH =
            FindCoefficients.FindSCoefficients(gPracticalResultH, temperatureResultValuesH);
        double[] sTheoreticalResultH = ThermodynamicProperties.GetSValuesH().ToArray();

        // double[] hPracticalResultH =
        //     FindCoefficients.FindHCoefficients(gPracticalResultH, temperatureResultValuesH, sPracticalResultH);
        double[] hPracticalResultH =
            FindCoefficients.FindHCoefficients(gPracticalResultH, temperatureResultValuesH);
        double[] hTheoreticalResultH = ThermodynamicProperties.GetHValuesH().ToArray();

        double[] cpPracticalResultH =
            FindCoefficients.FindCpCoefficients(hPracticalResultH, temperatureResultValuesH);
        double[] cpTheoreticalResultH = ThermodynamicProperties.GetCpValuesH().ToArray();

        string path = "/Users/oduvanchik/CourseWorkNumMethods/CourseWork/output_results_H.txt";
        using (var fileStream = new FileStream(path, FileMode.Create))
        {
        }

        CreateTableGInFile(temperatureResultValuesH, gPracticalResultH, path);
        CreateTableCpInFile(temperatureResultValuesH, cpTheoreticalResultH, cpPracticalResultH, path);
        CreateTablePhiInFile(temperatureResultValuesH, phiTheoreticalResultH, phiPracticalResultH, path);
        CreateTableSInFile(temperatureResultValuesH, sTheoreticalResultH, sPracticalResultH, path);
        CreateTableHInFile(temperatureResultValuesH, hTheoreticalResultH, hPracticalResultH, path);
    }

    public static void OutputResultForO(Func<double, double>[] functionArray)
    {
        double[] temperatureResultValuesO = ThermodynamicProperties.GetTemperatureValuesO();

        double[] phiValuesForElement =
            temperatureResultValuesO.Select(temp => ThermodynamicProperties.GetPhiValuesForTemperatureO(temp))
                .ToArray();

        double[] transformedTemperatures =
            temperatureResultValuesO.Select(t => t * (1 / (Math.Pow(10.0, 4)))).ToArray();

        double[] polynomialCoefficients =
            LeastSquareMethod.LSMethod(transformedTemperatures, phiValuesForElement, functionArray);
        Console.WriteLine("The transformed polynomial coefficients are:");
        Console.WriteLine(string.Join(", ", polynomialCoefficients));

        double[] phiPracticalResultO =
            temperatureResultValuesO
                .Select(temp => FindCoefficients.FindPhiCoefficients(polynomialCoefficients, temp))
                .ToArray();
        double[] phiTheoreticalResultO = ThermodynamicProperties.GetPhiValuesO();

        double[] gPracticalResultO =
            FindCoefficients.FindGCoefficientsO(polynomialCoefficients, temperatureResultValuesO);

        double[] sPracticalResultO =
            FindCoefficients.FindSCoefficients(gPracticalResultO, temperatureResultValuesO);
        double[] sTheoreticalResultO = ThermodynamicProperties.GetSValuesO().ToArray();

        // double[] hPracticalResultO =
        //     FindCoefficients.FindHCoefficients(gPracticalResultO, temperatureResultValuesO, sPracticalResultO);
        double[] hPracticalResultO =
            FindCoefficients.FindHCoefficients(gPracticalResultO, temperatureResultValuesO);
        double[] hTheoreticalResultO = ThermodynamicProperties.GetHValuesO().ToArray();

        double[] cpPracticalResultO =
            FindCoefficients.FindCpCoefficients(hPracticalResultO, temperatureResultValuesO);
        double[] cpTheoreticalResultO = ThermodynamicProperties.GetCpValuesO().ToArray();

        string path = "/Users/oduvanchik/CourseWorkNumMethods/CourseWork/output_results_O.txt";
        using (var fileStream = new FileStream(path, FileMode.Create))
        {
        }

        CreateTableGInFile(temperatureResultValuesO, gPracticalResultO, path);
        CreateTableCpInFile(temperatureResultValuesO, cpTheoreticalResultO, cpPracticalResultO, path);
        CreateTablePhiInFile(temperatureResultValuesO, phiTheoreticalResultO, phiPracticalResultO, path);
        CreateTableSInFile(temperatureResultValuesO, sTheoreticalResultO, sPracticalResultO, path);
        CreateTableHInFile(temperatureResultValuesO, hTheoreticalResultO, hPracticalResultO, path);
    }

    private static void CreateTableGInFile(double[] temperatureResultValues, double[] gPracticalResult,
        string pathFileName)
    {
        using (StreamWriter writer = new StreamWriter(pathFileName, append: true))
        {
            writer.WriteLine("".PadLeft(20) + "G" + "".PadLeft(20));
            writer.WriteLine(new string('-', 65));

            writer.WriteLine("{0,-15} | {1,-20} ", "Temperature (K)", "Practical G");
            writer.WriteLine(new string('-', 65));

            for (int i = 0; i < temperatureResultValues.Length - 2; i++)
            {
                writer.WriteLine("{0,-15:F2} | {1,-20:F4} ",
                    temperatureResultValues[i],
                    gPracticalResult[i]);
            }

            writer.WriteLine(new string('-', 65));
        }
    }

    private static void CreateTableCpInFile(double[] temperatureResultValues,
        double[] cpTheoreticalResult,
        double[] cpPracticalResult, string pathFileName)
    {
        using (StreamWriter writer = new StreamWriter(pathFileName, append: true))
        {
            writer.WriteLine("".PadLeft(20) + "Cp" + "".PadLeft(20));
            writer.WriteLine(new string('-', 65));

            writer.WriteLine("{0,-15} | {1,-20} | {2,-20}", "Temperature (K)", "Cp Result", "Practical Cp");
            writer.WriteLine(new string('-', 65));

            for (int i = 0; i < temperatureResultValues.Length - 2; i++)
            {
                writer.WriteLine("{0,-15:F2} | {1,-20:F4} | {2,-20:F4}",
                    temperatureResultValues[i],
                    cpTheoreticalResult[i],
                    cpPracticalResult[i]);
            }

            writer.WriteLine(new string('-', 65));
        }
    }

    private static void CreateTablePhiInFile(double[] temperatureResultValues,
        double[] phiTheoreticalResult,
        double[] phiPracticalResult, string pathFileName)
    {
        using (StreamWriter writer = new StreamWriter(pathFileName, append: true))
        {
            writer.WriteLine("".PadLeft(20) + "Phi" + "".PadLeft(20));
            writer.WriteLine(new string('-', 65));

            writer.WriteLine("{0,-15} | {1,-20} | {2,-20}", "Temperature (K)", "Phi Result", "Practical Phi");
            writer.WriteLine(new string('-', 65));

            for (int i = 0; i < temperatureResultValues.Length - 2; i++)
            {
                writer.WriteLine("{0,-15:F2} | {1,-20:F4} | {2,-20:F4}",
                    temperatureResultValues[i],
                    phiTheoreticalResult[i],
                    phiPracticalResult[i]);
            }

            writer.WriteLine(new string('-', 65));
        }
    }

    private static void CreateTableSInFile(double[] temperatureResultValues,
        double[] sTheoreticalResult,
        double[] sPracticalResult, string pathFileName)
    {
        using (StreamWriter writer = new StreamWriter(pathFileName, append: true))
        {
            writer.WriteLine("".PadLeft(20) + "S" + "".PadLeft(20));
            writer.WriteLine(new string('-', 65));

            writer.WriteLine("{0,-15} | {1,-20} | {2,-20}", "Temperature (K)", "S Result", "Practical S");
            writer.WriteLine(new string('-', 65));

            for (int i = 0; i < temperatureResultValues.Length - 2; i++)
            {
                writer.WriteLine("{0,-15:F2} | {1,-20:F4} | {2,-20:F4}",
                    temperatureResultValues[i],
                    sTheoreticalResult[i],
                    sPracticalResult[i]);
            }

            writer.WriteLine(new string('-', 65));
        }
    }

    private static void CreateTableHInFile(double[] temperatureResultValues,
        double[] hTheoreticalResult,
        double[] hPracticalResult, string pathFileName)
    {
        using (StreamWriter writer = new StreamWriter(pathFileName, append: true))
        {
            writer.WriteLine("".PadLeft(20) + "H" + "".PadLeft(20));
            writer.WriteLine(new string('-', 65));

            writer.WriteLine("{0,-15} | {1,-20} | {2,-20}", "Temperature (K)", "H Result", "Practical H");
            writer.WriteLine(new string('-', 65));

            for (int i = 0; i < temperatureResultValues.Length - 2; i++)
            {
                writer.WriteLine("{0,-15:F2} | {1,-20:F4} | {2,-20:F4}",
                    temperatureResultValues[i],
                    hTheoreticalResult[i],
                    hPracticalResult[i] * Math.Pow(10, -3));
            }

            writer.WriteLine(new string('-', 65));
        }
    }
}
