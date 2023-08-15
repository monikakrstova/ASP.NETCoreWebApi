using BookApp.Models;

namespace BookApp
{
    public static class StaticDb
    {

        public static List<Book> Books = new List<Book>()
        {
            new Book { Author = "J.K. Rowling", Title = "Harry Potter and the Sorcerer's Stone" },
            new Book { Author = "George Orwell", Title = "1984" },
            new Book { Author = "Harper Lee", Title = "To Kill a Mockingbird" },
            new Book { Author = "J.R.R. Tolkien", Title = "The Hobbit" },
            new Book { Author = "Jane Austen", Title = "Pride and Prejudice" },
            new Book { Author = "F. Scott Fitzgerald", Title = "The Great Gatsby" },
            new Book { Author = "Mark Twain", Title = "The Adventures of Huckleberry Finn" },
            new Book { Author = "Gabriel García Márquez", Title = "One Hundred Years of Solitude" },
            new Book { Author = "Agatha Christie", Title = "Murder on the Orient Express" },
            new Book { Author = "Leo Tolstoy", Title = "War and Peace" }
        };

    }
        
}
