﻿using System.Collections.Generic;
using System.Linq;

namespace Store.Web.App
{
    public class BookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public IReadOnlyCollection<BookModel> GetAllByQuery(string query)
        {

            var books = Book.IsIsbn(query)
                        ? bookRepository.GetAllByIsbn(query)
                        : bookRepository.GetAllByTitleOrAuthor(query);

            return books.Select(Map)
                         .ToArray();
        }
        public IReadOnlyCollection<BookModel> GetAll()
        {
            var books = bookRepository.GetAll();

            return books.Select(Map)
                        .ToArray();
        }
        public IReadOnlyCollection<BookModel> GetRandom(int index)
        {
            var books = bookRepository.GetRandom(index);

            return books.Select(Map)
                        .ToArray();
        }
        public BookModel GetById(int id)
        {
            var book = bookRepository.GetById(id);

            return Map(book);
        }
        private BookModel Map(Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Isbn = book.Isbn,
                Image = book.Image,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price
            };
        }
    }
}
