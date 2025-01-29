using System.Numerics;

public class Polar
{
    public double Radius { get; set; }
    public double Theta { get; set; } // In radians

    public Polar(double radius, double theta)
    {
        Radius = radius;
        Theta = theta;
    }

    // Convert from Cartesian to Polar
    public static Polar? FromCartesian(Vector2 point)
    {
        if (double.IsNaN(point.X) || double.IsNaN(point.Y))
            return null;
        double radius = Math.Sqrt(point.X * point.X + point.Y * point.Y);
        double theta = Math.Atan2(point.Y, point.X);
        return new Polar(radius, theta);
    }

    // Convert from Polar to Cartesian
    public Vector2 ToCartesian()
    {
        float x = (float)(Radius * Math.Cos(Theta));
        float y = (float)(Radius * Math.Sin(Theta));
        return new Vector2(x, y);
    }

    // Calculate arc length between two angles at given radius
    public static double ArcLength(double radius, double startTheta, double endTheta)
    {
        if (radius < 0)
            return double.NaN;
        return radius * Math.Abs(endTheta - startTheta);
    }

    // Calculate area of sector
    public static double SectorArea(double radius, double startTheta, double endTheta)
    {
        if (radius < 0)
            return double.NaN;
        return 0.5 * radius * radius * Math.Abs(endTheta - startTheta);
    }

    // Distance between two polar points
    public static double Distance(Polar? p1, Polar? p2)
    {
        if (p1 == null || p2 == null)
            return double.NaN;
        double x = p1.Radius * Math.Cos(p1.Theta) - p2.Radius * Math.Cos(p2.Theta);
        double y = p1.Radius * Math.Sin(p1.Theta) - p2.Radius * Math.Sin(p2.Theta);
        return Math.Sqrt(x * x + y * y);
    }

    // Normalize angle to [0, 2π)
    public static double NormalizeAngle(double theta)
    {
        double twoPi = 2 * Math.PI;
        theta = theta % twoPi;
        return theta < 0 ? theta + twoPi : theta;
    }

    // Calculate the slope of the tangent line at a point
    public double TangentSlope()
    {
        Vector2 point = ToCartesian();
        if (Math.Abs(point.X) < double.Epsilon)
            return double.NaN;
        return -point.X / point.Y;
    }

    // Calculate the curvature at the current point
    public double Curvature()
    {
        if (Radius < double.Epsilon)
            return double.NaN;
        return 1.0 / Radius;
    }

    // Calculate the polar slope (dr/dθ)
    public double PolarSlope()
    {
        return Radius;
    }

    // Check if a point lies on a given polar curve (r = f(θ))
    public bool IsOnCurve(Func<double, double> radiusFunction, double tolerance = 1e-10)
    {
        double expectedRadius = radiusFunction(Theta);
        return Math.Abs(Radius - expectedRadius) < tolerance;
    }
}