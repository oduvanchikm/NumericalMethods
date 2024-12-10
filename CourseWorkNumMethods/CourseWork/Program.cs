namespace CourseWork;

public class Program
{
    static void Main(string[] args)
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
        
        OutputResult.OutputResultForH2(functionArray);
        OutputResult.OutputResultForO2(functionArray);
        OutputResult.OutputResultForH2O(functionArray);
        OutputResult.OutputResultForOH(functionArray);
        OutputResult.OutputResultForH(functionArray);
        OutputResult.OutputResultForO(functionArray);
    }
}
