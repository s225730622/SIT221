using System;
using System.Collections.Generic;
using System.Text;
/**/

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

    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return Id + "[" + Name + "]";
        }
        //  Implement CompareTo(T) method which compares this Student ID to another Student ID and sorts
        public int CompareTo(Student another)
        {
            return this.Id.CompareTo(another.Id);
        }
    }

    //  This comparator class sorts the sequence stored in the Vector<Student> class in ascending order of IDs
    public class AscendingIDComparer : IComparer<Student>
    {
        public int Compare(Student a, Student b)
        {
            return a.Id - b.Id;
        }
    }

    //  This comparator class sorts the sequence stored in the Vector<Student> class in descending order of names (and then by descending IDs if there are any ties)
    public class DescendingNameDescendingIdComparer : IComparer<Student>
    {
        public int Compare(Student a, Student b)
        {
            if (b.Name.CompareTo(a.Name) != 0) 
                return b.Name.CompareTo(a.Name);

            else 
                return b.Id - a.Id;
        }
    }

/**/
// This is the method where all the testing goes.
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
            
            // Test 1 (A)  Test Sort() method functionality 
            try
            {
                Console.WriteLine("\nTest A: Run a sequence of operations: ");
                Console.WriteLine("Create a new vector by calling 'Vector<int> vector = new Vector<int>(50);'");
                vector = new Vector<int>(50);
                Console.WriteLine("Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9");
                vector.Add(2); vector.Add(6); vector.Add(8); vector.Add(5); vector.Add(5); vector.Add(1); vector.Add(8); vector.Add(5);
                vector.Add(3); vector.Add(5); vector.Add(7); vector.Add(1); vector.Add(4); vector.Add(9);
                if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 }, vector)) throw new Exception("Vector stores an incorrect sequence of integers after adding new elements");
                Console.WriteLine("Sort the integers in the default order defined by the native CompareTo() method");
				
				vector.Sort();
                int[] array = new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 };
                Array.Sort(array, 0, 14);
				
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckIntSequence(array, vector)) throw new Exception("Vector stores an incorrect sequence of integers after sorting them");
                Console.WriteLine(" :: SUCCESS");
                result = result + "A";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }
			
            // Test 2 (B)  Test Sort(IComparer<T> comparer) method and AscendingIntComparer functionalities
            try
            {
                Console.WriteLine("\nTest B: Run a sequence of operations: ");
                Console.WriteLine("Create a new vector by calling 'Vector<int> vector = new Vector<int>(50);'");
                vector = new Vector<int>(50);
                Console.WriteLine("Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9");
                vector.Add(2); vector.Add(6); vector.Add(8); vector.Add(5); vector.Add(5); vector.Add(1); vector.Add(8);
                vector.Add(5); vector.Add(3); vector.Add(5); vector.Add(7); vector.Add(1); vector.Add(4); vector.Add(9);
                if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 }, vector)) throw new Exception("Vector stores an incorrect sequence of integers after adding new elements");
                Console.WriteLine("Sort the integers in the order defined by the AscendingIntComparer class");
				
                vector.Sort(new AscendingIntComparer());
                int[] array = new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 };
                Array.Sort(array, 0, 14, new AscendingIntComparer());
				
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckIntSequence(array, vector)) throw new Exception("Vector stores an incorrect sequence of integers after sorting them");
                Console.WriteLine(" :: SUCCESS");
                result = result + "B";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // Test 3 (C)  Test Sort(IComparer<T> comparer) method and DescendingIntComparer functionalities
            try
            {
                Console.WriteLine("\nTest C: Run a sequence of operations: ");
                Console.WriteLine("Create a new vector by calling 'Vector<int> vector = new Vector<int>(50);'");
                vector = new Vector<int>(50);
                Console.WriteLine("Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9");
                vector.Add(2); vector.Add(6); vector.Add(8); vector.Add(5); vector.Add(5); vector.Add(1); vector.Add(8);
                vector.Add(5); vector.Add(3); vector.Add(5); vector.Add(7); vector.Add(1); vector.Add(4); vector.Add(9);
                if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 }, vector)) throw new Exception("Vector stores an incorrect sequence of integers after adding new elements");
                Console.WriteLine("Sort the integers in the order defined by the DescendingIntComparer class");

                vector.Sort(new DescendingIntComparer());
                int[] array = new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 };
                Array.Sort(array, 0, 14, new DescendingIntComparer());

                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckIntSequence(array, vector)) throw new Exception("Vector stores an incorrect sequence of integers after sorting them");
                Console.WriteLine(" :: SUCCESS");
                result = result + "C";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }
            
            // Test 4 (D)  Test Sort(IComparer<T> comparer) method and EvenNumberFirstComparer functionalities
            try
            {
                Console.WriteLine("\nTest D: Run a sequence of operations: ");
                Console.WriteLine("Create a new vector by calling 'Vector<int> vector = new Vector<int>(50);'");
                vector = new Vector<int>(50);
                Console.WriteLine("Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9");
                vector.Add(2); vector.Add(6); vector.Add(8); vector.Add(5); vector.Add(5); vector.Add(1); vector.Add(8);
                vector.Add(5); vector.Add(3); vector.Add(5); vector.Add(7); vector.Add(1); vector.Add(4); vector.Add(9);
                if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 }, vector)) throw new Exception("Vector stores an incorrect sequence of integers after adding new elements");
                Console.WriteLine("Sort the integers in the order defined by the EvenNumberFirstComparer class");
                
                vector.Sort(new EvenNumberFirstComparer());
                int[] array = new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 };
                Array.Sort(array, 0, 14, new EvenNumberFirstComparer());

                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckIntSequence(array, vector)) throw new Exception("Vector stores an incorrect sequence of integers after sorting them");
                Console.WriteLine(" :: SUCCESS");
                result = result + "D";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }
            
            // Test 5 (E)  Test Student class which contains CompareTo() method and implements IComparable<Student> interface
            try
            {
                string[] names = new string[] { "Kelly", "Cindy", "John", "Andrew", "Richard", "Michael", "Guy", "Elicia", "Tom", "Iman", "Simon", "Vicky" };
                Random random = new Random(100);
                Console.WriteLine("\nTest E: Run a sequence of operations: ");
                Console.WriteLine("Create a new vector of Student objects by calling 'Vector<Student> students = new Vector<Student>();'");
                Vector<Student> students = new Vector<Student>();
                for (int i = 0; i < 14; i++)
                {
                    Student student = new Student() { Name = names[random.Next(0, names.Length)], Id = i };
                    Console.WriteLine("Add student with record: " + student.ToString());
                    students.Add(student);
                }
                Console.WriteLine("Sort the students in the default order defined by the native CompareTo() method");
                students.Sort();
                
                Console.WriteLine("Print the vector of students via students.ToString();");
                Console.WriteLine(students.ToString());
                Console.WriteLine(" :: SUCCESS");
                result = result + "E";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }
            
            // Test 6 (F)  Test comparator class AscendingIDComparer() functionality
            try
            {
                string[] names = new string[] { "Kelly", "Cindy", "John", "Andrew", "Richard", "Michael", "Guy", "Elicia", "Tom", "Iman", "Simon", "Vicky" };
                Random random = new Random(100);
                Console.WriteLine("\nTest F: Run a sequence of operations: ");
                Console.WriteLine("Create a new vector of Student objects by calling 'Vector<Student> students = new Vector<Student>();'");
                Vector<Student> students = new Vector<Student>();
                for (int i = 0; i < 14; i++)
                {
                    Student student = new Student() { Name = names[random.Next(0, names.Length)], Id = i };
                    Console.WriteLine("Add student with record: " + student.ToString());
                    students.Add(student);
                }
                Console.WriteLine("Sort the students in the order defined by the AscendingIDComparer class");
                
                students.Sort(new AscendingIDComparer());
                Console.WriteLine("Print the vector of students via students.ToString();");
                Console.WriteLine(students.ToString());

                Console.WriteLine(" :: SUCCESS");
                result = result + "F";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }
            
            // Test 7 (G)  Test comparator class DescendingNameDescendingIdComparer() functionality
            try
            {
                string[] names = new string[] { "Kelly", "Cindy", "John", "Andrew", "Richard", "Michael", "Guy", "Elicia", "Tom", "Iman", "Simon", "Vicky" };
                Random random = new Random(100);
                Console.WriteLine("\nTest G: Run a sequence of operations: ");
                Console.WriteLine("Create a new vector of Student objects by calling 'Vector<Student> students = new Vector<Student>();'");
                Vector<Student> students = new Vector<Student>();
                for (int i = 0; i < 14; i++)
                {
                    Student student = new Student() { Name = names[random.Next(0, names.Length)], Id = i };
                    Console.WriteLine("Add student with record: " + student.ToString());
                    students.Add(student);
                }
                Console.WriteLine("Sort the students in the order defined by the DescendingNameDescendingIdComparer class");
                
                students.Sort(new DescendingNameDescendingIdComparer());
                Console.WriteLine("Print the vector of students via students.ToString();");
                Console.WriteLine(students.ToString());

                Console.WriteLine(" :: SUCCESS");
                result = result + "G";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }
            
            // Test 8 (H)  Test RemoveAt() functionality when the index refers to the last element in the array
            try
            {
                string[] names = new string[] { "Kelly", "Cindy", "John", "Andrew", "Richard", "Michael", "Guy", "Elicia", "Tom", "Iman", "Simon", "Vicky" };
                Console.WriteLine("\nTest H: Run a sequence of operations: ");
                Console.WriteLine("Create a new vector of Student objects by calling 'Vector<Student> students = new Vector<Student>();'");
                Vector<Student> students = new Vector<Student>();
                for (int i = 0; i < names.Length; i++)
                {
                    Student student = new Student() { Name = names[i], Id = i };
                    Console.WriteLine("Add student with record: " + student.ToString());
                    students.Add(student);
                }
                Console.WriteLine("Remove the Students name which is last in the vector when sorted by Ascending ID");
                students.Sort(new AscendingIDComparer());
                students.RemoveAt(names.Length - 1);
                Console.WriteLine("Print the new vector of students via students.ToString();");
                Console.WriteLine(students.ToString());

                Console.WriteLine(" :: SUCCESS");
                result = result + "H";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // Test 9 (I)  Test functionality of Sort(IComparer<T>) method when the comparer given is null
            try
            {
                IComparer<Student> comparer = null;

                string[] names = new string[] { "Kelly", "Cindy", "John", "Andrew", "Richard", "Michael", "Guy", "Elicia", "Tom", "Iman", "Simon", "Vicky" };
                Console.WriteLine("\nTest I: Run a sequence of operations: ");
                Console.WriteLine("Create a new vector of Student objects by calling 'Vector<Student> students = new Vector<Student>();'");
                Vector<Student> students = new Vector<Student>();
                for (int i = 0; i < names.Length; i++)
                {
                    Student student = new Student() { Name = names[i], Id = i };
                    Console.WriteLine("Add student with record: " + student.ToString());
                    students.Add(student);
                }
                Console.WriteLine("Test Sort(comparer) method when comparer parameter is null");
                students.Sort(comparer);
                Console.WriteLine("Print the resulting vector of students via students.ToString();");
                Console.WriteLine(students.ToString());

                Console.WriteLine(" :: SUCCESS");
                result = result + "I";
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
