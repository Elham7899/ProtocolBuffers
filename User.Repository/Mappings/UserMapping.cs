using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace User.Repository.Mappings;

public class UserMapping : IEntityTypeConfiguration<Users>
{
	public void Configure(EntityTypeBuilder<Users> builder)
	{
		builder.ToTable("UserInfo");
	}
}
