using System;
using System.Collections.Generic;
using System.Text;

namespace SIT221_Library
{
    public class Vector<T>
    {
        // This constant determines the default number of elements in a newly created vector.
        // It is also used to extended the capacity of the existing vector
        private const int DEFAULT_CAPACITY = 10;

        // This array represents the internal data structure wrapped by the vector class.
        // In fact, all the elements are to be stored in this private  array. 
        // You will just write extra functionality (methods) to make the work with the array more convenient for the user.
        private T[] data;

        // This property represents the number of elements in the vector
        public int Count { get; private set; } = 0;

        // This property represents the maximum number of elements (capacity) in the vector
        public int Capacity
        {
            get { return data.Length; }
        }

        // This is an overloaded constructor
        public Vector(int capacity)
        {
            data = new T[capacity];
        }

        // This is the implementation of the default constructor
        public Vector() : this(DEFAULT_CAPACITY) { }

        // An Indexer is a special type of property that allows a class or structure to be accessed the same way as array for its internal collection. 
        // For example, introducing the following indexer you may address an element of the vector as vector[i] or vector[0] or ...
        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                return data[index];
            }
            set
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                data[index] = value;
            }
        }

        // This private method allows extension of the existing capacity of the vector by another 'extraCapacity' elements.
        // The new capacity is equal to the existing one plus 'extraCapacity'.
        // It copies the elements of 'data' (the existing array) to 'newData' (the new array), and then makes data pointing to 'newData'.
        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[Capacity + extraCapacity];
            for (int i = 0; i < Count; i++) newData[i] = data[i];
            data = newData;
        }

        // This method adds a new element to the existing array.
        // If the internal array is out of capacity, its capacity is first extended to fit the new element.
        public void Add(T element)
        {
            if (Count == Capacity) ExtendData(DEFAULT_CAPACITY);
            data[Count] = element;
            Count++;
        }

        // This method searches for the specified object and returns the zero‐based index of the first occurrence within the entire data structure.
        // This method performs a linear search; therefore, this method is an O(n) runtime complexity operation.
        // If occurrence is not found, then the method returns –1.
        // Note that Equals is the proper method to compare two objects for equality, you must not use operator '=' for this purpose.
        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return i;
            }
            return -1;
        }

        // This method inserts a given T element into the data collection at provided index
        public void Insert(int index, T element)
        {
            // Exception is thrown if index is outside of the array range
            if (index > Count || index < 0) throw new IndexOutOfRangeException("Index is out of array range");       
            // Increase capacity if full
            if (Count == Capacity) ExtendData(DEFAULT_CAPACITY);
            // If the index equals the count, the item is added to the end of the Vector<T>
            if (index == Count)
            {
                Add(element);
            }
            // Otherwise, loop through the vector find where the index is located and insert the element
            else
            {;
                for (int i = Count; i > index; i--)
                {
                    data[i] = data[i - 1];
                }
                // Insert new element at index
                data[index] = element;
                Count++;
            }
        }

        // This method sets Count to 0 and removes all elements from vector without changing its capacity
        public void Clear()
        {
            // Set Count to 0
            Count = 0;
        }

        // This method determines whether a specific T element exists within the data list
        public bool Contains(T element)
        {
            // Iterate through the list and return true if the specified T element exists, otherwise return false
            for (int i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return true;
            }
            return false;
        }

        // This method removes the first occurrence of the specified element from the data list
        public bool Remove(T element)
        {
            // Iterate through the list to find the first occurrence of T element
            if (Contains(element))
            {
                // Use IndexOf and RemoveAt methods to find index and remove it from the list, then return true 
                RemoveAt(IndexOf(element));
                return true;
            }
            // Return false if the element is not found in the list
            else return false;
        }

        // This method removes the element located at a specified index and shuffles list to close gap
        public void RemoveAt(int index)
        {
            // Throw exception if index value is invalid
            if (index >= Count || index < 0) throw new IndexOutOfRangeException("Index is out of array range");  
            // Shuffle all elements from the index onwards to remove the element
            for (int i = index; i < Count; i++)
            {
                data[i] = data[i + 1];
            }
            Count--;
        }

        // This method returns a string that represents the current object
        public override string ToString()
        {
            // Return an empty string [] if count is 0 and there are no elements in the list
            if (Count == 0) return "[]";
            
            // Create a new empty string to build the list into
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < Count; i++)
            {
                // Format the list to begin and end with square brackets
                if (i == 0) 
                    sb.Append($"[{data[i]},");
                else if (i == Count - 1) 
                    sb.Append($"{data[i]}]");
                // Display all other elements of the list
                else
                    sb.Append($"{data[i]},");
            }
            // Returns a formatted string
            return sb.ToString();
        }
    }

    // TESTING METHODS
    class Tester
    {
        private static bool CheckIntSequence(int[] certificate, Vector<int> vector)
        {
            if (certificate.Length != vector.Count) return false;
            for (int i = 0; i < certificate.Length; i++)
            {
                if (certificate[i] != vector[i]) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Vector<int> vector = null;
            string result = "";

            // Test 1 (A)  Test new vector and creation with correct capacity
            try
            {
                int capacity = 1;
                Console.WriteLine("\nTest A: Create a new vector by calling 'Vector<int> vector = new Vector<int>(" + capacity + ");'");
                vector = new Vector<int>(capacity);
                if (vector.Capacity != capacity) throw new Exception("Vector has a wrong capacity");
                Console.WriteLine(" :: SUCCESS");
                result = result + "A";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // Test 2 (B)  Test Add() which should append all values below to the new vector
            try
            {
                Console.WriteLine("\nTest B: Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5");
                vector.Add(2); vector.Add(6); vector.Add(8); vector.Add(5); vector.Add(5); vector.Add(1); vector.Add(8); vector.Add(5); vector.Add(3); vector.Add(5);
                if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5 }, vector)) throw new Exception("Vector stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "B";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // Test 3 (C)  Test Remove() which should remove the first occurrence of the specified values below
            try
            {
                Console.WriteLine("\nTest C: Remove number 3, 7, and then 6");
                bool check = vector.Remove(3) && (!vector.Remove(7)) && vector.Remove(6) && (!vector.Remove(6));
                if (!CheckIntSequence(new int[] { 2, 8, 5, 5, 1, 8, 5, 5 }, vector)) throw new Exception("Vector stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "C";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // Test 4 (D)  Test Insert(X, Y) which should insert an element Y and inserts it at the location of index X
            try
            {
                Console.WriteLine("\nTest D: Insert number 50 at index 6, then number 0 at index 0, then number 60 at index 'vector.Count-1', then number 70 at index 'vector.Count'");
                vector.Insert(6, 50); vector.Insert(0, 0); vector.Insert(vector.Count - 1, 60); vector.Insert(vector.Count, 70);
                if (!CheckIntSequence(new int[] { 0, 2, 8, 5, 5, 1, 8, 50, 5, 60, 5, 70 }, vector)) throw new Exception("Vector stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "D";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // Test 5 (E)  Test Insert() at the index vector.Count+1
            try
            {
                Console.WriteLine("\nTest E: Insert number -1 at index 'vector.Count+1'");
                vector.Insert(vector.Count + 1, -1);
                Console.WriteLine(" :: FAIL");
                Console.WriteLine("Last operation is invalid and must throw IndexOutOfRangeException. Your solution does not match specification.");
                result = result + "-";
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(" :: SUCCESS");
                result = result + "E";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine("Last operation is invalid and must throw IndexOutOfRangeException. Your solution does not match specification.");
                result = result + "-";
            }

            // Test 6 (F)  Test RemoveAt() at the specified index values below
            try
            {
                Console.WriteLine("\nTest F: Remove number at index 4, then number index 0, and then number at index 'vector.Count-1'");
                vector.RemoveAt(4); vector.RemoveAt(0); vector.RemoveAt(vector.Count - 1);
                if (!CheckIntSequence(new int[] { 2, 8, 5, 1, 8, 50, 5, 60, 5 }, vector)) throw new Exception("Vector stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result = result + "F";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }


            // Test 7 (G)  Test RemoveAt() at the index of Vector.Count
            try
            {
                Console.WriteLine("\nTest G: Remove number at index 'vector.Count'");
                vector.RemoveAt(vector.Count);
                Console.WriteLine(" :: FAIL");
                Console.WriteLine("Last operation is invalid and must throw IndexOutOfRangeException. Your solution does not match specification.");
                result = result + "-";
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(" :: SUCCESS");
                result = result + "G";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine("Last operation is invalid and must throw IndexOutOfRangeException. Your solution does not match specification.");
                result = result + "-";
            }

            // Test 8 (H)  Test Contains() with the specified values below 
            try
            {
                Console.WriteLine("\nTest H: Run a sequence of operations: ");

                Console.WriteLine("vector.Contains(1);");
                if (vector.Contains(1)) Console.WriteLine(" :: SUCCESS");
                else throw new Exception("1 must be in the vector");

                Console.WriteLine("vector.Contains(2);");
                if (vector.Contains(2)) Console.WriteLine(" :: SUCCESS");
                else throw new Exception("2 must be in the vector");

                Console.WriteLine("vector.Contains(4);");
                if (!vector.Contains(4)) Console.WriteLine(" :: SUCCESS");
                else throw new Exception("4 must not be in the vector");

                Console.WriteLine("vector.Add(4); vector.Contains(4);");
                vector.Add(4);
                if (vector.Contains(4)) Console.WriteLine(" :: SUCCESS");
                else throw new Exception("4 must be in the vector");

                result = result + "H";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // Test 9 (I)  Test ToString() which should print all elements in the vector
            try
            {
                Console.WriteLine("\nTest I: Print the contents of the vector via calling vector.ToString();");
                Console.WriteLine(vector.ToString());
                Console.WriteLine(" :: SUCCESS");
                result = result + "I";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // Test 12 (J)   --- EXTRA TEST ADDED: Test ToString() which should print an empty list ---
            try
            {
                Console.WriteLine("\nTest J: Print an empty vector string using ToString;");
                Vector<int> list = new Vector<int>();
                string str = list.ToString();
                Console.WriteLine(str);
                if (str != "[]") throw new Exception("Vector string is incorrect. It must be created and empty ([]).");
                Console.WriteLine(" :: SUCCESS");
                result = result + "J";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }
            
            // Test 13 (K)   --- EXTRA TEST ADDED: Test RemoveAt() at edge (first/last) index values ---
            try
            {
                Console.WriteLine("\nTest K:  Remove number at the first index and the number at the last index;");
                vector.RemoveAt(0); vector.RemoveAt(vector.Count - 1);
                Console.WriteLine(" :: SUCCESS");
                result = result + "K";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // Test 12 (L)  Test Clear() which should erase entire contents of vector
            try
            {
                Console.WriteLine("\nTest L: Clear the content of the vector via calling vector.Clear();");
                vector.Clear();
                if (!CheckIntSequence(new int[] { }, vector)) throw new Exception("Vector stores incorrect data. It must be empty.");
                Console.WriteLine(" :: SUCCESS");
                result = result + "J";
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
