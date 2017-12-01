using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeState.Models
{
    public class Mortgage : Collateral
    {
        public Region Region { get; set; }
        public District District { get; set; }
        public Settlement Settlement { get; set; }
        public SettlementType SettlementType { get; set; }
        public string Street { get; set; }
        public StreetType StreetType { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public int? NumberOfRooms { get; set; }
        public string TotalArea { get; set; }
        public string LandArea { get; set; }
        public Appointment Appointment { get; set; }
        public string Pledgers { get; set; }
    }

    public class District
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
    public class Settlement
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
    public class SettlementType
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
    public class StreetType
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
    public class Appointment
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }

}
