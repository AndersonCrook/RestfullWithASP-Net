using RestWithASPNet.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNet.Service.Implementattions
{
    public interface IBookService
    {
        BookVO Create(BookVO person);

        BookVO FindById(long  id);

        List<BookVO> FindAll();

        BookVO Update(BookVO person);

        void Delete(long id);
    }
}
