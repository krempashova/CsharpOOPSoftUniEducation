namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Constructor_Test()
        {
            Book book = new Book("book", "author");
            Assert.AreEqual("book", book.BookName);
            Assert.AreEqual("author", book.Author);
           
        }
        [TestCase(null)]
        [TestCase("")]
        public void NameisNull(string bookName)
        {
            Book book ;
            Assert.Throws<ArgumentException>(() => new Book(bookName, "author"), $"Invalid {bookName}!");
        }
        [TestCase(null)]
        [TestCase("")]
        public void AuthorIsInvalid(string author)
        {
            Book book;
            Assert.Throws<ArgumentException>(() => new Book("book", author), $"Invalid {author}!");
        }







    }
}