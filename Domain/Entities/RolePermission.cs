using CoNettion.Core.Enums;
using Domain.Entities.Common;
using Domain.Entities.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Roles
{
    [Table("RolePermissions")]
    public class RolePermission : PermissionEntity
    {
        [Key]
        public Guid DepartmentId { get; set; }

        [Key]
        public int RoleId { get; set; }

        [Key]
        public int PermissionId { get; set; }
    }
}
