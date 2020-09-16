using System;

namespace OperatorOverloadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector myTestVector = new Vector(2, 3);

            // Get the pretty print version of the myTestVector
            Console.WriteLine($"myTestVector: {myTestVector}");

            // Define two new vectors to demonstrate different vector operations
            Vector vector1 = new Vector(1, 1);
            Vector vector2 = new Vector(3, 4);

            // Vector addition
            Vector vecAddition = vector1 + vector2;
            Console.WriteLine($"Vector addition: {vector1} + {vector2} = {vecAddition}");

            // What about ++ and -- operators?
            // Console.WriteLine(vector1++);
            // Console.WriteLine(vector1--);
            // Won't compile: operator '++' cannot be applied to operand of type 'Program.Vector'
            // This is because addition/subtraction of an integer to a vector is not defined in the struct 
            // (and has no mathematical interpretation either)

            // Vector subtraction
            Vector vecSubtraction = vector1 - vector2;
            Console.WriteLine($"Vector subtraction: {vector1} - {vector2} = {vecSubtraction}");

            // Multiplication of a vector by a scalar (i.e. constant)
            Vector vecScalarMultiplication = vector1 * 3;
            Console.WriteLine($"Vector scalar multiplication: {vector1} * 3 = {vecScalarMultiplication}");

            // Division of a vector by a scalar.
            Vector vecScalarDivision = vector1 / 3.5;
            Console.WriteLine($"Vector scalar division: {vector1} / 3.5 = {vecScalarDivision}");

            // Combined operations
            Vector vecCombined = vector1 + vector2 * 3;
            Console.WriteLine($"Vector multiplication and addition: {vector1} + {vector2} * 3 = {vecCombined}");

            // Dot multiplication of two vectors
            double vecDotMultiplication = Vector.DotM(vector1, vector2);
            Console.WriteLine($"Vector dot multiplication: {vector1} ⋅ {vector2} = {vecDotMultiplication}");

            // Magnitude of the vector
            double vecMagnitude = Vector.Magnitude(vector1);
            Console.WriteLine($"Vector magnitude: |{vector1}| = {vecMagnitude}");



        }

        private void TypeExamples()
        {
            // Declare and assign variables containing primitive types
            int myInteger = 6;

            // Still an int, only left to the compiler to determine on compilation
            var implicitInteger = 6; 

            string myString = "Hello World!";

            // Simple integer addition
            int mySecondInteger = myInteger + 1; // Equals 7

            // Types can be automatically cast from one type to another,
            // if automatic typecasting is defined for the specific pairs
            // (double and int in this case)
            double myDouble = mySecondInteger + 2 * myInteger / 9;
            // The above line will return myDouble = 8 due to integer division

            // If myInteger is cast into a double however...
            myDouble = mySecondInteger + 2 * (double)myInteger / 9;
            // The result this time is 8.333333333333334

            // Strings can be concatenated using the + operator
            string concatenatedString = "Hello" + "World" + "!";


        }

        public struct Vector
        {
            // X and Y can only be defined at the time of creation.
            private double X, Y;

            // Defining a vector through use of a constructor
            public Vector(double x, double y) => (X, Y) = (x, y); //A tuple

            // Override generic ToString() definition with our own which returns 
            // a string in the form of "<X,Y>"
            public override string ToString() => $"<{X}, {Y}>";     

            // Define + and - operators for a single argument of type Vector
            public static Vector operator +(Vector vector) => vector;
            
            // Sign change
            public static Vector operator -(Vector vector) => new Vector(-vector.X, -vector.Y);

            // Vector addition
            public static Vector operator +(Vector vector1, Vector vector2)
            {
                return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
            }

            // Vector subtraction (addition with sign change)
            public static Vector operator -(Vector vector1, Vector vector2) => vector1 + (-vector2);

            // Vector scalar multiplication
            public static Vector operator *(Vector vector1, double scalar)
            {
                return new Vector(vector1.X * scalar, vector1.Y * scalar);
            }

            // Vector scalar division
            public static Vector operator /(Vector vector1, double scalar)
            {
                return new Vector(vector1.X / scalar, vector1.Y / scalar);
            }

            // Vector dot product - returns a scalar 
            // (ref. https://www.mathsisfun.com/algebra/vectors-dot-product.html)
            public static double DotM(Vector vector1, Vector vector2)
            {
                return vector1.X * vector2.X + vector1.Y + vector2.Y;
            }

            // Vector magnitude - returns a scalar 
            // (ref: https://www.mathsisfun.com/algebra/vectors.html)
            public static double Magnitude(Vector vector)
            {
                return Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
            }
        }
    }
}
