using ElanWaveBookStore.Data;
using ElanWaveBookStore.Interface;
using ElanWaveBookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElanWaveBookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _dbContext;

        public BookRepository(DataContext dataContext)
        {
            _dbContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            //var httpContext = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public IEnumerable<Book> GetAll()
        {
            var books = _dbContext.Books;
            return books;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            book.BookID = new Guid();
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            var b = _dbContext.Books.FirstOrDefault(b => b.BookID == book.BookID);
            return b;
        }

        public async Task<Book> GetAsync(Guid bookID)
        {
            Book book = await _dbContext.Books.SingleOrDefaultAsync(b => b.BookID == bookID);
            return book;
        }

        public async Task<Book> Update(Book book)
        {
            Book updateBook = await GetAsync(book.BookID);
            _dbContext.Entry(updateBook).CurrentValues.SetValues(book);
            await _dbContext.SaveChangesAsync();
            return updateBook;
        }

        public async Task Delete(Guid bookID)
        {
            Book deleteBook = await GetAsync(bookID);
            _dbContext.Books.Remove(deleteBook);
            await _dbContext.SaveChangesAsync();
        }
    }
}
