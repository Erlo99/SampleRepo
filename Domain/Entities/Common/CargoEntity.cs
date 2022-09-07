using CoNettion.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    public class CargoEntity : BaseClassEntity
    {
        [Required]
        [MaxLength(50)]
        public string CargoName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Sku { get; set; }

        [MaxLength(50)]
        public string Ean { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(3)]
        public string UnitOfMeasurment { get; set; }

        [MaxLength(3)]
        public string UnitOfWeight { get; set; }

        [MaxLength(3)]
        public string CountryOfManufacture { get; set; }

        public decimal Weight { get; set; }

        public decimal UnitPrice { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
