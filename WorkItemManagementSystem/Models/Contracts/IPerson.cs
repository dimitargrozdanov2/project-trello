﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WorkItemManagementSystem.Models.Contracts
{
    public interface IPerson
    {
        string UserName { get; }
        string FirstName { get; }
        string LastName { get; }
    }
}