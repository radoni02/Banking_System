﻿using Banking.Core.Domain.Consts;
using Banking.Core.Domain.Entities;
using Banking.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Factories.UserFactory
{
    public interface IUserFactory
    {
        User Create( string FirstName, string LastName, Gender gender, string pesel, string phoneNumber, string emailAddress,DateTime birthday);
    }
}
