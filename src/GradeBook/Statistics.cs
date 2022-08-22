using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double lowGrade;
        public double highGrade;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
 

                    case var d when d >= 80.0: //& d < 90:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';
     

                    case var d when d >= 60.0:
                        return 'D';
      

                    case var d when d >= 50.0:
                        return 'E';
                    
                    default:
                        return 'F';
       
                }
            }
        }
    public double Count;
        public double Sum;

        public Statistics()
        {
            Sum = 0.0;
            highGrade = double.MinValue;
            lowGrade = double.MaxValue;
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            highGrade = Math.Max(number, highGrade);
            lowGrade = Math.Min(number, lowGrade);

        }

    }
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

    // Average /= grades.Count; As sum was counted into Average variable 
}



