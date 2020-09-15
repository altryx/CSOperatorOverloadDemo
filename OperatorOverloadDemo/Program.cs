using System;

namespace OperatorOverloadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector myTestVector = new Vector(2, 3);

            Console.WriteLine(myTestVector.ToString());
        }

        private void SimpleExamples()
        {
            // Declare and assign variables containing primitive types
            // Ref.
            int myInteger = 6;
            string myString = "Hello World!";
            
            // Simple integer addition
            int mySecondInteger = myInteger + 1;

            // Types can be automatically cast from one type to another,
            // if defined as such
            double myDouble = mySecondInteger + 2 * myInteger / 9;

            // The above line is functionally equivalent to:
            double anotherDouble = (double)(mySecondInteger + 2 * myInteger / 9);

            // It is also possible to manually cast a variable to specific type


            // Strings can be concatenated using the + operator
            string concatenatedString = "Hello" + "World" + "!";


        }



        public struct Vector
        {
            // By making these private, a vector can only be defined at time of creation.
            private int Magnitude, Direction;

            // Defining a vector through use of a constructor
            public Vector(int magnitude, int direction)
            {
                Magnitude = magnitude;
                Direction = direction;
            }

            // Override generic object ToString() definition with our own in the form of "<magnitude,direction>"
            public override string ToString() => $"<{Magnitude}, {Direction}>";

            

            
        }
    }
}
