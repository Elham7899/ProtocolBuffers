using User.Repository.Contract.Contract;
using User.Repository.EFDbContext;

namespace User.Repository.UnitOFWorks;

public class UnitOfWork: IUnitOfWorks
{
	private readonly DbContexts _dbContext;

	public UnitOfWork(DbContexts dbContexts)
	{
		_dbContext = dbContexts;
	}

	public  void Commit()
	{
		 _dbContext.SaveChanges();
	}
}