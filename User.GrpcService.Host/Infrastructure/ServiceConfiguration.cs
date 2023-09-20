using Microsoft.EntityFrameworkCore;
using User.BLL.Contract.Contract;
using User.BLL.Services;
using User.DAL.Contract.Contract;
using User.Repository.Contract.Contract;
using User.Repository.EFDbContext;
using User.Repository.Repositories;
using User.Repository.UnitOFWorks;

namespace User.Host.Infrastructure;

public static class ServiceConfiguration
{
	public static void RegistrationService(this WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext<DbContexts>(option =>
		option.UseSqlServer("Password=12345;Persist Security Info=True;User ID=sa;Initial Catalog=Users;Data Source=.;TrustServerCertificate=Yes"));

		builder.Services.AddScoped<IUserBLL, UserBLL>();
		builder.Services.AddScoped<IUserRepository, UserRepository>();
		builder.Services.AddScoped<IUnitOfWorks, UnitOfWork>();
	}
}