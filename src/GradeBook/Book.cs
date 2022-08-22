using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args); // EventArgs is a class used when an event does not have any data associated with it, i.e when an event is only used to notify about an event and not pass any data.

    public class NamedObject // Base class, which is used to inherit the Name property
    {
        public string Name
        {
            get;
            set;
        }
        public NamedObject(string name)
        {
            Name = name;
        }

    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }

        event GradeAddedDelegate GradeAdded;

    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            Name = name;

        }

        public override event GradeAddedDelegate? GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

                // handle IO Exception by releasing the object being used.
            }

        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var score = reader.ReadLine();

                while (score != null)
                {
                    result.Add(Double.Parse(score));
                    score = reader.ReadLine();
                }

                return result;
            }
        }
    }

    public abstract class Book : NamedObject, IBook  //Abstract class is a restricted class that cannot be used to create objects.
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade); // Abstract methods can only be used in an abstract class and does not have a body. The boy is provided by the derived class.

        public abstract Statistics GetStatistics();

    }

    public class InMemoryBook : Book
    // by default have the access modifier as internal which causes the methods, fields being restricted to be accessed only inside the project.
    {
        // readonly string category; // readyonly allows to create a field which can be initialized, changed or write to only in the constructor.
        public const string CATEGORY = "Sci"; //field in caps to visualize it as an const
        public List<double> grades;
        // public string Name; // Name was set public for convenience to accesss outside. A property can be made to make the field protected as well as safely write and read the book name string.
        // private string name = string.Empty; // for avoiding null warning make the string empty.

        // public string Name // property for modifying or getting the book name. Property helps in increasing accessibility of a private field
        // {
        //     get; 
        //     set; //if declared private, it will be effectively read-only as only can be accessed in the class it has been defined. will be out of scope for any other class.  

        //     // get
        //     // {
        //     //     return name;
        //     // }
        //     // set
        //     // {
        //     //     if(!String.IsNullOrEmpty(value))
        //     //     {
        //     //         name = value;
        //     //     }
        //     // }
        // }

        public InMemoryBook(string name) : base(name) // base is 
        {
            grades = new List<double>();
            Name = name;
            // category = "Science"; // readonly field
        }
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}"); // delberatively threw an exception to catch it later.... Exceptions are thrown to handle error conditions later..
                // after throwing of exception the code searches for catch in that method and then in the method that called this method.
            }
        }

        public override event GradeAddedDelegate GradeAdded = null!;

        public void AddGrade(char letter)
        {
            switch (letter)
            {

                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                case 'D':
                    AddGrade(60);
                    break;

                case 'E':
                    AddGrade(50);
                    break;

                default:
                    AddGrade(0);
                    break;

            }


        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for (var index = 0; index < grades.Count; index++)
            {
                result.Add(grades[index]);
            }

            return result;
        }

        //  return result;

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

// if AddGrade method is made static, then it would not be associated with an instance, however the grades field is still an object instance. 
// Making the grades static would make the whole application have only one list of grades.


// Method overloading - the c# can differentiate btw two methods with the same method name by looking at the method signature(methodname and parameters passed) and does not look into the return type of the method.
// Constructors can also be overloaded. 

// Members of class - fields, methods, property, events
// A property is similar to a field, it can encapsulate a state and it can store data for an object.

// A static member of a class cannot be accessed via a object reference, it can be accessed by a type name

// readonly are nice to have when you are sure an object's fields should not be changed by any other property or method. You know what the values are when the object comes to life.
// fields and variables declared "const" cannot be changed. const variables can be accessed anywhere by declaring them as public.

// delegate is used to define a variable to define or point to a method. Delegate methods have a particular structure.

// base() is used to access members of the base class from within a derived class.

// Polymorphism uses the inherited members to perform different tasks. This allows us to perform a single action in different ways. Like logging messages in a list, file or database. 

// An override method provides a new implementation of the method inherited from a base class.