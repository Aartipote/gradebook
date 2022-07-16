using System;
using System.Collections.Generic;

namespace GradeBook{

    class Program
    {
        static void Main(string[] args)
        {
            //double[] numbers;
            //numbers[0] = 10.7; [BIG Doubt - numbers are not intialized]

            // var numbers = new double[3];
            // numbers[0] = 12.7;
            // numbers[1] = 10.3;
            // numbers[2] = 6.11;
            // var result = numbers[0] + numbers[1];
            // result = result + numbers[2];
            // Console.WriteLine(result);

            //var numbers = new[] {12.7, 10.3, 6.11, 4.1};           
            //System.Console.WriteLine(result);
            
            // Arrays and lists share a lot of the same behaviour, however list are more dynamic[addition of elements to the list] and arrays have a definative size.
            // var grades = new List<double>();
            // grades.Add(56.1);

            var grades = new List<double>() {12.7, 10.3, 6.11, 4.1};
            grades.Add(56.1);


            var result = 0.0;
            var count = grades.Count();
            foreach(var grade in grades)
            {
                result += grade;
            }
            var Average = (result / count); // or result /= grades.Count; 
            //Console.WriteLine(Average);
            Console.WriteLine($"The Average is {Average:N2}"); // Average:N2 formatted the result to give 2 digits after decimal point.


            if(args.Length > 0)
            {
                Console.WriteLine($"Hello, {args[0]} !");
            }
            else
            {
                Console.WriteLine("Hello!!");
            }
        }
    }
}

// Notes:

// .NET framework is only for windows, .NET Core is for all linux, mac, windows, arm.

// .NET is a runtime, .NET provides space for programs to be run, manage memory and give instructions to the processors. It also provides library.

// dotnet --info -> shows the version of sdk, runtime environment information, version of the runtime.

// dotnet restore -> looks into .csproj file for any other external required dependencies. Sometimes libararies are not enough...some features are available through NuGet package 

// dotnet build -> compile the source code. It builds a efficient binary representation of source code with .dll extension.

// dotnet run --project <path> -> to run program.cs outside the project folder. dotnet run internally runs 'restore' and 'build' command. 



// [implicit typing] - letting c# decide the type of variable by using var type to declare and assign a variable. However, if assigning a variable with double value and then assigning that variable a string value is invalid.
// (valid in javascript). // double can take int, float values. 
// System.Console.WriteLine(); --> the type/class of console comes from System and hence if "using System;" statement is mentioned, just "Console.Write();" works