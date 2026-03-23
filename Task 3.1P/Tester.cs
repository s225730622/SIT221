using System;
using System.Collections.Generic;

namespace SIT221_Library
{

    public class AscendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A - B;
        }
    }

    public class DescendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return B - A;
        }
    }

    public class EvenNumberFirstComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A % 2 - B % 2;
        }
    }

    class Tester
    {
        private static bool CheckAscending(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] > vector[i + 1]) return false;
            return true;
        }

        // Add in another CheckAscending method for integer arrays
        private static bool CheckAscending(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
                if (array[i] > array[i + 1]) return false;
            return true;
        }

        private static bool CheckDescending(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] < vector[i + 1]) return false;
            return true;
        }

        // Add in another CheckDescending method for integer arrays
        private static bool CheckDescending(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
                if (array[i] < array[i + 1]) return false;
            return true;
        }        

        private static bool CheckEvenNumberFirst(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] % 2 > vector[i + 1] % 2) return false;
            return true;
        }

        // Add in another CheckEvenNumberFirst method for integer arrays
        private static bool CheckEvenNumberFirst(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
                if (array[i] % 2 > array[i + 1] % 2) return false;
            return true;
        }


        static void Main(string[] args)
        {
            string result = "";
            int problem_size = 20;
            int[] data = new int[problem_size]; data[0] = 333;
            Random k = new Random(1000);
            for (int i = 1; i < problem_size; i++) data[i] = 100 + k.Next(900);

            Vector<int> vector = new Vector<int>(problem_size);
            
            int[] array = new int[] {};
            int arrayLen = array.Length - 1;


            // ------------------ Default Sort ----------------------------------
            try
            {
                Console.WriteLine("\nTest A: Sort integer numbers applying Default Sort with the AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(null, new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "A";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest B: Sort integer numbers applying Default Sort with the DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(null, new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "B";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest C: Sort integer numbers applying Default Sort with the EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(null, new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "C";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }


            // ------------------ BubbleSort ----------------------------------

            try
            {
                Console.WriteLine("\nTest D: Sort integer numbers applying BubbleSort with the AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new BubbleSort(), new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "D";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest E: Sort integer numbers applying BubbleSort with the DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new BubbleSort(), new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "E";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest F: Sort integer numbers applying BubbleSort with the EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new BubbleSort(), new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "F";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }


            // ------------------ SelectionSort ----------------------------------

            try
            {
                Console.WriteLine("\nTest G: Sort integer numbers applying SelectionSort with the AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new SelectionSort(), new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "G";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest H: Sort integer numbers applying SelectionSort with the DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new SelectionSort(), new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "H";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest I: Sort integer numbers applying SelectionSort with the EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new SelectionSort(), new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "I";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }


            // ------------------ InsertionSort ----------------------------------

            try
            {
                Console.WriteLine("\nTest J: Sort integer numbers applying InsertionSort with the AscendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new InsertionSort(), new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "J";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest K: Sort integer numbers applying InsertionSort with the DescendingIntComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new InsertionSort(), new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "K";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine("\nTest L: Sort integer numbers applying InsertionSort with the EvenNumberFirstComparer: ");
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++) vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new InsertionSort(), new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "L";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }


            // ------------------ Extra Tests ----------------------------------

            //   Must test the sorting algorithms INDEPENDENTLY of Vector<T> class. To do this, extend the existing set of tests by adding new cases with focus 
            //   on sorting an array of data elements (e.g. integers or strings) by a direct call of the Sort methods of the BubbleSort, InsertionSort, and 
            //   SelectionSort classes. 
            //   Be creative and think about the tests that will be most effective in testing the algorithms for logical errors and runtime exceptions. These 
            //   testing strategies will need to be clearly communicated to the tutor to explain the purpose of proposed tests.  

            /*   TESTING STRATEGIES:
                 1.  Normal unsorted input
                 2.  Already sorted input
                 3.  Reverse sorted input
                 4.  Duplicate values
                 5.  Empty array
                 6.  One-element array
                 7.  Invalid computer/null comparer if relevant
            */


            // EXTRA TEST : Use BubbleSort on with the DescendingIntComparer an array of integers not created using the Vector<T> class
            try
            {
                Console.WriteLine("\nTest M: Sort integer numbers applying BubbleSort with the DescendingIntComparer and not using the Vector<T> class: ");
                // Use the int[] data array which does not need to interact the Vector<T> class
                int range = data.Length - 1;
                // Display initial array
                Console.Write("Initial data: [");
                for (int i = 0; i < range; i++) Console.Write(data[i] + ",");
                Console.WriteLine(data[range] + "]");
                // Sort array using BubbleSort and the DescendingIntComparer
                new BubbleSort().Sort(data, 0, data.Length, new DescendingIntComparer());
                Console.Write("Resulting order: [");
                for (int i = 0; i < range; i++) Console.Write(data[i] + ",");
                Console.WriteLine(data[range] + "]");
                
                // Check to see if the array has been sorted correctly using one of the added in int[] data helper methods
                if (!CheckDescending(data))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "M";
                }                
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }


            // EXTRA TEST : Use SelectionSort with the AscendingIntComparer on an array of integers not created using the Vector<T> class
            try
            {
                Console.WriteLine("\nTest N: Sort integer numbers applying SelectionSort with the AscendingIntComparer and not using the Vector<T> class: ");
                // Use the int[] data array which does not need to interact the Vector<T> class
                int range = data.Length - 1;
                // Display initial array
                Console.Write("Initial data: [");
                for (int i = 0; i < range; i++) Console.Write(data[i] + ",");
                Console.WriteLine(data[range] + "]");
                
                // Sort array using SelectionSort and the AscendingIntComparer
                new SelectionSort().Sort(data, 0, data.Length, new AscendingIntComparer());

                Console.Write("Resulting order: [");
                for (int i = 0; i < range; i++) Console.Write(data[i] + ",");
                Console.WriteLine(data[range] + "]");

                // Check to see if the array has been sorted correctly using one of the added in int[] data helper methods
                if (!CheckAscending(data))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "N";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }


            // EXTRA TEST : Use InsertionSort with the EvenNumberFirstComparer on an array of integers not created using the Vector<T> class
            try
            {
                 Console.WriteLine("\nTest O: Sort integer numbers applying InsertionSort with the EvenNumberFirstComparer and not using the Vector<T> class: ");
                // Use the int[] data array which does not need to interact the Vector<T> class
                int range = data.Length - 1;
                // Display initial array
                Console.Write("Initial data: [");
                for (int i = 0; i < range; i++) Console.Write(data[i] + ",");
                Console.WriteLine(data[range] + "]");
                
                // Sort array using InsertionSort and the EvenNumberFirstComparer
                new InsertionSort().Sort(data, 0, data.Length, new EvenNumberFirstComparer());

                Console.Write("Resulting order: [");
                for (int i = 0; i < range; i++) Console.Write(data[i] + ",");
                Console.WriteLine(data[range] + "]");

                // Check to see if the array has been sorted correctly using one of the added in int[] data helper methods
                if (!CheckEvenNumberFirst(data))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "O";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }
            
            // EXTRA TEST : Sort an array using SelectionSort with the AscendingIntComparer for an int[] array which contains duplicate values
            try
            {
                Console.WriteLine("\nTest P: Sort integer numbers applying SelectionSort with the AscendingIntComparer in an array with multiple duplicate values: ");
                // Update the int[] data array which does not need to interact the Vector<T> class
                data = [299,511,312,780,100,722,511,966,772,724,122,120,263,175,752,958,511,299,995,772];
                int range = data.Length - 1;
                // Display initial array
                Console.Write("Initial data: [");
                for (int i = 0; i < range; i++) Console.Write(data[i] + ",");
                Console.WriteLine(data[range] + "]");
                
                // Sort array using SelectionSort with the AscendingIntComparer
                new SelectionSort().Sort(data, 0, data.Length, new AscendingIntComparer());

                Console.Write("Resulting order: [");
                for (int i = 0; i < range; i++) Console.Write(data[i] + ",");
                Console.WriteLine(data[range] + "]");

                // Check to see if the array has been sorted correctly using one of the added in int[] data helper methods
                if (!CheckAscending(data))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "P";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // EXTRA TEST : Sort an array using BubbleSort with the DescendingIntComparer for an int[] array which is empty
            try
            {
                Console.WriteLine("\nTest Q: Sort integer numbers applying BubbleSort with the DescendingIntComparer when an int[] array is empty: ");
                // Update the int[] data array which does not need to interact the Vector<T> class
                data = new int[] { };
                int range = data.Length;

                // Display initial array
                Console.Write("Initial data: [");
                for (int i = 0; i < range; i++)
                {
                    Console.Write(data[i]);
                    if (i < data.Length - 1)
                        Console.Write(",");
                }
                Console.WriteLine("]");
                
                // Sort array using BubbleSort with the DescendingIntComparer
                new BubbleSort().Sort(data, 0, data.Length, new DescendingIntComparer());

                Console.Write("Resulting order: [");
                for (int i = 0; i < range; i++)
                {
                    Console.Write(data[i]);
                    if (i < data.Length - 1)
                        Console.Write(",");
                }
                Console.WriteLine("]");

                // Check to see if the array has been sorted correctly using one of the added in int[] data helper methods
                if (data.Length != 0)
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "Q";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }


            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);
            Console.ReadKey();

        }
    }
}
