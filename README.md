# Polar Coordinates Library

A pure C# library for working with polar coordinates. No external dependencies except for Microsoft's unit testing, built for .NET 9.0.

This code is free for non-commercial use. A commercial use license is $5 Canadian.</br>
Make a purchase [here.](https://TranscendAI.tech/paylanding.html)</br>

## What Are Polar Coordinates?
Polar coordinates provide a way to represent points in a plane using a distance from a reference point (the radius) and an angle from a reference direction (theta). Unlike Cartesian coordinates (x, y), which define a point by horizontal and vertical displacement, polar coordinates define a point as:

- **Radius (r)**: The distance from the origin to the point.
- **Theta (θ)**: The angle (in radians) measured counterclockwise from the positive x-axis.

### Direction of Theta (θ)
- Theta (θ) is measured in radians.
- Positive angles rotate counterclockwise from the positive x-axis.
- Negative angles rotate clockwise from the positive x-axis.
- The angle is typically normalized to the range **[0, 2π)**.

## Functionality of the `Polar` Class
This `Polar` class provides methods to work with polar coordinates, including conversions, measurements, and calculations.

### Constructor
```csharp
public Polar(double radius, double theta)
```
- Initializes a `Polar` object with a specified radius and angle.

### Conversion Methods
#### `FromCartesian(Vector2 point)`
```csharp
public static Polar? FromCartesian(Vector2 point)
```
- Converts a Cartesian coordinate (x, y) into polar coordinates.
- Returns `null` if the input contains `NaN` values.
- Uses the formula:
  - `r = sqrt(x² + y²)`
  - `θ = atan2(y, x)`

#### `ToCartesian()`
```csharp
public Vector2 ToCartesian()
```
- Converts a polar coordinate to Cartesian form (x, y).
- Uses the formulas:
  - `x = r * cos(θ)`
  - `y = r * sin(θ)`

### Measurement Functions
#### `ArcLength(double radius, double startTheta, double endTheta)`
```csharp
public static double ArcLength(double radius, double startTheta, double endTheta)
```
- Computes the arc length of a circular segment between two angles.
- Formula: `Arc Length = r * |θ₂ - θ₁|`.
- Returns `NaN` if the radius is negative.

#### `SectorArea(double radius, double startTheta, double endTheta)`
```csharp
public static double SectorArea(double radius, double startTheta, double endTheta)
```
- Calculates the area of a sector of a circle.
- Formula: `Sector Area = (1/2) * r² * |θ₂ - θ₁|`.
- Returns `NaN` if the radius is negative.

#### `Distance(Polar? p1, Polar? p2)`
```csharp
public static double Distance(Polar? p1, Polar? p2)
```
- Computes the Euclidean distance between two points given in polar form.
- Uses Cartesian conversion for distance calculation:
  - `distance = sqrt((x₁ - x₂)² + (y₁ - y₂)²)`
- Returns `NaN` if either point is `null`.

### Angle Normalization
#### `NormalizeAngle(double theta)`
```csharp
public static double NormalizeAngle(double theta)
```
- Ensures that an angle is in the range `[0, 2π)`.
- Uses modular arithmetic to adjust negative angles.

### Calculus and Curvature
#### `TangentSlope()`
```csharp
public double TangentSlope()
```
- Computes the slope of the tangent line at the given polar coordinate.
- Uses Cartesian form: `slope = -x / y`.
- Returns `NaN` if the denominator is zero.

#### `Curvature()`
```csharp
public double Curvature()
```
- Computes the curvature at the given point.
- Formula: `Curvature = 1 / Radius`.
- Returns `NaN` if the radius is zero.

#### `PolarSlope()`
```csharp
public double PolarSlope()
```
- Computes the radial slope `dr/dθ` at the given point.
- Returns the radius as the slope.

### Curve Fitting
#### `IsOnCurve(Func<double, double> radiusFunction, double tolerance = 1e-10)`
```csharp
public bool IsOnCurve(Func<double, double> radiusFunction, double tolerance = 1e-10)
```
- Checks if the point lies on a given polar curve `r = f(θ)`.
- Uses absolute difference to determine if `Radius ≈ f(Theta)`.

## Usage Example
```csharp
Vector2 point = new Vector2(3, 4);
Polar? polar = Polar.FromCartesian(point);
if (polar != null)
{
    Console.WriteLine($"Radius: {polar.Radius}, Theta: {polar.Theta}");
    Vector2 cartesian = polar.ToCartesian();
    Console.WriteLine($"Converted back: ({cartesian.X}, {cartesian.Y})");
}
```

This library provides robust mathematical operations for handling polar coordinates, including conversions, distance calculations, and curvature analysis.

![AI Image](aiimage.jpg)
</br>
Copyright [TranscendAI.tech](https://TranscendAI.tech) 2025.</br>
Authored by Warren Harding. AI assisted.</br>

