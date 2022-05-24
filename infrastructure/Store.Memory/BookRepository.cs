using System;
using System.Collections.Generic;
using System.Linq;
namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 13246-65348", "D. Knuth", "Art Of Programming", "Knuth began the project, originally conceived as a single book with twelve chapters, in 1962. The first three volumes of what was then expected to be a seven-volume set were published in 1968, 1969, and 1973. Work began in earnest on Volume 4 in 1973, but was suspended in 1977 for work on typesetting prompted by the second edition of Volume 2.", 1300m),
            new Book(2, "ISBN 13246-65349", "M. Fowler", "Refactoring", "Refactoring is a controlled technique for improving the design of an existing code base. Its essence is applying a series of small behavior-preserving transformations, each of which \"too small to be worth doing\".", 650m),
            new Book(3, "ISBN 13246-65350", "B. Kernighan, D. Ritchie", "C Programming Language", "The authors present the complete guide to ANSI standard C language programming. Written by the developers of C, this new version helps readers keep up with the finalized ANSI standard for C while showing how to take advantage of C's rich set of operators, economy of expression, improved control flow, and data structures. The 2/E has been completely rewritten with additional examples and problem sets to clarify the implementation of difficult language constructs.", 950m),
         };

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var fountBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;
            return fountBooks.ToArray();

        }

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn.Contains(isbn))
                        .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query)
                                    || book.Title.Contains(query))
                                      .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}
