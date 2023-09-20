using Microsoft.AspNetCore.Mvc;
using User.BLL.Contract.Contract;

namespace User.Host.Controllers;

[ApiController]
public class UsersController : Controller
{
	private readonly IUserBLL _userBLL;
	public UsersController(IUserBLL userBLL)
	{
		_userBLL = userBLL;
	}

	[Route("api/Users/{id}")]
	[HttpGet]
	public IActionResult Get(int id)
	{
		var user = _userBLL.SelectUser(id);
		return Ok(user);
	}

	[Route("api/Users/{id}")]
	[HttpPost]
	public IActionResult Post(int id)
	{
		var user = _userBLL.SelectUser(id);
		return Ok(user);
	}
}
