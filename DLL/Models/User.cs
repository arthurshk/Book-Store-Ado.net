using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public class User
    {
    public int Id { get; set; }
    [Required]
    [MaxLength(40)]
    public string Login { get; set; }
    [Required]
    [MaxLength(40)]
    public string Password { get; set; }
    }
}
