//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SemesterProject_WPF_DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class orderTable
    {
        public int order_id { get; set; }
        public int order_product_id { get; set; }
        public int order_delivery_type_id { get; set; }
        public int order_customer_id { get; set; }
        public int order_worker_id { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual delivery_type delivery_type { get; set; }
        public virtual product product { get; set; }
        public virtual worker worker { get; set; }
    }
}
