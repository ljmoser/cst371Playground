// using System;
// using System.Collections.Generic;

// namespace Playground
// {
//     public class Point
//     {
//         public double X {get;set;}
//         public double Y {get;set;}
//     }

//     public class Segment
//     {
//         public Point A {get;set;}
//         public Point B {get;set;}

//         public double length {get {return Math.Sqrt(Math.Pow(Math.Abs(A.X-B.X), 2) + Math.Pow(Math.Abs(A.Y-B.Y), 2));}}
        
//     }

//     public class Polygon
//     {
//         public List<Segment> Sides {get;set;}

//         public Polygon()
//         {
//             Sides = new List<Segment>();
//         }

//         public double Perimeter()
//         {
//             double perimeter = 0;
//             foreach(var s in Sides)
//             {
//                 perimeter += s.length;
//             }

//             return perimeter;
//         }
//     }

//     public class Square : Polygon
//     {
//         public Square(Point a, Point b, Point c, Point d)
//         {
//             //We could (and probably should) do some clever things here
//             //to prevent ourselves from producing an invalid square

//             Segment side1 = new Segment(){A = a,B = b};
//             Segment side2 = new Segment(){A = b,B = c};
//             Segment side3 = new Segment(){A = c,B = d};
//             Segment side4 = new Segment(){A = d,B = a};
//             this.Sides.Add(side1);
//             this.Sides.Add(side2);
//             this.Sides.Add(side3);
//             this.Sides.Add(side4);
//         }
//         public Segment LeftSide {get {return Sides[0];}}
//         public Segment RightSide {get {return Sides[1];}}
//         public Segment BottomSide {get {return Sides[2];}}
//         public Segment TopSide {get {return Sides[3];}}
//     }

//     public class Triangle : Polygon
//     {
//         public Triangle(Point a, Point b, Point c)

//         {
//             Segment side1 = new Segment(){A = a,B = b};
//             Segment side2 = new Segment(){A = b,B = c};
//             Segment side3 = new Segment(){A = c,B = a};
//             this.Sides.Add(side1);
//             this.Sides.Add(side2);
//             this.Sides.Add(side3);

//         }
//         public Segment Side1 {get {return Sides[0];}}
//         public Segment Side2 {get {return Sides[1];}}
//         public Segment Side3 {get {return Sides[2];}}
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Point p = new Point(){X = 10, Y= 14},
//             q = new Point(){X = 12, Y= 14},
//             r = new Point(){X = 10, Y= 18};
//             Triangle triangle = new Triangle(p, q, r);

//             Point t = new Point(){X=10, Y=10},
//             u = new Point(){X=10,Y=20},
//             v = new Point(){X=20,Y=20},
//             w = new Point(){X=10,Y=20};

//             Square s = new Square(t,u,v,w);

            
//         }
//     }
// }
