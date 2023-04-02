using System;
// Dear Brother Duane Richards
// This is the final project "open-ended project"
namespace ShapeProgram
{
    abstract class Shape
    {
        public abstract double Area();
    }

    class Circle : Shape
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public override double Area()
        {
            return Math.PI * _radius * _radius;
        }
    }

    class Rectangle : Shape
    {
        private double _length;
        private double _width;

        public Rectangle(double length, double width)
        {
            _length = length;
            _width = width;
        }

        public override double Area()
        {
            return _length * _width;
        }
    }

    class Triangle : Shape
    {
        private double _side1;
        private double _side2;
        private double _side3;

        public Triangle(double side1, double side2, double side3)
        {
            _side1 = side1;
            _side2 = side2;
            _side3 = side3;
        }

        public override double Area()
        {
            double s = (_side1 + _side2 + _side3) / 2;
            return Math.Sqrt(s * (s - _side1) * (s - _side2) * (s - _side3));
        }
    }

    class Square : Rectangle
    {
        public Square(double side) : base(side, side)
        {
        }
          public override double Area()
        {
            return side * side;
        }
    }

    class Ellipse : Shape
    {
        private double _majorRadius;
        private double _minorRadius;

        public Ellipse(double majorRadius, double minorRadius)
        {
            _majorRadius = majorRadius;
            _minorRadius = minorRadius;
        }

        public override double Area()
        {
            return Math.PI * _majorRadius * _minorRadius;
        }
    }

    class Pentagon : Shape
    {
        private double _sideLength;

        public Pentagon(double sideLength)
        {
            _sideLength = sideLength;
        }

        public override double Area()
        {
            return 0.25 * Math.Sqrt(5 * (5 + 2 * Math.Sqrt(5))) * _sideLength * _sideLength;
        }
    }

    class Hexagon : Shape
    {
        private double _sideLength;

        public Hexagon(double sideLength)
        {
            _sideLength = sideLength;
        }

        public override double Area()
        {
            return 3 * Math.Sqrt(3) * _sideLength * _sideLength / 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[8];

            shapes[0] = new Circle(5);
            shapes[1] = new Rectangle(4, 6);
            shapes[2] = new Triangle(3, 4, 5);
            shapes[3] = new Square(5);
            shapes[4] = new Ellipse(3, 4);
            shapes[5] = new Pentagon(5);
            shapes[6] = new Hexagon(5);
            shapes[7] = new Circle(10);

            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"The area of the {shape.GetType().Name} is {shape.Area()}");
            }
        }
    }
}