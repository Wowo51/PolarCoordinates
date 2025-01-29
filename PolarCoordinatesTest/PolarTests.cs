using System.Numerics;

[TestClass]
public class PolarTests
{
    private const double Epsilon = 1e-10;
    [TestMethod]
    public void Constructor_ValidInput_SetsProperties()
    {
        Polar polar = new Polar(5.0, Math.PI / 4);
        Assert.AreEqual(5.0, polar.Radius);
        Assert.AreEqual(Math.PI / 4, polar.Theta);
    }

    [TestMethod]
    public void FromCartesian_ValidPoint_ReturnsPolarCoordinates()
    {
        Vector2 point = new Vector2(3.0f, 4.0f);
        Polar? polar = Polar.FromCartesian(point);
        Assert.IsNotNull(polar);
        Assert.AreEqual(5.0, polar.Radius, Epsilon);
        Assert.AreEqual(Math.Atan2(4, 3), polar.Theta, Epsilon);
    }

    [TestMethod]
    public void FromCartesian_NaNInput_ReturnsNull()
    {
        Vector2 point = new Vector2(float.NaN, 4.0f);
        Polar? polar = Polar.FromCartesian(point);
        Assert.IsNull(polar);
    }

    [TestMethod]
    public void ToCartesian_ValidInput_ReturnsCartesianCoordinates()
    {
        Polar polar = new Polar(5.0, Math.PI / 4);
        Vector2 point = polar.ToCartesian();
        double expectedX = 5.0 * Math.Cos(Math.PI / 4);
        double expectedY = 5.0 * Math.Sin(Math.PI / 4);
        Assert.AreEqual((float)expectedX, point.X, Epsilon);
        Assert.AreEqual((float)expectedY, point.Y, Epsilon);
    }

    [TestMethod]
    public void ArcLength_ValidInput_ReturnsCorrectLength()
    {
        double length = Polar.ArcLength(2.0, 0, Math.PI / 2);
        Assert.AreEqual(Math.PI, length, Epsilon);
    }

    [TestMethod]
    public void ArcLength_NegativeRadius_ReturnsNaN()
    {
        double length = Polar.ArcLength(-1.0, 0, Math.PI);
        Assert.IsTrue(double.IsNaN(length));
    }

    [TestMethod]
    public void SectorArea_ValidInput_ReturnsCorrectArea()
    {
        double area = Polar.SectorArea(2.0, 0, Math.PI);
        Assert.AreEqual(2.0 * Math.PI, area, Epsilon);
    }

    [TestMethod]
    public void SectorArea_NegativeRadius_ReturnsNaN()
    {
        double area = Polar.SectorArea(-1.0, 0, Math.PI);
        Assert.IsTrue(double.IsNaN(area));
    }

    [TestMethod]
    public void Distance_ValidPoints_ReturnsCorrectDistance()
    {
        Polar p1 = new Polar(1.0, 0);
        Polar p2 = new Polar(1.0, Math.PI);
        double distance = Polar.Distance(p1, p2);
        Assert.AreEqual(2.0, distance, Epsilon);
    }

    [TestMethod]
    public void Distance_NullInput_ReturnsNaN()
    {
        Polar p1 = new Polar(1.0, 0);
        double distance = Polar.Distance(p1, null);
        Assert.IsTrue(double.IsNaN(distance));
    }

    [TestMethod]
    public void NormalizeAngle_ValidInput_ReturnsNormalizedAngle()
    {
        double normalized = Polar.NormalizeAngle(3 * Math.PI);
        Assert.AreEqual(Math.PI, normalized, Epsilon);
    }

    [TestMethod]
    public void NormalizeAngle_NegativeInput_ReturnsPositiveAngle()
    {
        double normalized = Polar.NormalizeAngle(-Math.PI / 2);
        Assert.AreEqual(3 * Math.PI / 2, normalized, Epsilon);
    }

    [TestMethod]
    public void TangentSlope_ValidPoint_ReturnsCorrectSlope()
    {
        Polar polar = new Polar(2.0, Math.PI / 4);
        double slope = polar.TangentSlope();
        Assert.AreEqual(-1.0, slope, Epsilon);
    }

    [TestMethod]
    public void Curvature_ValidRadius_ReturnsCorrectCurvature()
    {
        Polar polar = new Polar(2.0, Math.PI / 4);
        double curvature = polar.Curvature();
        Assert.AreEqual(0.5, curvature, Epsilon);
    }

    [TestMethod]
    public void Curvature_ZeroRadius_ReturnsNaN()
    {
        Polar polar = new Polar(0.0, Math.PI / 4);
        double curvature = polar.Curvature();
        Assert.IsTrue(double.IsNaN(curvature));
    }

    [TestMethod]
    public void PolarSlope_ValidPoint_ReturnsCorrectSlope()
    {
        Polar polar = new Polar(2.0, Math.PI / 4);
        double slope = polar.PolarSlope();
        Assert.AreEqual(2.0, slope, Epsilon);
    }

    [TestMethod]
    public void IsOnCurve_PointOnCurve_ReturnsTrue()
    {
        Polar polar = new Polar(2.0, Math.PI / 4);
        bool isOnCurve = polar.IsOnCurve(theta => 2.0);
        Assert.IsTrue(isOnCurve);
    }

    [TestMethod]
    public void IsOnCurve_PointNotOnCurve_ReturnsFalse()
    {
        Polar polar = new Polar(2.0, Math.PI / 4);
        bool isOnCurve = polar.IsOnCurve(theta => 3.0);
        Assert.IsFalse(isOnCurve);
    }
}