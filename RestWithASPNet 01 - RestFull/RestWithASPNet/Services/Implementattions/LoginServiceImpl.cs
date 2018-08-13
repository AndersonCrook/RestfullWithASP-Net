using RestWithASPNet.Data.VO;
using RestWithASPNet.Security.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace RestWithASPNet.Repository.Generic
{
    public class LoginServiceImpl :ILoginService
    {
        private IUserRepository _repository;

        private SigningConfigurations _signingConfigurations;
        private TokenConfiguration _tokenConfigurations;

        public LoginServiceImpl(IUserRepository repository, SigningConfigurations signingConfigurations, TokenConfiguration tokenConfigurations)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
        }

        public object FindByLogin(UserVO user)
        {
            bool credentialIsValid = false;
            if (user != null && !string.IsNullOrWhiteSpace(user.Login))
            {
                var baseUser = _repository.FindByLogin(user.Login);
                credentialIsValid = (baseUser != null && user.Login == baseUser.Login && user.AccessKey == baseUser.AccessKey);
            }
            if (credentialIsValid)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Login,"login"),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("n")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Login),
                    }                    
                    );
                DateTime createDate = DateTime.Now;

                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);

                return SuccessObject(createDate, expirationDate, token);
            }
            else
            {
                return ExceptionObject();
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
                          
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object ExceptionObject()
        {
            return new
            {
                autenticated = false,
                
                mesage = "Failed to autheticate"
            };
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, String token)
        {
            return new
            {
                autenticated = true,
                created = createDate.ToString("yyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyy-MM-dd HH:mm:ss"),
                accessToken = token,
                mesage = "Sucesso Meu Príncipe / Minha Princesa"
            };
        }
    }
}