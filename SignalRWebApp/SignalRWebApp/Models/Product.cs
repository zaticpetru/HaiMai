using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SignalRWebApp.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Product : EntityBase
    {
        [DataMember]
        [Display(Name = "ID")]
        public Int32 ProductID { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Unit Price")]
        public Decimal UnitPrice { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Quantity")]
        public Decimal Quantity { get; set; }
    }
}