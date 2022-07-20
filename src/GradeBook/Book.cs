using System.Collections.Generic;

namespace GradeBook
{  
      class Book
      {
        private List<double> grades;
        private string name;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            var result = 0.0;
            var count = grades.Count;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

             foreach(var number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
                result += number;
            }

            var Average = (result / count); // or result /= grades.Count; 

            Console.WriteLine($"The Average is {Average:N2}"); // Average:N2 formatted the result to give 2 digits after decimal point.
            Console.WriteLine($"The highGrade is {highGrade}");
            Console.WriteLine($"The lowGrade is {lowGrade}");
        }

    }

}

// if AddGrade method is made static, then it would not be associated with an instance, however the grades field is still an object instance. 
// Making the grades static would make the whole application have only one list of grades.