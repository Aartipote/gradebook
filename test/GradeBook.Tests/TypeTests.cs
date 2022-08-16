using System;
using Xunit;

namespace GradeBook.Tests
{
    
    public delegate string WriteLogDelegate(string logMessage); 

    public class TypeTests
    {   
        int count = 0;
       
        [Fact]
        public void WriteLogDelegateCanPointToAnotherMethod() 
        {
            // WriteLogDelegate log; // delegate field
            // log = ReturnMessage; // log = new WriteLogDelegate(ReturnMessage);  //delegate variable pointing to a method

            WriteLogDelegate log = ReturnMessage;
            log +=ReturnMessage;
            log +=AnotherIncrementDelegate;
            log +=AnotherIncrementDelegate;

            var result = log("Hello!!"); // invoking mulitple delegate methods as delegate defined as return type and parameter type as string.

            Assert.Equal(4, count); 
        }

        string AnotherIncrementDelegate(string message) // another method that delegate can point to as return type is string and has one parameter string.
        {
           count += 1;
           return message; 
        }
        
        string ReturnMessage(string message) // a method that delegate can point to as return type is string and has one parameter string.
        {
           count += 1;
           return message; 
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            var name = "aarti";
            var upper = MakeUpperCase(name);
        
            Assert.Equal("aarti", name);
            Assert.Equal("AARTI", upper);
        }
            private string MakeUpperCase(string parameter)
            {
            return parameter.ToUpper(); 
            }


        [Fact]
        public void ValueTypesInt()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42,x);
        }
            private void SetInt(ref int z)
            {
            z = 42;
            }
            public int GetInt()
            {
                return 3;
            }


        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");   
            var book2 = GetBook("Book 2"); 

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }
        Book GetBook(string name)
            {
                return new Book(name);
            }


        [Fact]
        public void CSharpCanPassByRef()
        {

            var book1 = GetBook("Book 1"); 
            // var book1 = new Book("Book 1");
            GetBookSetNameByRef(ref book1, "NewBook") ; 
        
            Assert.Equal("NewBook", book1.Name);
        }
            private void GetBookSetNameByRef(ref Book book, string name)
            {
                // book = new Book(name);
                book.Name = name; //works but logic???
            }


        [Fact]
        public void CSharpIsPassByValue()
        {

            var book1 = GetBook("Book 1"); 
            // var book1 = new Book("Book 1");
            GetBookSetName(book1, "NewBook") ; 
        
            Assert.Equal("Book 1", book1.Name);
        }
            private void GetBookSetName(Book book, string name)
            {
                book = new Book(name);
                // book.Name = name;
            }


        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1"); 
            SetName(book1, "NewBook") ; 
        
            Assert.Equal("NewBook", book1.Name);
        }

            private void SetName(Book book, string name)
            { 
                book.Name = name;
            }


        [Fact]
        public void TwoVariablesReferenceSameObjects()
        {
            var book1 = GetBook("Book 1");   
            var book2 = book1; 

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

}
}
// Notes:

// assert.equal -> checks that objects have same type and value
// assert.same -> checks if reference indicate the same object in memory. 
// for checking if a type is struct or class (ref by val or ref by ref), put the cursor on the type and press F12 to see the sourcecode.
// string is a ref type but behaves like a value type.
