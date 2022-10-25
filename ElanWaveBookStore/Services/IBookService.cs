using ElanWaveBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElanWaveBookStore.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Task<Book> CreateAsync(Book book);
        Task<Book> GetAsync(Guid bookID);
        Task<Book> Update(Book book);
        Task Delete(Guid bookID);
    }
}
