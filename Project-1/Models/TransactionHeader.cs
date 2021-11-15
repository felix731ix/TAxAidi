//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TransactionHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TransactionHeader()
        {
            this.TransactionDetails = new HashSet<TransactionDetail>();
        }
    
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int ShowId { get; set; }
        public System.DateTime ShowTime { get; set; }
        public System.DateTime CreatedAt { get; set; }
    
        public virtual Show Show { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
        public virtual User User { get; set; }
    }
}