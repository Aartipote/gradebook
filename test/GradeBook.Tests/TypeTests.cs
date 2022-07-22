using System;
using Xunit;

namespace GradeBook.Tests
{

public class TypeTests
{

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
        book = new Book(name);
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
