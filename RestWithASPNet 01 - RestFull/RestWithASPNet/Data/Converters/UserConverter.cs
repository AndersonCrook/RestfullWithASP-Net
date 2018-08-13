using RestWithASPNet.Data.Converter;
using RestWithASPNet.Data.VO;
using RestWithASPNet.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNet.Data.Converters
{
    public class UserConverter : IParser<UserVO, UserModel>, IParser<UserModel, UserVO>
    {
        public UserModel Parse(UserVO origin)
        {
            if (origin == null) return null;
            return new UserModel
            {                
                Login = origin.Login,
                AccessKey = origin.AccessKey
                
            };
        }

        public UserVO Parse(UserModel origin)
        {
            if (origin == null) return null;
            return new UserVO
            {                
                Login = origin.Login,
                AccessKey = origin.AccessKey

            };
        }

        public List<UserModel> ParseList(List<UserVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<UserVO> ParseList(List<UserModel> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}