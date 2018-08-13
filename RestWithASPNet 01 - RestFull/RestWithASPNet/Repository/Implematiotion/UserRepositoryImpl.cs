using RestWithASPNet.Model;
using RestWithASPNet.Model.Context;
using System.Linq;

namespace RestWithASPNet.Repository.Generic
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly MySQLContext _context;
        public UserRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public UserModel FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login.Equals(login));
        }
    }
}