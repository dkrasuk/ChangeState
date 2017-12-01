using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeState.Models
{
    public class Car : Collateral
    {
        public BodyType BodyType { get; set; }
        public Brand Brand { get; set; }
        public Model Model { get; set; }
        public string StateNumber { get; set; }
        public string VinCode { get; set; }
        public int? YearIssue { get; set; }
        public Color Color { get; set; }
        public string Engine { get; set; }
        public GearBox GearBox { get; set; }
        public Region Region { get; set; }
    }
    public class BodyType
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }

    public class Brand
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
    public class Color
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
    public class GearBox
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
    public class Region
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
    public class Model
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Brand")]
        public string Brand { get; set; }
    }

}
