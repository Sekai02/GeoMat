namespace GeoMat;
public class Line2D
{
    public Point2D Point1 { get; }
    public Point2D Point2 { get; }

    public Line2D(Point2D point1, Point2D point2)
    {
        Point1 = point1;
        Point2 = point2;
    }

    //Length of the line
    public double Length()
    {
        return Point1.DistanceBetweenPoints(Point2);
    }

    //Square of the length of the line
    public double SquaredLength()
    {
        return Point1.SquaredDistanceTo(Point2);
    }

    //Checks if a point lies inside the point
    public bool ContainsPoint(Point2D point)
    {
        dynamic crossProduct = (point - Point1) ^ (Point2 - Point1);
        return crossProduct == 0;
    }

    //Checks if two lines are parallel
    public bool IsParallel(Line2D otherLine)
    {
        dynamic crossProduct = (Point2 - Point1) ^ (otherLine.Point2 - otherLine.Point1);
        return crossProduct == 0;
    }

    //Checks if two lines are perpendicular
    public static bool AreLinesPerpendicular(Line2D line1, Line2D line2)
    {
        double slope1 = (line1.Point2.Y - line1.Point1.Y) / (line1.Point2.X - line1.Point1.X);
        double slope2 = (line2.Point2.Y - line2.Point1.Y) / (line2.Point2.X - line2.Point1.X);

        // Check if the product of the slopes is -1
        return Math.Abs(slope1 * slope2 + 1) < double.Epsilon;
    }

    //Check if two lines are coincident
    public static bool AreLinesCoincident(Line2D line1, Line2D line2)
    {
        double slope1 = (line1.Point2.Y - line1.Point1.Y) / (line1.Point2.X - line1.Point1.X);
        double slope2 = (line2.Point2.Y - line2.Point1.Y) / (line2.Point2.X - line2.Point1.X);

        double intercept1 = line1.Point1.Y - slope1 * line1.Point1.X;
        double intercept2 = line2.Point1.Y - slope2 * line2.Point1.X;

        // Check if the slopes and intercepts are equal
        return Math.Abs(slope1 - slope2) < double.Epsilon && Math.Abs(intercept1 - intercept2) < double.Epsilon;
    }

    //Checks if two lines intersect
    public bool IsIntersecting(Line2D otherLine)
    {
        if (IsParallel(otherLine))
        {
            return false;
        }

        dynamic crossProduct1 = (otherLine.Point1 - Point1) ^ (otherLine.Point2 - Point1);
        dynamic crossProduct2 = (otherLine.Point1 - Point2) ^ (otherLine.Point2 - Point2);
        return crossProduct1 * crossProduct2 < 0;
    }

    //Calculates anggle between two lines
    public double AngleBetweenLines(Line2D otherLine)
    {
        dynamic dotProduct = (Point2.X - Point1.X) * (otherLine.Point2.X - otherLine.Point1.X)
            + (Point2.Y - Point1.Y) * (otherLine.Point2.Y - otherLine.Point1.Y);

        dynamic magnitude1 = Math.Sqrt(Math.Pow(Point2.X - Point1.X, 2) + Math.Pow(Point2.Y - Point1.Y, 2));
        dynamic magnitude2 = Math.Sqrt(Math.Pow(otherLine.Point2.X - otherLine.Point1.X, 2)
            + Math.Pow(otherLine.Point2.Y - otherLine.Point1.Y, 2));

        dynamic angleInRadians = Math.Acos(dotProduct / (magnitude1 * magnitude2));
        double angleInDegrees = angleInRadians * (180 / Math.PI);

        return angleInDegrees;
    }
}