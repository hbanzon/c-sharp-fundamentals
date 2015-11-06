using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests
{
    [TestClass]
    public class TypeTests
    {

        [TestMethod]
        public void VariablesHoldAReference()
        {
            var book1 = new GradeBook();
            var book2 = book1;

            book2.Name = "cat in the hat";
            Assert.AreEqual("cat in the hat", book1.Name);
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            var book1 = new GradeBook();
            book1.Name = "Tic Tac Toe";
            EditBookName(book1);
            Assert.AreEqual("Chess", book1.Name);
        }

        private void EditBookName(GradeBook book)
        {
            book.Name = "Chess";
        }

        [TestMethod]
        public void ReferenceTypesPassByValueReassigned()
        {
            var book1 = new GradeBook();
            book1.Name = "Hino B";
            ReassignBook(book1);

            // Our book is still assigned to the same Gradebook instance
            // Since a copy of our pointer was passed, changing assignment 
            // in another method does not affect our book's assignment.
            Assert.AreEqual("Hino B", book1.Name, true);
        }

        private void ReassignBook(GradeBook book)
        {
            book = new GradeBook();
            book.Name = "Not Hino B";
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            var dateTime = new DateTime(2015, 1, 1);
            dateTime = dateTime.AddDays(2);
            Assert.IsTrue(dateTime.Day == 3);
        }

        [TestMethod]
        public void UpperCaseString()
        {
            var myString = "hino";
            myString = myString.ToUpper();
            Assert.AreEqual("HINO", myString, false);
        }

        [TestMethod]
        public void UsingArrays()
        {
            float[] grades = new float[3];
            AddGrades(grades);
            Assert.AreEqual(grades[0], 89.1f);

            AddGradesToNewArray(grades);
            Assert.AreNotEqual(grades[0], 88.9f);
        }

        private void AddGrades(float[] grades)
        {
            grades[0] = 89.1f;
        }

        private void AddGradesToNewArray(float [] grades)
        {
            grades = new float[5];
            grades[0] = 88.9f;
        }
    }
}
