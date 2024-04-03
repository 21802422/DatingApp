using API.Data;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace API.Controllers;

[Authorize]
[ApiController]
[Route("API/[controller]")] //api for users
public class UsersController : ControllerBase
{
  private readonly IUserRepository _userRepository;
  private readonly IMapper _mapper;
  public UsersController(IUserRepository userRepository, IMapper mapper)
  {
    _mapper = mapper;
   _userRepository = userRepository;
  }

  
  
  [HttpGet] //retrieve a list if the all appUser object from DB and return Http Response
  public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
  {
    var users = await _userRepository.GetMembersAsync();

     return Ok(users);
  }

  [HttpGet("{username}")] //retrieving a single appUsers object 4 DB on it PK and return it as HTTP
  public async Task<ActionResult<MemberDto>> GetUser(string username)
  {
    return await _userRepository.GetMemberAsync(username);
  }


}
