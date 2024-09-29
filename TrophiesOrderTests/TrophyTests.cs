using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[TestClass()]
public class TrophyTests
{
    [TestMethod()]
    public void ValidateCompetitionTest()
    {
        Trophy trophyWithCompetition = new Trophy() { Id = 1, Competition = "NFL", Year = 2020 };
        Trophy trophyNullCompetition = new Trophy() { Id = 2, Year = 2020 };
        Trophy trophyCompetitionUnder3Letters = new Trophy() { Id = 3, Competition = "DI", Year = 2020 };
    
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophyCompetitionUnder3Letters.ValidateCompetition());
    
        Assert.ThrowsException<ArgumentNullException>(() => trophyNullCompetition.ValidateCompetition());
    
        trophyWithCompetition.ValidateCompetition();
    }
    [TestMethod()]
    public void ValidateYearTest()
    {
        Trophy TrophyYear1More = new Trophy() { Id = 1, Competition = "bbb", Year = 2025 };
        Trophy TrophyYearMax = new Trophy() { Id = 4, Competition = "bbb", Year = 2024 };
        Trophy TrophyYear1Less = new Trophy() { Id = 5, Competition = "bbb", Year = 1969 };
        Trophy TrophyYearMin = new Trophy() { Id = 3, Competition = "bbb", Year = 1970 };
        Trophy TrophyWithOutYear = new Trophy() { Id = 3, Competition = "bbb"};

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => TrophyYear1More.ValidateYear());
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => TrophyWithOutYear.ValidateYear());
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => TrophyYear1Less.ValidateYear());
        TrophyYearMax.ValidateYear();
        TrophyYearMin.ValidateYear();
    }
    [TestMethod()]
    public void TostringTest()
    {
        Trophy TrophyToString = new Trophy() { Id = 3, Competition = "NFL", Year = 1970 };

        string result = TrophyToString.ToString();
        Assert.AreEqual("this Trophy was gotten from the NFL Competition. in the year of 1970", result);
    }
}
