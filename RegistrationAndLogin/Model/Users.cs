using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace RegistrationAndLogin.Model;

public class Users
{
    [Key]
    [Column("User Name")]
    public string? UserName { get; set; }

    [Column("Age")]
    public int? Age { get; set; }

    [Column("Role")]
    public string? Role { get; set; }

    [Required]
    [Column("Password")]
    public byte[]? Password { get; set; }

    [Column("Hash Key")]
    public byte[]? HashKey { get; set; }
}
