using System;
using System.Collections.Generic;

namespace GeoMat;

public class Polygon2D
{
    public List<Point2D> Vertices { get; }

    public Polygon2D(List<Point2D> vertices)
    {
        Vertices = vertices;
    }

    //Calculate Area of Polygon (points must be sorted in counter-clockwise order)
    public double CalculateArea()
    {
        int numVertices = Vertices.Count;
        if (numVertices < 3)
        {
            throw new InvalidOperationException("A Polygon2D must have at least 3 vertices.");
        }

        double area = 0;
        for (int i = 0; i < numVertices; i++)
        {
            int j = (i + 1) % numVertices;
            area += Vertices[i].X * Vertices[j].Y;
            area -= Vertices[j].X * Vertices[i].Y;
        }
        area /= 2;

        return Math.Abs(area);
    }

    //Checks if point is strictly inside polygon
    public bool ContainsInnerPoint(Point2D point)
    {
        int numVertices = Vertices.Count;
        if (numVertices < 3)
        {
            throw new InvalidOperationException("A Polygon2D must have at least 3 vertices.");
        }

        bool contains = false;
        int j = numVertices - 1;
        for (int i = 0; i < numVertices; i++)
        {
            if ((Vertices[i].Y < point.Y && Vertices[j].Y >= point.Y
                || Vertices[j].Y < point.Y && Vertices[i].Y >= point.Y)
                && (Vertices[i].X + (point.Y - Vertices[i].Y) / (Vertices[j].Y - Vertices[i].Y) * (Vertices[j].X - Vertices[i].X) < point.X))
            {
                contains = !contains;
            }
            j = i;
        }

        return contains;
    }

    //Checks if point lies in the border of the polygon or inside it
    public bool ContainsPoint(Point2D point)
    {
        int numVertices = Vertices.Count;
        if (numVertices < 3)
        {
            throw new InvalidOperationException("A polygon must have at least 3 vertices.");
        }

        bool contains = false;
        int j = numVertices - 1;
        for (int i = 0; i < numVertices; i++)
        {
            if ((Vertices[i].Y < point.Y && Vertices[j].Y >= point.Y
                || Vertices[j].Y < point.Y && Vertices[i].Y >= point.Y)
                && (Vertices[i].X + (point.Y - Vertices[i].Y) / (Vertices[j].Y - Vertices[i].Y) * (Vertices[j].X - Vertices[i].X) <= point.X))
            {
                if (Math.Abs(point.X - Vertices[i].X) < double.Epsilon && Math.Abs(point.Y - Vertices[i].Y) < double.Epsilon)
                {
                    return true; // Punto está en un vértice
                }
                contains = !contains;
            }
            if (Math.Abs(point.X - Vertices[i].X) < double.Epsilon && Math.Abs(point.Y - Vertices[i].Y) < double.Epsilon)
            {
                return true; // Punto está en el borde
            }
            j = i;
        }

        return contains;
    }

    //Checks if a line cuts the polygon
    public bool IntersectsLine(Line2D line)
    {
        int numVertices = Vertices.Count;
        if (numVertices < 3)
        {
            throw new InvalidOperationException("A Polygon2D must have at least 3 vertices.");
        }

        for (int i = 0; i < numVertices; i++)
        {
            int j = (i + 1) % numVertices;
            Line2D edge = new Line2D(Vertices[i], Vertices[j]);
            if (line.IsIntersecting(edge))
            {
                return true;
            }
        }

        return false;
    }
}