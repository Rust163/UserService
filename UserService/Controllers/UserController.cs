using Microsoft.AspNetCore.Mvc;
using UserService.Models.Users;

namespace UserService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller<User> {
        public UserController(IRepository<User> repository) : base(repository) { 
        }
    }
}
