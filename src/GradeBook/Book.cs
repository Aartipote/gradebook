using System.Collections.Generic;

namespace GradeBook
{  
      public class Book // by default have the access modifier as internal which causes the methods, fields being restricted to be accessed only inside the project.
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

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.highGrade = double.MinValue;
            result.lowGrade = double.MaxValue;

             foreach(var grade in grades)
            {
                result.highGrade  = Math.Max(grade, result.highGrade);
                result.lowGrade = Math.Min(grade, result.lowGrade);
                result.Average += grade;
            }

             result.Average /= grades.Count; 

             return result;

            // var result = 0.0;
            // var count = grades.Count;
            // var highGrade = double.MinValue;
            // var lowGrade = double.MaxValue;

            //  foreach(var number in grades)
            // {
            //     highGrade = Math.Max(number, highGrade);
            //     lowGrade = Math.Min(number, lowGrade);
            //     result += number;
            // }

            // var Average = (result / count); // or result /= grades.Count; 

        }

    }

}

// if AddGrade method is made static, then it would not be associated with an instance, however the grades field is still an object instance. 
// Making the grades static would make the whole application have only one list of grades.