using Microsoft.EntityFrameworkCore;
using Models;
using User.DAL.Contract.Contract;
using User.Repository.EFDbContext;

namespace User.Repository.Repositories;

public class UserRepository : IUserRepository
{
	private readonly DbContexts _dbContexts;

	public UserRepository(DbContexts dbContext)
	{
		_dbContexts = dbContext;
	}

	public async Task<Users?> Select(int id)
	{
		var a = await _dbContexts.Users.Where(u => u.Id == id).SingleOrDefaultAsync();

		return a;
	}

	public async Task<int> Insert(Users user)
	{
		await _dbContexts.Users.AddAsync(user);

		return user.Id;
	}

	public void Delete(int id)
	{
		var user = _dbContexts.Users.Where(u => u.Id == id).SingleOrDefault();

		_dbContexts.Users.Remove(user);
	}

	public  Users Find(int id)
	{
		var user = _dbContexts.Users.Find(id);

		return user;
	}

	public void Update(Users user)
	{
		_dbContexts.Users.Update(user);
	}
}