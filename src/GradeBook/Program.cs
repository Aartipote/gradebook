using System;
using System.Collections.Generic;

namespace GradeBook{

    class Program
    {
        static void Main(string[] args)
        {
            // var p = new Program();
            // p.Main(args); // Main being static cannot be accessed via instance reference 
            // Program.Main(args); // static methos is accessed by type(/class) name 

            var book = new Book("Aarti's Grade Book");
            // book.AddGrade(89.1);
            // book.AddGrade(90.5);

            var done = false;

            while(done == false){

                System.Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine() ?? string.Empty;
        
                if (input == "q" || string.IsNullOrEmpty(input))
                {
                    done = true;
                    continue;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                catch(FormatException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                // finally
                // {
                //     Console.WriteLine("****"); // finally block is executed regardless of an exception happening or not. It is where, you want the code to be executed always.
                // }
            }


            var stats = book.GetStatistics();
       
            book.Name = "Aarya's Grade Book"; // passing value to Name property
    
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The Average is {stats.Average:N2}"); // Average:N2 formatted the result to give 2 digits after decimal point.
            Console.WriteLine($"The highGrade is {stats.highGrade}");
            Console.WriteLine($"The lowGrade is {stats.lowGrade}");
            Console.WriteLine($"The Grade is {stats.Letter}");
            // Console.WriteLine($" {book.Name}'s Grade is {stats.Letter}");
            // Console.WriteLine($" Last member is {book.grades.Last()}");

            // book.grades.add(79.0) will show error as grades is a variable declared private to be only used in Book class. 
            // However if it was declared to be public then it could be accessed.

            // var grades = new List<double>() {12.7, 10.3, 6.11, 4.1}; 
            // grades.Add(56.1);

            // if(args.Length > 0)
            // {
            //     Console.WriteLine($"Hello, {args[0]} !");
            // }
            // else
            // {
            //     Console.WriteLine("Hello!!");
            // }
        }
    }
}

// Notes:

// .NET framework is only for windows, .NET Core is for all linux, mac, windows, arm.

// .NET is a runtime, .NET provides space for programs to be run, manage memory and give instructions to the processors. It also provides library.

// <dotnet new> creates a .net project and asks for template the project would use.

// <dotnet new console> will create a template for console application

// dotnet --info -> shows the version of sdk, runtime environment information, version of the runtime.

// dotnet restore -> looks into .csproj file for any other external required dependencies. Sometimes libararies are not enough...some features are available through NuGet package 

// dotnet build -> compile the source code. It builds a efficient binary representation of source code with .dll extension.

// dotnet run --project <path> -> to run program.cs outside the project folder. dotnet run internally runs 'restore' and 'build' command. 

//Run a dll file: <dotnet <path_to_dll_file> >

// dotnet run Aarti - Aarti is a parameter passed to dotnet cli (command line interface)
// dotnet run -- Aarti - Aarti is a parameter passed to application

// [implicit typing] - letting c# decide the type of variable by using var type to declare and assign a variable. However, if assigning a variable with double value and then assigning that variable a string value is invalid.
// (valid in javascript). // double can take int, float values. 

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


// System.Console.WriteLine(); --> the type/class of console comes from System and hence if "using System;" statement is mentioned, just "Console.Write();" works
// classes must be present inside a namespace.
// classes without namespaces are legally, however, may cause clashes with the classes in the global namespace.
// legal to have more than one class per namespace. Preferred to have one class per .cs file.

// methods have () like .add() , whereas properties dont have () like .Count 

// Build an abstraction for the following reasons:
// what is the behaviour?
// what is the state/or data it holds?

// CLR/System.NullReferenceException happens check for variables not initalized.

// "this" keyword is used when field with the same name as the parameter send into method.

// statics are not associated with an object instance i.e, object reference is requied for non-static field, method or property.
// Static methods are accessed by class name only 

// dotnet new sln - in the main application folder creates a one point execution for running src and test projects.
// dotnet sln add <project-path> - adds the different projects to dotnet solution.
