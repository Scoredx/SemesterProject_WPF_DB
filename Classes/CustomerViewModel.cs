using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProject_WPF_DB
{
    class CustomerViewModel
    {
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string customer_surname { get; set; }
        public int address_id { get; set; }
        public string address_city { get; set; }
        public int customer_phone { get; set; }
        public string customer_email { get; set; }
        public string customer_nip { get; set; }

        /// <summary>
        /// Signs values to customer object
        /// </summary>
        /// <param name="customer">Customer</param>
        public CustomerViewModel(customer customer)
        {
            customer_id = customer.customer_id;
            customer_name = customer.customer_name;
            customer_surname = customer.customer_surename;
            address_id = customer.addressTable.address_id;
            address_city = customer.addressTable.address_city;
            customer_phone = customer.customer_phone;
            customer_email = customer.customer_email;
            customer_nip = customer.customer_nip;
        }
    }
}
