using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TexTuto.API.Data;
using TexTuto.API.DTO;
using TexTuto.API.Models;

namespace TexTuto.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo){
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto){
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(userForRegisterDto.Username)){
                return BadRequest("Username already exist");
            }

            var userToCreate = new User{
                username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate,userForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}