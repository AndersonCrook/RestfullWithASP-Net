using RestWithASPNet.Data.VO;

namespace RestWithASPNet.Repository.Generic
{
    public interface ILoginService
    {
        object FindByLogin(UserVO user);
    }
}
