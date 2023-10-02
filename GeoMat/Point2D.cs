namespace GeoMat;
using System;

public class Point2D
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point2D(double x, double y)
    {
        X = x;
        Y = y;
    }

    //Plus operator
    public static Point2D operator +(Point2D p1, Point2D p2)
    {
        dynamic x = p1.X + p2.X;
        dynamic y = p1.Y + p2.Y;
        return new Point2D(x, y);
    }

    //Minus operator
    public static Point2D operator -(Point2D p1, Point2D p2)
    {
        dynamic x = p1.X - p2.X;
        dynamic y = p1.Y - p2.Y;
        return new Point2D(x, y);
    }

    //Dot product
    public static dynamic operator *(Point2D p1, Point2D p2)
    {
        dynamic x = p1.X * p2.X;
        dynamic y = p1.Y * p2.Y;
        return x + y;
    }
    
    //Cross product
    public static dynamic operator ^(Point2D p1, Point2D p2)
    {
        dynamic x = p1.X * p2.Y;
        dynamic y = p1.Y * p2.X;
        return x - y;
    }

    //Cross product between three points
    public static dynamic operator ^(Point2D p1, Tuple<Point2D, Point2D> p2)
    {
        dynamic x1 = p2.Item1.X - p1.X;
        dynamic y1 = p2.Item1.Y - p1.Y;
        dynamic x2 = p2.Item2.X - p1.X;
        dynamic y2 = p2.Item2.Y - p1.Y;
        return x1 * y2 - y1 * x2;
    }

    //Product by scalar
    public static Point2D operator *(Point2D p, double scalar)
    {
        dynamic x = p.X * scalar;
        dynamic y = p.Y * scalar;
        return new Point2D(x, y);
    }

    //Product by scalar
    public static Point2D operator *(double scalar, Point2D p)
    {
        return p * scalar;
    }

    //Divide by scalar
    public static Point2D operator /(Point2D p, double scalar)
    {
        dynamic x = p.X / scalar;
        dynamic y = p.Y / scalar;
        return new Point2D(x, y);
    }

    //Rotate point by angle in radians
    public void Rotate(double angle)
    {
        dynamic sin = Math.Sin(angle);
        dynamic cos = Math.Cos(angle);
        dynamic x = X * cos - Y * sin;
        dynamic y = X * sin + Y * cos;
        X = x;
        Y = y;
    }

    //Get Polar Angle
    public double GetAngle()
    {
        return Math.Atan2(Convert.ToDouble(Y), Convert.ToDouble(X));
    }

    //Distance from origin to point
    public double DistanceFromOrigin()
    {
        dynamic xSquared = X * X;
        dynamic ySquared = Y * Y;
        return Math.Sqrt(xSquared + ySquared);
    }

    //Checks if the closes turn from one point to another is the counterclockwise (cross product is used)
    public bool IsCounterClockwise(Point2D p1, Point2D p2)
    {
        dynamic result = (p2.X - X) * (p1.Y - Y) - (p1.X - X) * (p2.Y - Y);
        return result > 0;
    }

    //Distance between two points
    public double DistanceBetweenPoints(Point2D p)
    {
        dynamic xDiff = X - p.X;
        dynamic yDiff = Y - p.Y;
        dynamic xSquared = xDiff * xDiff;
        dynamic ySquared = yDiff * yDiff;
        return Math.Sqrt(xSquared + ySquared);
    }

    //Square of the distance between two points
    public double SquaredDistanceTo(Point2D p)
    {
        dynamic xDiff = X - p.X;
        dynamic yDiff = Y - p.Y;
        dynamic xSquared = xDiff * xDiff;
        dynamic ySquared = yDiff * yDiff;
        return xSquared + ySquared;
    }

    //Distance from point to line
    public double DistanceToLine(Line2D line)
    {
        dynamic numerator = ((line.Point2.Y - line.Point1.Y) * X) - ((line.Point2.X - line.Point1.X) * Y) + (line.Point2.X * line.Point1.Y) - (line.Point2.Y * line.Point1.X);
        dynamic denominator = Math.Sqrt(Math.Pow(line.Point2.Y - line.Point1.Y, 2) + Math.Pow(line.Point2.X - line.Point1.X, 2));
        return Math.Abs(numerator) / denominator;
    }
}