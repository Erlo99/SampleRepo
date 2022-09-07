using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    public class PermissionEntity : BaseClassEntity
    {
        [Required]
        public bool Create { get; set; }

        [Required]
        public bool Read { get; set; }

        [Required]
        public bool Update { get; set; }

        [Required]
        public bool Delete { get; set; }
    }
}
