using Models;

namespace User.BLL.Contract.Contract;

public interface IUserBLL
{
	Task<Users?> SelectUser(int id);

	void UpdateUser(int id,Users users);

	Task<int> Insert(Users users);

	void Delete(int id);
}