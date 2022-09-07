using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class AuditableEntity : CreatedEntity
    {
        [Required]
        public DateTime LastModifiedAt { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastModifiedBy { get; set; }
    }
}
