using Microsoft.AspNetCore.Mvc;
using UserService.Models.Role;

namespace UserService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller<Role> {
        public RoleController(IRepository<Role> repository) : base(repository) {
        }
    }
}
