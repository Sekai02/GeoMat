using System.Drawing;
using GeoMat;

namespace ShowCase
{
    class Program
    {
        static void Main(string[] args)
        {
            //Short example of how to use Polygon2D class
            Polygon2D poly = new Polygon2D(
                new List<Point2D>{
                    new Point2D(1,-1),
                    new Point2D(1,2),
                    new Point2D(0,4),
                    new Point2D(-1,2),
                    new Point2D(-1,-1)
                }
            );

            //Check if a set of points is inside of the Polygon
            Console.WriteLine(poly.ContainsPoint(new Point2D(-2, -1)));
            Console.WriteLine(poly.ContainsPoint(new Point2D(1, -1)));
            Console.WriteLine(poly.ContainsPoint(new Point2D(0, 1)));
            Console.WriteLine(poly.ContainsPoint(new Point2D(2, 3)));
        }
    }
}