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
        public int customer_phone { get; set; }
        public string customer_email { get; set; }
        public string customer_nip { get; set; }

        public CustomerViewModel(customer customer)
        {
            customer_id = customer.customer_id;
            customer_name = customer.customer_name;
            customer_surname = customer.customer_surename;
            address_id = customer.customer_address_id;
            customer_phone = customer.customer_phone;
            customer_email = customer.customer_email;
            customer_nip = customer.customer_nip;
        }
    }
}
