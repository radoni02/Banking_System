using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Dto
{
    public class BalanceDto
    {
       [Required] public decimal AccountBalance { get;  set; }

       [Required] public Currency Currency { get; set; }
    }
}
