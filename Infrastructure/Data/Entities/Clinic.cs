using Infrastructure.Data.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Infrastructure.Data.Entities
{
    public class Clinic : ResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public DateTime? ModificationDate { get; set; }
        [JsonIgnore]
        public ICollection<Equipment> Equipments { get; set; }
    }
}
