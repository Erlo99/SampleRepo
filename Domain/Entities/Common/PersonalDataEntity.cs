using CoNettion.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    public class PersonalDataEntity : BaseClassEntity
    {
        [MaxLength(50)]
        public string CompanyName { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        [Required]
        [MaxLength(50)]
        public string HouseNumber { get; set; }
        [MaxLength(50)]
        public string LocalNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public CountryEnum Country { get; set; }
        [Required]
        [MaxLength(50)]
        public string ZipCode { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string TaxNumber { get; set; }
    }
}
