
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoXamarimGS.Data;
using ProjetoXamarimGS.Data.Entities;
using System.Linq;

namespace ProjetoXamarimGS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : Controller
    {
        //private readonly IUsersRepository _usersRepository;
        public readonly DataContext _context;
        public UsersController(/*IUsersRepository usersRepository,*/ DataContext context)
        {
            //_usersRepository = usersRepository;
            _context = context;
        }
        



        [HttpGet]
        public IActionResult GetUsers()
        {
            //return Ok(_usersRepository.GetAllUsers());



            return Ok(_context.Set<User>().AsNoTracking());
        }






    }
}