using RestWithASPNet.Data.Converter;
using RestWithASPNet.Data.VO;
using RestWithASPNet.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNet.Data.Converters
{
    public class BookConverter : IParser<BookVO, BookModel>, IParser<BookModel, BookVO>
    {
        public BookModel Parse(BookVO origin)
        {
            if (origin == null) return new BookModel();
            return new BookModel
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public BookVO Parse(BookModel origin)
        {
            if (origin == null) return new BookVO();
            return new BookVO
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<BookModel> ParseList(List<BookVO> origin)
        {
            if (origin == null) return new List<BookModel>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> ParseList(List<BookModel> origin)
        {
            if (origin == null) return new List<BookVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}