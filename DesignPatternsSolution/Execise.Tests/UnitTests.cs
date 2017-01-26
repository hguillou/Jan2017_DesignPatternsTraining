using Exercise;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Execise.Tests
{
    [TestClass]
    public class UnitTests
    {
        //test the two calls to library instance return same instance
        [TestMethod]
        public void LibraryShouldBeSingleton()
        {
            //check that when you create a Library instance second time, 
            //you get exactly the same instance as for a very first time
            var library1 = Library.getInstance();
            var library2 = Library.getInstance();
            Assert.AreSame(library1, library2);
        }

        //test that an book was registered successfully by checking the returned Id value is not -1
        [TestMethod]
        public void BookShouldRegister()
        {
            var library = Library.getInstance();
            int test = library.Register(new Book("Murakami", "19Q4", 2002, 1));
            Assert.AreNotSame(-1, test);

        }

        //test that an customer was registered successfully by checking the returned Id value is not -1
        [TestMethod]
        public void CustomerShouldRegister()
        {
            var library = Library.getInstance();
            int test = library.Register(new Customer("Barb", "Upside Down"));
            Assert.AreNotSame(-1, test);
        }

        //test that a book can be borrowed
        [TestMethod]
        public void CanBorrowBook()
        {
            //create a borrowable book with available amount more than one. 
            //Run BorrowOne method of the BookBorrowable instance. Check that total amount was reduced by one.
            
            int initialAmount = 10;
            
            Book book = new Book("Murakami", "19Q4", 2002, initialAmount);
            BookBorrowable borrowedBook = new BookBorrowable(book, new Decorator());

            borrowedBook.BorrowOne();

            Assert.AreEqual(initialAmount - 1, book.AvailableAmount);

        }       
    }
}
