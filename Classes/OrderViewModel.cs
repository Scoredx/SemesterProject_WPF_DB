using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProject_WPF_DB
{
    class OrderViewModel
    {
        public int order_id { get; set; }
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string customer_surname { get; set; }
        public int worker_id { get; set; }
        public int delivery_type_id { get; set; }
        public string delivery_type1 { get; set; }
    }
}
