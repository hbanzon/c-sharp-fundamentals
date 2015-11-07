using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = GetGradeBookName();
            var gradeBook = InitializeGradeBook(name);

            try {
                PrintStats(gradeBook.ComputeStatistics());
            } catch (DivideByZeroException ex) {
                Console.WriteLine("Divide By Zero Exception: " + ex.StackTrace);
                return;
            }
            
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }

        static string GetGradeBookName()
        {
            Console.Write("Enter Grade Book's Name: ");
            return Console.ReadLine();
        }

        static IGradeTracker InitializeGradeBook(string name)
        {
            var gradeBook = new ThrowAwayGradeBook();
            gradeBook.NameChanged += OnNameChanged;
            gradeBook.AddGrade(100f);
            gradeBook.AddGrade(80f);
            gradeBook.AddGrade(71f);
            gradeBook.AddGrade(92f);
            gradeBook.AddGrade(33f);
            gradeBook.Name = name;
            return gradeBook;
        }

        static void PrintStats(GradeStatistics stats)
        {
            WriteLine("Number of Grades", stats.NumberOfGrades);
            WriteLine("Highest Grade", stats.HighestGrade);
            WriteLine("Lowest Grade", stats.LowestGrade);
            WriteLine("Average Grade", stats.Average);
            WriteLine("Grade", stats.LetterGrade);
            WriteLine("Comment", PerformanceRating(stats.LetterGrade));
        }

        static string PerformanceRating(string letterGrade)
        {
            switch (letterGrade)
            {
                case "A":
                    return "Excellent";
                case "B":
                    return "Very Good";
                case "C":
                    return "Good";
                case "D":
                    return "Bad";
                default:
                    return "Failing";
            }
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade Book [{args.OldName}] has been renamed to  [{args.NewName}]");
        }

        public static void WriteLine(string description, int number)
        {
            Console.WriteLine($"{description}: {number}");
        }

        public static void WriteLine(string description, float number)
        {
            Console.WriteLine($"{description}: {number:F2}");
        }

        public static void WriteLine(string description, string value)
        {
            Console.WriteLine($"{description}: {value}");
        }
    }
}
