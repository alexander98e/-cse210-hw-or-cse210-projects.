Student: Alexander Beltran
Date: 04/01/2023

This is a detailed explaination of the code that  
implements the principles of: 
- abstraction
- encapsulation
- inheritance
- polymorphism.
This program can calculates the area of various shapes like 
circles, rectangles, triangles, squares, ellipses, pentagons, and hexagons.

The program starts by defining an abstract class called "Shape".
This class contains an abstract method called "Area()" which is used to calculate the area of a shape.
Since the "Shape" class is abstract, it cannot be instantiated.
The program defines various concrete classes such as "Circle", "Rectangle", "Triangle", "Square", "Ellipse", "Pentagon", 
and "Hexagon" that inherit from the "Shape" class.
Each of these classes has its own implementation of the "Area()" method 
all this to calculate the area of the respective shape.

The "Circle", "Rectangle", and "Triangle" classes have their 
OWN private fields such as "_radius", "_length", "_width", "_side1", "_side2",
and "_side3" to store the shape's dimensions. 

The "Square", "Ellipse", "Pentagon", and "Hexagon" classes inherit from "Shape" 
and pass the required dimensions to their respective base classes.

In the "Main" method, an array of "Shape" objects is created to store instances of various shapes.
Each of these instances is created using the respective class's constructor and 
passed the required dimensions. 
Finally, the "Area()" method is called on each shape instance using a loop,
and the result is printed to the console using the "GetType()" and "Name" 
properties to get the name of the shape.

--------ALSO IF YOU CAN LOOK TO THE FOUNDATIONS (1 TROUGH 4). I PROVIDED 4 CODES
TO EXPLAIN BASICALLY WHAT ABSTRACTION, ENCAPSULATION, INHERITANCE, AND POLYMORPHISM IN A SHAPE PROGRAM.--------

Thank you so much Brother Duane Richards to have the time grading this.