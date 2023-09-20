using Models;

namespace User.DAL.Contract.Contract;

public interface IUserRepository
{
	Task<Users?> Select(int id);

	Task<int> Insert(Users user);

	void Delete(int id);

	Users Find(int id);

	void Update(Users user);
}
