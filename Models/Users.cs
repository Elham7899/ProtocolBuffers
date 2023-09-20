using System.ComponentModel.DataAnnotations;

namespace Models;

public class Users
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

	[Required]
	public string LastName { get; set; }

	[Required]
	public string Birthday { get; set; }

	[Required]
	[MinLength(11)]
	[MaxLength(11)]
	public int NationalCode { get; set; }
}