using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Dto
{
    public class BankAccountDto
    {
        [Required] public AccountType Type { get;  set; }
        [Required] public string Card { get;  set; }
        [Required] public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get;  set; }
        [Required] public string Pin { get;  set; }
        [Required] public string AccountNumber { get;  set; }
    }
}
