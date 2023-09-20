using Grpc.Core;
using Models;
using User.BLL.Contract.Contract;

namespace User.GrpcService.Host.Services;

public class GreeterService : Greeter.GreeterBase
{
	private readonly ILogger<GreeterService> _logger;
	private readonly IUserBLL _userBLL;
	public GreeterService(ILogger<GreeterService> logger, IUserBLL userBLL)
	{
		_logger = logger;
		_userBLL = userBLL;
	}

	public override async Task<UserReply> GetUser(UserRequest request, ServerCallContext context)
	{
		var user = await _userBLL.SelectUser(request.Id);

		return new UserReply
		{
			FirstName = user.FirstName,
			LastName = user.LastName,
			NationalCode = user.NationalCode,
			Birthday = user.Birthday
		};
	}

	public override async Task<UserPostReply> PostUser(UserPostRequest request, ServerCallContext context)
	{
		var user = new Users() { Birthday = request.Birthday, FirstName = request.FirstName, LastName = request.LastName, NationalCode = request.NationalCode, Id = request.Id };

		var id = await _userBLL.Insert(user);

		return new UserPostReply
		{
			Id = id
		};
	}

	public override Task<UserDeleteReply> DeleteUser(UserDeleteRequest request, ServerCallContext context)
	{
		_userBLL.Delete(request.Id);

		return Task.FromResult(new UserDeleteReply
		{
			Message = "Deleted Successfully"
		});
	}

	public override Task<UserUpdateReply> UpdateUser(UserUpdateRequest request, ServerCallContext context)
	{
		var user = new Users() { Birthday = request.Birthday, FirstName = request.FirstName, LastName = request.LastName, NationalCode = request.NationalCode, Id = request.Id };

		_userBLL.UpdateUser(request.Id, user);

		return Task.FromResult(new UserUpdateReply
		{
			Message = "Updated Successfully"
		});
	}
}