using System;

namespace Zadatak1
{
    class Class1
    {
        public static void ListExample(IIntegerList listOfIntegers)
        {
            listOfIntegers.Add(1);   // [1]
            listOfIntegers.Add(2);   // [1,2]
            listOfIntegers.Add(3);   // [1,2,3]
            listOfIntegers.Add(4);   // [1,2,3,4]
            listOfIntegers.Add(5);   // [1,2,3,4,5]
            listOfIntegers.RemoveAt(0); // [2,3,4,5]
            listOfIntegers.Remove(5); //[2,3,4]
            Console.WriteLine(listOfIntegers.Count); // 3
            Console.WriteLine(listOfIntegers.Remove(100)); //  false

            try
            {
                Console.WriteLine(listOfIntegers.RemoveAt(5));
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(false);
            };

            listOfIntegers.Clear(); // []
            Console.WriteLine(listOfIntegers.Count); //
        }

        static void Main(string[] args)
        {
            var listOfIntegers = new IntegerList();
            ListExample(listOfIntegers);
        }
    }
}
