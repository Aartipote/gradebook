using System;
using Xunit;

namespace GradeBook.Tests
{

public class BookTests
{
    [Fact]
    public void BookStatisticsCalculations()
    {
        //arrange
        var book = new Book("");
        book.AddGrade(89.1);
        book.AddGrade(90.5);
        book.AddGrade(77.3);
        book.AddGrade(105);

        //act
        var result = book.GetStatistics();
        
        //assert
        Assert.Equal(85.6, result.Average, 1);
        Assert.Equal(90.5, result.highGrade);
        Assert.Equal(77.3, result.lowGrade);
        Assert.Equal(77.3, book.grades.Last());

    }

    // [Fact]

    // public void EnteredGradeValid()
    // {
    //     book.AddGrade(105);
    //     Book.grades
    //     Assert.Equal(105, grades[]);
    // }
}
}
// Notes:

// dotnet new xunit --> it creates required tests project files. 
// dotnet add --> adds package or reference to the project.
// dotnet add reference <project-path> --> will add the reference to the path specificied.(Path specified should be of the .csproject file)
