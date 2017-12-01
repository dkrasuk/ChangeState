using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeState.Models
{
    public class Collateral
    {
        public string ActualDescription { get; set; }
        [JsonProperty(PropertyName = "BiddingDate")]
        public DateTime? BiddingDate { get; set; }
        [JsonProperty(PropertyName = "Comment")]
        public string Comment { get; set; }
        [JsonProperty(PropertyName = "Deleted")]
        public bool? Deleted { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "EntryDate")]
        public DateTime? EntryDate { get; set; }
        [JsonProperty(PropertyName = "Evaluation")]
        public Evaluation Evaluation { get; set; }
        [JsonProperty(PropertyName = "EvaluationDate")]
        public DateTime? EvaluationDate { get; set; }
        [JsonProperty(PropertyName = "EvaluationHistory")]
        public IList<Evaluation> EvaluationHistory { get; set; }
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "InventoryDate")]
        public DateTime? InventoryDate { get; set; }
        [JsonProperty(PropertyName = "IsActive")]
        public bool? IsActive { get; set; }
        [JsonProperty(PropertyName = "IsAdditionalProperty")]
        public bool? IsAdditionalProperty { get; set; }
        [JsonProperty(PropertyName = "IsVerified")]
        public bool? IsVerified { get; set; }
        [JsonProperty(PropertyName = "ModifyDate")]
        public DateTime? ModifyDate { get; set; }
        [JsonProperty(PropertyName = "ModifyUser")]
        public string ModifyUser { get; set; }
        [JsonProperty(PropertyName = "Moratorium")]
        public Moratorium Moratorium { get; set; }
        [JsonProperty(PropertyName = "SaleDate")]
        public DateTime? SaleDate { get; set; }
        [JsonProperty(PropertyName = "SaleType")]
        public SaleType SaleType { get; set; }
        [JsonProperty(PropertyName = "SetamDate")]
        public DateTime? SetamDate { get; set; }
        [JsonProperty(PropertyName = "State")]
        public State State { get; set; }
        [JsonProperty(PropertyName = "Status")]
        public Status Status { get; set; }
        [JsonProperty(PropertyName = "Subtype")]
        public Subtype Subtype { get; set; }
        [JsonProperty(PropertyName = "Type")]
        public Type Type { get; set; }
        [JsonProperty(PropertyName = "User")]
        public string User { get; set; }
    }

    public class Evaluation
    {
        public DateTime? Date { get; set; }
        [JsonProperty(PropertyName = "DateEntry")]
        public DateTime? DateEntry { get; set; }
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Responsible")]
        public string Responsible { get; set; }
        [JsonProperty(PropertyName = "Source")]
        public Source Source { get; set; }
        [JsonProperty(PropertyName = "Type")]
        public EvalutionType Type { get; set; }
        [JsonProperty(PropertyName = "Value")]
        public Amount Value { get; set; }
    }

    public class Moratorium
    {       

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
    public class SaleType
    {
        
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
    public class State
    {    

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
    public class Subtype
    {

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
    public class Status
    {

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
    public class Type
    {

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
    public class Source
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
    public class EvalutionType
    {

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }    
    public class Amount
    {        

        [JsonProperty(PropertyName = "Currency")]
        public Currency Currency { get; set; }
        [JsonProperty(PropertyName = "Value")]
        public double? Value { get; set; }
    }
    public class Currency
    {       

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
}
