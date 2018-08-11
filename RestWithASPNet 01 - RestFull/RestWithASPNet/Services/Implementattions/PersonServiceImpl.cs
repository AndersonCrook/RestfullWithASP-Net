using System.Collections.Generic;
using RestWithASPNet.Data.Converters;
using RestWithASPNet.Data.VO;
using RestWithASPNet.Model;
using RestWithASPNet.Repository.Generic;

namespace RestWithASPNet.Service.Implementattions
{
    public class PersonServiceImpl : IPersonService
    {
        private IRepository<PersonModel> _repository;
        private readonly PersonConverter _converter;

        public PersonServiceImpl(IRepository<PersonModel> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        //Criar uma nova Pessoa
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        //buscar Pessoas pelo id
        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        //buscar todas as Pessoas
        public List<PersonVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        // Edita uma pessoa pelo id
        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
            
        }

        //Deletar um Pessoa pelo id
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}