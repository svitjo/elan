using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElanWaveBookStore.Interface;
using ElanWaveBookStore.Models;

namespace ElanWaveBookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public IEnumerable<Book> GetAll()
        {
            var books = _bookRepository.GetAll();
            return books;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            var b = await _bookRepository.CreateAsync(book);
            return b;
        }

        public async Task<Book> GetAsync(Guid bookID)
        {
            Book book = await _bookRepository.GetAsync(bookID);
            return book;
        }

        public async Task<Book> Update(Book book)
        {
            Book updateBook = await _bookRepository.Update(book);
            return updateBook;
        }

        public async Task Delete(Guid bookID)
        {
            await _bookRepository.Delete(bookID);
        }
    }
}
