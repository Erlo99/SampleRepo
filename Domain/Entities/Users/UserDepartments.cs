using Domain.Common;
using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users
{
    [Table("UsersDepartments")]
    public class UserDepartments : CreatedEntity
    {
        [Key]
        public Guid UserId { get; set; }

        [Key]
        public Guid DepartmentId { get; set; }
    }
}
