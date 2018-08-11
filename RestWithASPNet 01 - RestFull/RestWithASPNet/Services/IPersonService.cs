using RestWithASPNet.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNet.Service.Implementattions
{
    public interface IPersonService
    {
        PersonVO Create(PersonVO person);

        PersonVO FindById(long  id);

        List<PersonVO> FindAll();

        PersonVO Update(PersonVO person);

        void Delete(long id);
    }
}
