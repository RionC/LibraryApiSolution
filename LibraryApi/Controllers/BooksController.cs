using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryApi.Domain;
using LibraryApi.Models.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class BooksController : ControllerBase
    {
        private LibraryDataContext _context;
        private IMapper _mapper;
        private MapperConfiguration _mapperConfig;

        public BooksController(LibraryDataContext context, IMapper mapper, MapperConfiguration mapperConfig)
        {
            _context = context;
            _mapper = mapper;
            _mapperConfig = mapperConfig;
        }

        [HttpGet("/books")]
        public async Task<ActionResult> GetAllBooks()
        {
            var response = new GetBooksResponse();

            var books = await _context.Books
                .Where(b => b.IsInInventory == true)
                .ProjectTo<GetBooksResponseItem>(_mapperConfig)
                .ToListAsync();

            response.Data = books;

            return Ok(response);
        }

        [HttpGet("/books/{bookId:int}")]
        public async Task<ActionResult> GetBookById([FromRoute] int bookId)
        {
            var book = await _context.Books
                .Where(b => b.IsInInventory && b.Id == bookId)
                .ProjectTo<GetBookDetailsResponse>(_mapperConfig)
                .SingleOrDefaultAsync();

            if(book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }
        }
    }
}
