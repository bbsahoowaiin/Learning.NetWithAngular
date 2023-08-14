using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class UsersController : ControllerBase
{
    private readonly DataContext _dataContext;

    public UsersController(DataContext dataContext){
        //TODO: Add DB connection here
        _dataContext = dataContext;
    }

    [HttpGet]  // get/users
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUses(){
        var users = await _dataContext.Users.ToListAsync();
        
        return users;
    }

    [HttpGet("{id}")] //get/users/2
    public async Task<ActionResult<AppUser>> GetUserById(int id){
        return await _dataContext.Users.FindAsync(id);
    }

}
