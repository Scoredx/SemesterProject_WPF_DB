using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemesterProject_WPF_DB.Classes
{
    class CustomerService
    {
        private Database1Entities1 db = new Database1Entities1();
        /// <summary>
        /// List of customers in Database
        /// </summary>
        /// <returns>List of customers in Database</returns>
        public List<customer> GetList()
        {
           var customer_ =  db.customer
                .Include("addressTable")
                .ToList();
           return customer_;
        }
        /// <summary>
        /// Create new customer entity in database
        /// </summary>
        /// <param name="cstmr">Customer</param>
        public void NewCustomer(customer cstmr)
        {
            db.customer.Add(cstmr);
            db.SaveChanges();
        }
        /// <summary>
        /// Delete customer entity from database
        /// </summary>
        /// <param name="customer">Customer</param>
        public void DeleteCustomer(customer customer)
        {
            if (customer != null)
            {
                db.customer.Remove(customer);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Customer is null");
            }
        }
        /// <summary>
        /// Update customer entity in database 
        /// </summary>
        /// <param name="customerObject">Customer Object</param>
        /// <param name="customer_name">Customer Name</param>
        /// <param name="customer_surname">Customer Surname</param>
        /// <param name="customer_address_id">Address Id</param>
        /// <param name="customer_phone">Customer Phone</param>
        /// <param name="customer_email">Customer Email</param>
        /// <param name="customer_nip">Customer Nip</param>
        public void UpdateCustomer(customer customerObject,string customer_name,string customer_surname, int customer_address_id,int customer_phone, string customer_email,string customer_nip)
        {
            if (customerObject != null)
            { 
                customerObject.customer_name = customer_name;
                customerObject.customer_surename = customer_surname;
                customerObject.customer_address_id = customer_address_id;
                customerObject.customer_phone = customer_phone;
                customerObject.customer_email = customer_email;
                customerObject.customer_nip = customer_nip;
            }
            db.SaveChanges();
        }
        /// <summary>
        /// Get customer entity by Id
        /// </summary>
        /// <param name="customerID">Customer Id</param>
        /// <returns>Get customer entity by Id</returns>
        public customer SelectCustomerById(int customerID)
        {
            var customer=  db.customer.FirstOrDefault(y => y.customer_id == customerID);
            return customer;
        }
        /// <summary>
        /// Get amount of address entities in addressTable
        /// </summary>
        /// <param name="field">Address Index TextBox</param>
        /// <returns>Address Index</returns>
        public int checkAddresstQan(string field)
        {
            IQueryable<addressTable> count1 = db.addressTable;
            var addressQuantity = count1.Count();
            int addressIndexInt;
            bool addressIntResult = int.TryParse(field, out addressIndexInt);
            if (addressIntResult)
            {
                if (addressQuantity >= addressIndexInt)
                {
                    return addressIndexInt;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
