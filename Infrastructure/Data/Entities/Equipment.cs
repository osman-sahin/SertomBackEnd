using Infrastructure.Data.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Text;
using System.Text.Json.Serialization;

namespace Infrastructure.Data.Entities
{
    public class Equipment : ResponseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ProcurementDate { get; set; }
        [Required]
        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, (double)Decimal.MaxValue)]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(4,1)")]
        [Range(0.0, 100.0)]
        public decimal UtilizationRatio { get; set; } = 0.0m;
        [ForeignKey("Clinic")]
        public int ClinicId { get; set; }
        [JsonIgnore]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public DateTime? ModificationDate { get; set; }
    }
}
