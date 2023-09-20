using Models;
using User.BLL.Contract.Contract;
using User.DAL.Contract.Contract;
using User.Repository.Contract.Contract;

namespace User.BLL.Services;

public class UserBLL : IUserBLL
{
	private readonly IUserRepository _userRepository;
	private readonly IUnitOfWorks _unitOfWorks;

	public UserBLL(IUserRepository userRepository, IUnitOfWorks unitOfWorks)
	{
		_userRepository = userRepository;
		_unitOfWorks = unitOfWorks;
	}

	public async Task<Users?> SelectUser(int id)
	{
		return await _userRepository.Select(id);
	}

	public async Task<int> Insert(Users users)
	{
		var id = await _userRepository.Insert(users);

		_unitOfWorks.Commit();

		return id;
	}

	public void Delete(int id)
	{
		_userRepository.Delete(id);

		_unitOfWorks.Commit();
	}

	public  void UpdateUser(int id, Users users)
	{
		var user =  _userRepository.Find(id);

		if (user != null)
		{
			user.FirstName = users.FirstName;
			user.LastName = users.LastName;
			user.Birthday = users.Birthday;
			user.NationalCode = users.NationalCode;
		}

		_userRepository.Update(user);

		_unitOfWorks.Commit();
	}
}