using System.Text;

namespace NumericalMethods;

public class SplineSegment
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    public double D { get; set; }
    public double XStart { get; set; }
    public double XEnd { get; set; }

    public string GetPolynomial()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"S(x) = {A:F5}");

        if (B >= 0)
        {
            sb.Append($" + {B:F5}(x - {XStart})");
        }
        else
        {
            sb.Append($" - {Math.Abs(B):F5}(x - {XStart})");
        }

        if (C >= 0)
        {
            sb.Append($" + {C:F5}(x - {XStart})^2");
        }
        else
        {
            sb.Append($" - {Math.Abs(C):F5}(x - {XStart})^2");
        }

        if (D >= 0)
        {
            sb.Append($" + {D:F5}(x - {XStart})^3");
        }
        else
        {
            sb.Append($" - {Math.Abs(D):F5}(x - {XStart})^3");
        }

        return sb.ToString();
    }
}

public class CubicSpline
{
    private readonly double[] xValues;
    private readonly double[] yValues;
    private readonly int n;
    private readonly double[] h;
    private readonly double[] alpha;
    private readonly double[] l;
    private readonly double[] mu;
    private readonly double[] z;
    private readonly double[] a;
    private readonly double[] b;
    private readonly double[] c;
    private readonly double[] d;
    private List<SplineSegment> Segments { get; set; }

    private CubicSpline(double[] xValues, double[] yValues)
    {
        var sortedIndices = Enumerable.Range(0, xValues.Length)
            .OrderBy(i => xValues[i])
            .ToArray();
        
        this.xValues = sortedIndices.Select(i => xValues[i]).ToArray();
        this.yValues = sortedIndices.Select(i => yValues[i]).ToArray();

        n = this.xValues.Length;
        h = new double[n - 1];
        alpha = new double[n - 1];
        l = new double[n];
        mu = new double[n];
        z = new double[n];
        a = new double[n];
        b = new double[n - 1];
        c = new double[n];
        d = new double[n - 1];
        Segments = new List<SplineSegment>();

        Initialize();
        ComputeSplineCoefficients();
        ConstructSegments();
    }

    private void Initialize()
    {
        for (int i = 0; i < n - 1; i++)
        {
            h[i] = xValues[i + 1] - xValues[i];
            if (h[i] <= 0)
            {
                throw new ArgumentException("xValues must be in strictly increasing order.");
            }
        }

        for (int i = 1; i < n - 1; i++)
        {
            alpha[i] = (3.0 / h[i]) * (yValues[i + 1] - yValues[i]) -
                       (3.0 / h[i - 1]) * (yValues[i] - yValues[i - 1]);
        }
    }
    private void ComputeSplineCoefficients()
    {
        l[0] = 1.0;
        mu[0] = 0.0;
        z[0] = 0.0;

        for (int i = 1; i < n - 1; i++)
        {
            l[i] = 2.0 * (xValues[i + 1] - xValues[i - 1]) - h[i - 1] * mu[i - 1];
            if (l[i] == 0)
            {
                throw new InvalidOperationException("Singular matrix encountered in spline computation.");
            }
            
            mu[i] = h[i] / l[i];
            z[i] = (alpha[i] - h[i - 1] * z[i - 1]) / l[i];
        }

        l[n - 1] = 1.0;
        z[n - 1] = 0.0;
        c[n - 1] = 0.0;

        for (int j = n - 2; j >= 0; j--)
        {
            c[j] = z[j] - mu[j] * c[j + 1];
            b[j] = (yValues[j + 1] - yValues[j]) / h[j] -
                   h[j] * (c[j + 1] + 2.0 * c[j]) / 3.0;
            d[j] = (c[j + 1] - c[j]) / (3.0 * h[j]);
            a[j] = yValues[j];
        }
    }

    private void ConstructSegments()
    {
        for (int i = 0; i < n - 1; i++)
        {
            Segments.Add(new SplineSegment
            {
                A = a[i],
                B = b[i],
                C = c[i],
                D = d[i],
                XStart = xValues[i],
                XEnd = xValues[i + 1]
            });
        }
    }

    private double Interpolate(double x)
    {
        if (x < xValues.First() || x > xValues.Last())
        {
            throw new ArgumentOutOfRangeException("x is outside the interpolation range.");
        }

        int interval = Array.BinarySearch(xValues, x);
        
        if (interval < 0)
        {
            interval = ~interval - 1;
        }
        
        interval = Math.Max(0, Math.Min(interval, n - 2));

        var segment = Segments[interval];
        double dx = x - segment.XStart;
        return segment.A + segment.B * dx + segment.C * Math.Pow(dx, 2) + segment.D * Math.Pow(dx, 3);
    }

    private IEnumerable<string> GetAllPolynomials()
    {
        return Segments.Select(seg => $"Interval [{seg.XStart}, {seg.XEnd}]: {seg.GetPolynomial()}");
    }

    public static void MainFunction()
    {
        double[] xValues = { -0.4, -0.1, 0.2, 0.5, 0.8 };
        double[] yValues = { -0.41152, -0.10017, 0.20136, 0.52360, 0.92730 };

        try
        {
            CubicSpline spline = new CubicSpline(xValues, yValues);

            Console.WriteLine("Cubic Spline Polynomials for Each Interval:");
            foreach (var poly in spline.GetAllPolynomials())
            {
                Console.WriteLine(poly);
            }

            double xToInterpolate = 0.1;
            double interpolatedValue = spline.Interpolate(xToInterpolate);
            Console.WriteLine(
                $"Interpolated value at x = {xToInterpolate} is f({xToInterpolate}) = {interpolatedValue:F5}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}