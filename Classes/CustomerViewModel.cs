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

    }
}
