# GeoMat

GeoMat es una biblioteca en C# que proporciona clases y métodos para cálculos geométricos en un espacio 2D. Incluye funcionalidades para trabajar con polígonos y líneas.

## Características

- **Polygon2D**: Representa un polígono en 2D y proporciona métodos para calcular su área, verificar si un punto está dentro o en el borde del polígono, y determinar si una línea intersecta el polígono.

- **Line2D**: Representa una línea en 2D y proporciona métodos para calcular su longitud, verificar si un punto está en la línea, determinar si dos líneas son paralelas o perpendiculares, verificar si dos líneas se intersectan y calcular el ángulo entre dos líneas.

- **Point2D**: Representa un punto en un espacio 2D y proporciona métodos para calcular la distancia entre dos puntos y la distancia al cuadrado entre dos puntos.

## Uso

Para utilizar la biblioteca GeoMat en tu proyecto de C#, puedes clonar este repositorio o instalarlo como un paquete NuGet. Una vez que tengas la biblioteca incluida en tu proyecto, puedes utilizar las diversas clases y sus métodos para cálculos geométricos.

Aquí tienes un ejemplo de cómo calcular el área de un polígono:

```csharp
using GeoMat;

// Crear una lista de vértices
List<Point2D> vertices = new List<Point2D>()
{
    new Point2D(0, 0),
    new Point2D(0, 5),
    new Point2D(5, 5),
    new Point2D(5, 0)
};

// Crear un objeto Polygon2D
Polygon2D polygon = new Polygon2D(vertices);

// Calcular el área
double area = polygon.CalculateArea();

Console.WriteLine("Área: " + area);
