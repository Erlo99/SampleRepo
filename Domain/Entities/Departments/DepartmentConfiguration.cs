using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Departments
{
    [Table("DepartmentConfigurations")]
    public class DepartmentConfiguration : BaseClassEntity
    {
        [Required]
        public bool CustomRoleAccess { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }
    }
}
