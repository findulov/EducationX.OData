using EducationX.Domain.Entities;
using EducationX.Infrastructure.Tests.Database;
using NUnit.Framework;
using System.Linq;

namespace EducationX.Infrastructure.Tests
{
    public class AcademicRankTests
    {
        private InMemoryDbContext dbContext;


        [SetUp]
        public void Setup()
        {
            dbContext = InMemoryDbContext.Create();
        }

        [Test]
        public void ThereMustBeFourAcademicRanksPositiveTest()
        {
            dbContext.AcademicRanks.Add(new AcademicRank(1, "Professor"));
            dbContext.AcademicRanks.Add(new AcademicRank(2, "Associate professor"));
            dbContext.AcademicRanks.Add(new AcademicRank(3, "Assistant Professor"));
            dbContext.AcademicRanks.Add(new AcademicRank(4, "Lecturer"));

            dbContext.SaveChanges();

            Assert.AreEqual(dbContext.AcademicRanks.ToList().Count, 4);
        }

        [Test]
        public void ThereMustBeFourAcademicRanksNegativeTest()
        {
            dbContext.AcademicRanks.Add(new AcademicRank(1, "Asdf"));

            dbContext.SaveChanges();

            Assert.AreEqual(dbContext.AcademicRanks.ToList().Count, 4);
        }
    }
}
