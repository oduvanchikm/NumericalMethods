namespace CourseWork;

public class ThermodynamicData
{
    public double Cp { get; set; }
    public double H { get; set; }
    public double S { get; set; }
    public double Phi { get; set; }

    public override string ToString()
    {
        return $"{Cp:F3}, {H:F3}, {S:F3}, {Phi:F3}";
    }
}