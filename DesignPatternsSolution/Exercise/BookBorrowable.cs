namespace Exercise
{
    public class Decorator
    {
        public void BorrowOne(Item book)
        {
            book.AvailableAmount--;
        }
    }

    public class BookBorrowable : Book
    {
        private Book book;
        private Decorator decorator;
        public BookBorrowable(Book book, Decorator decorator) : base(book.Author, book.NameOrTitle, book.YearCreated, book.AvailableAmount)
        {
            this.book = book;
            this.decorator = decorator;
        }

        public void BorrowOne()
        {
            decorator.BorrowOne(book);
        }
    }
}