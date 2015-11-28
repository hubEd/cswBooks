using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookEd.Transfer.DTOs;
using Book.Data;

namespace BookEd.Transfer
{
    public class ModelMapper
    {
        public static void BuildMaps()
        {
            Mapper.CreateMap<Book.Data.Author, AuthorModel>().ReverseMap();
            Mapper.CreateMap<Book.Data.Category, CategoryModel>().ReverseMap();
            Mapper.CreateMap<Book.Data.Book, BookModel>().ReverseMap();

            Mapper.CreateMap<Book.Data.Book, Book.Data.Book>()
                .ForMember(x => x.BookId, s => s.Ignore());
        }
    }
}
