using Domain.Common;
using Domain.Entities.Common;
using Domain.Entities.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users
{
    [Table("Users")]
    public class User : BaseClassEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]//unique
        public string UserName { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public Guid ParentDepartmentId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string HashedPassword { get; set; }
    }
}
