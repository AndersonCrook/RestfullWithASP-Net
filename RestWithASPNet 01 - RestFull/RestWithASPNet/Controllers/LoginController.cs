using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNet.Model;
using RestWithASPNet.Repository.Generic;
using Tapioca.HATEOAS;

namespace RestWithASPNet.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LoginController : Controller
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        // POST api/persons
        [AllowAnonymous]
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public object Post([FromBody]UserModel user)
        {
            if (user == null) return NotFound();
            return _loginService.FindByLogin(user);
        }
    }
}