using Grades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void HighestGradeTest()
        {
            var gradeBook = new GradeBook();
            gradeBook.AddGrade(90);
            gradeBook.AddGrade(10);

            var stats = gradeBook.ComputeStatistics();
            Assert.AreEqual(90, stats.HighestGrade);
        }

        [TestMethod]
        public void LowestGradeTest()
        {
            var gradeBook = new GradeBook();
            gradeBook.AddGrade(90);
            gradeBook.AddGrade(10);

            var stats = gradeBook.ComputeStatistics();
            Assert.AreEqual(10, stats.LowestGrade);
        }

        [TestMethod]
        public void AverageGradeTest()
        {
            var gradeBook = new GradeBook();
            gradeBook.AddGrade(90);
            gradeBook.AddGrade(10);
            gradeBook.AddGrade(0);

            var stats = gradeBook.ComputeStatistics();
            Assert.AreEqual(33.33f, stats.Average, 0.01);
        }

        [TestMethod]
        public void LetterGradeTest()
        {
            var gradeBook1 = new GradeBook();
            gradeBook1.AddGrade(90);
            gradeBook1.AddGrade(100);
            var stats1 = gradeBook1.ComputeStatistics();
            Assert.AreEqual("A", stats1.LetterGrade);

            var gradeBook2 = new GradeBook();
            gradeBook2.AddGrade(80);
            gradeBook2.AddGrade(87);
            var stats2 = gradeBook2.ComputeStatistics();
            Assert.AreEqual("B", stats2.LetterGrade);

            var gradeBook3 = new GradeBook();
            gradeBook3.AddGrade(77);
            gradeBook3.AddGrade(79);
            var stats3 = gradeBook3.ComputeStatistics();
            Assert.AreEqual("C", stats3.LetterGrade);

            var gradeBook4 = new GradeBook();
            gradeBook4.AddGrade(67);
            gradeBook4.AddGrade(61);
            var stats4 = gradeBook4.ComputeStatistics();
            Assert.AreEqual("D", stats4.LetterGrade);

            var gradeBook5 = new GradeBook();
            gradeBook5.AddGrade(58);
            gradeBook5.AddGrade(12);
            var stats5 = gradeBook5.ComputeStatistics();
            Assert.AreEqual("F", stats5.LetterGrade);
        }
    }
}
