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

        public OrderViewModel(orderTable order)
        {
            order_id = order.order_id;
            product_id = order.product.product_id;
            product_name = order.product.product_name;
            customer_id = order.customer.customer_id;
            customer_name = order.customer.customer_name;
            customer_surname = order.customer.customer_surename;
            worker_id = order.worker.worker_id;
            delivery_type_id = order.order_delivery_type_id;
            delivery_type1 = order.delivery_type.delivery_type1;
        }
    }
}
