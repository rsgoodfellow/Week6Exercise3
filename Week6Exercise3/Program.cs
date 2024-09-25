using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Exercise3
{
    internal class Program
    {
        public class Student //class for students
        {
            public string Name { get; set; } //declares name string
            public string Grade { get; set; } //declares grade string
        }

        static List<Student> ReadCsv(string fileName) //lists of students in a csv file
        {
            var students = new List<Student>(); //creates new student list

            using (var reader = new StreamReader(fileName)) //opens csv file
            {
                reader.ReadLine(); //reads header

                while (!reader.EndOfStream) //loops through each line while its not the end
                {
                    var line = reader.ReadLine(); //reads line and sets it to a var
                    var values = line.Split(','); //splits values

                    var student = new Student //creates new student
                    {
                        Name = values[0], //sets name
                        Grade = values[1] //sets grade
                    };
                    students.Add(student); //adds student object to list
                }
            }
            return students; //returns list
        }
        static void Main(string[] args)
        {
            string fileName = "students.csv"; //file path for csv file

            List<Student> students = ReadCsv(fileName); //calls method to read the file and store the data

            // Display the student names and grades
            foreach (var student in students) //foreach loop to display every student and their grade
            {
                Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}"); //displays student and their grade
            }

            Console.Read(); //lets the user read the program
        }
    }
}
