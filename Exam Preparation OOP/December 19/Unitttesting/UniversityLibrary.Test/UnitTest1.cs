namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_TEST()
        {
            TextBook textBook = new TextBook("drama", "idiot", "category");
            Assert.AreEqual("drama", textBook.Title);
            Assert.AreEqual("idiot", textBook.Author);
            Assert.AreEqual("category", textBook.Category);
        }
        [Test]
        public void TEST_cONSTRUCORlabary()
        {
            TextBook textBook = new TextBook("drama", "idiot", "category");
            UniversityLibrary library = new UniversityLibrary();
            library.AddTextBookToLibrary(textBook);
            Assert.AreEqual(1, textBook.InventoryNumber);
        }
        [Test]
        public void AddingbookToLibary()
        {
            TextBook textBook = new TextBook("drama", "idiot", "category");
            TextBook textBook2 = new TextBook("bla", "maloumna", "category2");

            UniversityLibrary library = new UniversityLibrary();

            library.AddTextBookToLibrary(textBook);
            library.AddTextBookToLibrary(textBook2);
            Assert.AreEqual(2, library.Catalogue.Count);
          
        }
        [Test]
        public void TestingADDTOSTRING()
        {
            TextBook textBook = new TextBook("drama", "idiot", "category");

            UniversityLibrary library = new UniversityLibrary();

            var actualResult = library.AddTextBookToLibrary(textBook);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: drama - 1");
            sb.AppendLine($"Category: category");
            sb.AppendLine($"Author: idiot");

            var expectedResult = sb.ToString().TrimEnd();

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void LoanTextBook_Test()
        {
            TextBook textBook = new TextBook("drama", "idiot", "category");

            UniversityLibrary library = new UniversityLibrary();
            library.AddTextBookToLibrary(textBook);
            library.LoanTextBook(1, "Dimitrichko");
            var actualResult = library.LoanTextBook(1, "dIMITRICHKO");
            var expectedResult = "drama loaned to dIMITRICHKO.";

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(textBook.Holder, "dIMITRICHKO");
        }
        [Test]
        public void LoanedNextCASE()
        {
            TextBook textBook = new TextBook("DRAMA", "typo", "potypo");

            UniversityLibrary library = new UniversityLibrary();

            library.AddTextBookToLibrary(textBook);

            library.LoanTextBook(1, "Viking");
            var actualResult = library.LoanTextBook(1, "Viking");
            var expectedResult = "Viking still hasn't returned DRAMA!";

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ReturnBook_Test()
        {
            TextBook textBook = new TextBook("DRAMA", "typo", "potypo");

            UniversityLibrary library = new UniversityLibrary();

            library.AddTextBookToLibrary(textBook);

            library.LoanTextBook(1, "Viking");
            var actualResult = library.ReturnTextBook(1);
            var expectedResult = "DRAMA is returned to the library.";

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(textBook.Holder, string.Empty);
        }
    }
}