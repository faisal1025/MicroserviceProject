using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Domain;
using UserService.UserDataAccess;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : Controller
    {
        private ILogger<UserController> logger;
        private IRepository repository;
        public UserController(IRepository repository, ILogger<UserController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var res = repository.GetAllUsers();
            return Json(res);
        }

        [HttpPost("login")]
        public ActionResult Login(LoginDto login)
        {
            var res = repository.Login(login.Email, login.Password);
            return Json(res);
        }

        // POST: api/user/register
        [HttpPost("register")]
        public ActionResult Register(User user)
        {  
            var res = repository.Register(user);
            return Json(res);
        }

        // POST: api/user/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult Edit(int Id, User user)
        {
            var res =repository.Edit(Id, user);
            return Json(res);
        }

        // POST: api/user/delete/5
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int Id)
        {
            var res = repository.Delete(Id);
            return Json(res);
        }
    }
}
