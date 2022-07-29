using System.Collections.Generic;

namespace GradeBook
{  
      public class Book // by default have the access modifier as internal which causes the methods, fields being restricted to be accessed only inside the project.
      {
        public List<double> grades;
        public string Name;

        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }
        public void AddGrade(double grade)
        {
            if( grade <= 100 && grade >= 0)
            {
            grades.Add(grade);
            }
            else
            {
                Console.WriteLine($"{grade}: This grade is not valid");
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.highGrade = double.MinValue;
            result.lowGrade = double.MaxValue;

            /* foreach(var grade in grades)   <--- foreach loop
            {
                result.highGrade  = Math.Max(grade, result.highGrade);
                result.lowGrade = Math.Min(grade, result.lowGrade);
                result.Average += grade;
            } */


            // do..while loop: always executes atleast once.   <--- do..while
           /* var index = 0;
            do
            {
                result.highGrade  = Math.Max(grades[index], result.highGrade);
                result.lowGrade = Math.Min(grades[index], result.lowGrade);
                result.Average += grades[index];
                index++ ;
                
            } while (index < grades.Count); */

            /* var index = 0;              <--- while loop
            while (index < grades.Count)
            {
                result.highGrade  = Math.Max(grades[index], result.highGrade);
                result.lowGrade = Math.Min(grades[index], result.lowGrade);
                result.Average += grades[index];
                index++ ;
            } */


            for(var index = 0; index < grades.Count; index++)   
            {
                if(grades[index] == 42.1)
                {
                    //break;  // break statement helps in breaking out of a loop 
                    //continue; // which makes the control to jump at the beginning of the loop for next iteration
                   /* goto done;
                    done: */  

                }
                
                
                result.highGrade  = Math.Max(grades[index], result.highGrade);
                result.lowGrade = Math.Min(grades[index], result.lowGrade);
                result.Average += grades[index];
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

