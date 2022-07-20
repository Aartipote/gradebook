namespace GradeBook.Tests;

public class BookTests
{
    [Fact]
    public void Test1()
    {
        //arrange
        var book = new Book("");
        book.AddGrade(89.1);
        book.AddGrade(90.5);
        book.AddGrade(77.3);

        //act
        var result = book.GetStatistics();
        
        //assert
        Assert.Equals(85.6, Average);
        Assert.Equals(90.5, highGrade);
        Assert.Equals(77.3, lowGrade);
    
    }
}

// Notes:

// dotnet new xunit --> it creates required tests project files. 
// dotnet add --> adds package or reference to the project.
// dotnet add reference <project-path> --> will add the reference to the path specificied.(Path specified should be of the .csproject file)
