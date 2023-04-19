using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Dto
{
    public class UserDto
    {
        [Required] public string FirstName { get;  set; }
        [Required] public string LastName { get;  set; }
        [Required] public Gender Gender { get; set; }
        [Required] public string Pesel { get; set; }
        [Required] public string Login { get; set; }
        [Required] public string PhoneNumber { get;  set; }
        [Required] public string EmailAddress { get;  set; }
        [Required] public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get;  set; }
    }
}
