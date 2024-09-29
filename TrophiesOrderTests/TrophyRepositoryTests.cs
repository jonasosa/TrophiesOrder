using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class TrophyRepositoryTests
    {
        TrophyRepository _myTrophyList = new TrophyRepository();
        [TestInitialize]
        public void Init()
        {
            _myTrophyList.Addtrophy(new Trophy() { Id = 1, Competition = "NFL", Year = 1990 });
            _myTrophyList.Addtrophy(new Trophy() { Id = 2, Competition = "NBA", Year = 2005 });
            _myTrophyList.Addtrophy(new Trophy() { Id = 3, Competition = "World Cup", Year = 2010 });
            _myTrophyList.Addtrophy(new Trophy() { Id = 4, Competition = "Olympics", Year = 2016 });
            _myTrophyList.Addtrophy(new Trophy() { Id = 5, Competition = "Champions League", Year = 2021 });
        }
        [TestMethod()]
        public void AddtrophyTest()
        {
            //TrophyRepository myTrophyList = new TrophyRepository();
            Trophy addTestTrophy = new Trophy() { Id = 2, Competition = "NFL", Year = 1990 };
            Trophy addTestTrophy2 = new Trophy() { Id = 3, Competition = "OOC", Year = 2000 };
            Trophy addTestWrongName = new Trophy() { Id = 3, Competition = "", Year = 1996 };

            var addTestTrophyId = _myTrophyList.Addtrophy(addTestTrophy);
            var result = _myTrophyList.Get();
            var addTestTrophy2Id = _myTrophyList.Addtrophy(addTestTrophy2);
            var result2 = _myTrophyList.Get();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => addTestWrongName.ValidateCompetition());
            Assert.AreEqual(6, addTestTrophyId.Id);
            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(7, addTestTrophy2Id.Id);
            Assert.AreEqual(7, result2.Count);
        }
        [TestMethod()]
        public void RemoveTest()
        {
            
            Trophy toStayTestTrophy = new Trophy() { Competition = "NFL", Year = 1990};
            Trophy removeTestTrophy = new Trophy { Competition = "OOC", Year = 1996};
            _myTrophyList.Addtrophy(toStayTestTrophy);
            _myTrophyList.Addtrophy(removeTestTrophy);

            var removedTeacher = _myTrophyList.Remove(8);
            var removedTeacherNull = _myTrophyList.Remove(9);
            var result = _myTrophyList.Get();

            Assert.IsNull(removedTeacherNull);
            Assert.IsNull(_myTrophyList.Get(8));
            Assert.AreEqual(7, result.Count);
            Assert.IsNotNull(_myTrophyList.Get(1));

        }
        [TestMethod()]
        public void UpdateTest()
        {
            
            Trophy myFirstTrophy = new Trophy() { Competition = "NFL", Year = 1990 };
            Trophy updateingMyFirstTrophy = new Trophy { Competition = "OOC", Year = 1996 };

            _myTrophyList.Addtrophy(myFirstTrophy);
            var result = _myTrophyList.Update(1, updateingMyFirstTrophy);
            var resultNull = _myTrophyList.Update(30, updateingMyFirstTrophy);

            Assert.IsNull(resultNull);
            Assert.IsNotNull(result);
            Assert.AreEqual("OOC", result.Competition);
            Assert.AreEqual(1996, result.Year);
        }
    }
}