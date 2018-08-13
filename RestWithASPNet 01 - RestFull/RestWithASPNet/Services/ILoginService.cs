using RestWithASPNet.Model;

namespace RestWithASPNet.Repository.Generic
{
    public interface ILoginService
    {
        object FindByLogin(UserModel user);
    }
}
