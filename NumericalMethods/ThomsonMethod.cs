namespace NumericalMethods;

class MatrixSolverThomsonMethod
{
    private static (List<double>, List<double>, List<double>) FindDiagonalsMatrix(MyMatrix matrix)
    {
        int n = matrix.getRowSize();

        List<double> MainDiagonal = new List<double>(new double[n]);
        List<double> UpperDiagonal = new List<double>(new double[n]);
        List<double> LowerDiagonal = new List<double>(new double[n]);

        LowerDiagonal[0] = 0;

        for (int i = 0; i < n; ++i)
        {
            MainDiagonal[i] = matrix.getDataMatrix()[i][i];

            if (i < n - 1)
            {
                UpperDiagonal[i] = matrix.getDataMatrix()[i][i + 1];
            }

            if (i > 0)
            {
                LowerDiagonal[i] = matrix.getDataMatrix()[i][i - 1];
            }
        }

        UpperDiagonal[n - 1] = 0;

        Console.WriteLine("Main diagonal: " + string.Join(" ", MainDiagonal));
        Console.WriteLine("Upper diagonal: " + string.Join(" ", UpperDiagonal));
        Console.WriteLine("Lower diagonal: " + string.Join(" ", LowerDiagonal));

        return (MainDiagonal, UpperDiagonal, LowerDiagonal);
    }

    private static bool CheckCriterionForStability(List<double> MainDiagonal, List<double> UpperDiagonal,
        List<double> LowerDiagonal)
    {
        for (var i = 0; i < MainDiagonal.Count; ++i)
        {
            double MainDiagElem = Math.Abs(MainDiagonal[i]);
            double UpperDiagElem = Math.Abs(UpperDiagonal[i]);
            double LowerDiagElem = Math.Abs(LowerDiagonal[i]);

            if (MainDiagElem >= LowerDiagElem + UpperDiagElem)
            {
                return true;
            }
        }

        return false;
    }

    private static bool CheckCriterionForStabilityForP(List<double> ValueP)
    {
        for (var i = 0; i < ValueP.Count; ++i)
        {
            double ValuePCheck = Math.Abs(ValueP[i]);

            if (ValuePCheck <= 1)
            {
                return true;
            }
        }

        return false;
    }

    private static (List<double>, List<double>) ThomsonDirectMethod(MyMatrix matrix, MyMatrix vector)
    {
        (List<double> MainDiagonal, List<double> UpperDiagonal, List<double> LowerDiagonal) =
            FindDiagonalsMatrix(matrix);

        if (!CheckCriterionForStability(MainDiagonal, UpperDiagonal, LowerDiagonal))
        {
            throw new InvalidOperationException("Does not satisfy the stability condition");
        }

        int size = matrix.getRowSize();

        List<double> ValuesP = new List<double>(new double[size]);
        List<double> ValuesQ = new List<double>(new double[size]);
        List<double> VectorD = vector.getVectorD();

        ValuesP[0] = -(UpperDiagonal[0]) / MainDiagonal[0];
        ValuesQ[0] = VectorD[0] / MainDiagonal[0];

        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("Number of iterator 1");
        Console.WriteLine($"P elements: {Math.Round(ValuesP[0], 6)}");
        Console.WriteLine($"Q elements: {Math.Round(ValuesQ[0], 6)}");
        Console.WriteLine("--------------------------------------------------------");

        for (var i = 1; i < matrix.getRowSize(); ++i)
        {
            ValuesP[i] = -(UpperDiagonal[i]) / (MainDiagonal[i] + LowerDiagonal[i] * ValuesP[i - 1]);
            ValuesQ[i] = (VectorD[i] - LowerDiagonal[i] * ValuesQ[i - 1]) /
                         (MainDiagonal[i] + LowerDiagonal[i] * ValuesP[i - 1]);

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"Number of iterator {i + 1}");
            Console.WriteLine($"P elements: {Math.Round(ValuesP[i], 6)}");
            Console.WriteLine($"Q elements: {Math.Round(ValuesQ[i], 6)}");
            Console.WriteLine("--------------------------------------------------------");
        }

        if (!CheckCriterionForStabilityForP(ValuesP))
        {
            throw new InvalidOperationException("Does not satisfy the stability condition for P value");
        }

        return (ValuesP, ValuesQ);
    }

    private static List<double> ThomsonReverseMethod(List<double> ValueP, List<double> ValueQ)
    {
        int size = ValueP.Count;
        Console.WriteLine($"Size P: {size}");
        List<double> ValuesX = new List<double>(new double[size]);

        ValuesX[size - 1] = ValueQ[size - 1];

        Console.WriteLine("===========================");
        Console.WriteLine($"Result {5}: {ValuesX[size - 1]}, {ValueP[size - 1]}, {ValueQ[size - 1]}");

        for (var i = size - 2; i >= 0; i--)
        {
            ValuesX[i] = ValueP[i] * ValuesX[i + 1] + ValueQ[i];
            Console.WriteLine($"Result {i + 1}: {ValuesX[i]}, {ValueP[i]}, {ValueQ[i]}");
        }

        Console.WriteLine("===========================");
        Console.WriteLine("ValuesX: " + string.Join(", ", ValuesX));

        return ValuesX;
    }

    private static double DeterminantOfTheMatrix(List<double> MainDiagonal, List<double> ValueP,
        List<double> LowerDiagonal)
    {
        int n = MainDiagonal.Count; // это размерность матрицы
        double result = MainDiagonal[0] + LowerDiagonal[0];

        for (int i = 1; i < n; ++i)
        {
            result *= MainDiagonal[i] + LowerDiagonal[i] * ValueP[i - 1];
        }

        Console.WriteLine($"Matrix's determinant: {result}");
        Console.WriteLine("Correct answer: -783672");

        return result;
    }

    public static void MainFunction()
    {
        string filename1 = "/Users/oduvanchik/NumericalMethods/FilesForLabs/SecondMatrix.txt";
        MyMatrix matrix1 = new MyMatrix();
        matrix1.ReadMatrixFromFile(filename1);

        string filename2 = "/Users/oduvanchik/NumericalMethods/FilesForLabs/SecondVector.txt";
        MyMatrix vector1 = new MyMatrix();
        vector1.ReadDFromFile(filename2);

        (List<double> main, List<double> upper, List<double> lower) = FindDiagonalsMatrix(matrix1);

        (List<double> P, List<double> Q) = ThomsonDirectMethod(matrix1, vector1);

        List<double> x = ThomsonReverseMethod(P, Q);

        double det = DeterminantOfTheMatrix(main, P, lower);
    }
}