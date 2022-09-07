using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoNettion.Core.Enums
{
    public enum RoleEnum
    {
        SuperAdmin = 1,
        Admin = 2,
        Manager = 3,
        WarehousePerson = 4,
        Accountant = 5,
        CustomRole1 = 100,
        CustomRole2 = 101,
        CustomRole3 = 102
    }
}
