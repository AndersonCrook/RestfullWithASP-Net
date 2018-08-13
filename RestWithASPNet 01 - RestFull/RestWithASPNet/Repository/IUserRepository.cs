using RestWithASPNet.Model;

namespace RestWithASPNet.Repository.Generic
{
    public interface IUserRepository
    {
        UserModel FindByLogin(string login);
    }
}
