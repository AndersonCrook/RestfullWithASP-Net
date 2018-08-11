using RestWithASPNet.Data.Converter;
using RestWithASPNet.Data.VO;
using RestWithASPNet.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNet.Data.Converters
{
    public class PersonConverter : IParser<PersonVO, PersonModel>, IParser<PersonModel, PersonVO>
    {
        public PersonModel Parse(PersonVO origin)
        {
            if (origin == null) return null;
            return new PersonModel
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public PersonVO Parse(PersonModel origin)
        {
            if (origin == null) return null;
            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<PersonModel> ParseList(List<PersonVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> ParseList(List<PersonModel> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}