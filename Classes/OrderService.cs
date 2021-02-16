using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProject_WPF_DB.Classes
{
    class OrderService
    {
        Database1Entities1 db = new Database1Entities1();
        /// <summary>
        /// Create new Order
        /// </summary>
        /// <param name="productObject">Order object</param>
        public void NewOrder(orderTable productObject)
        {
            db.orderTable.Add(productObject);
            db.SaveChanges();
        }
        /// <summary>
        /// Check quantity of records in product table
        /// </summary>
        /// <param name="field">product Index text box</param>
        /// <returns>Parsed product Index</returns>
        public int checkProductQan(string field)
        {
            IQueryable<product> count1 = db.product;
            var productsQuantity = count1.Count();

            int productIndexInt;
            bool productIntResult = int.TryParse(field, out productIndexInt);
            if (productIntResult)
            {
                if (productsQuantity >= productIndexInt)
                {
                    return productIndexInt;
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
        /// <summary>
        /// Check quantity of records in customer table
        /// </summary>
        /// <param name="field">customer Index text box</param>
        /// <returns>Parsed customer Index</returns>
        public int checkCustomerQan(string field)
        {
            IQueryable<customer> count1 = db.customer;
            var productsQuantity = count1.Count();

            int customerIndexInt;
            bool customertIntResult = int.TryParse(field, out customerIndexInt);
            if (customertIntResult)
            {
                if (productsQuantity >= customerIndexInt)
                {
                    return customerIndexInt;
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
        /// <summary>
        /// Check quantity of records in worker table
        /// </summary>
        /// <param name="field">worker Index text box</param>
        /// <returns>Parsed worker Index</returns>
        public int checkWorkerQan(string field)
        {
            IQueryable<worker> count1 = db.worker;
            var workerQuantity = count1.Count();

            int workerIndexResult;
            bool workerIntResult = int.TryParse(field, out workerIndexResult);
            if (workerIntResult)
            {
                if (workerQuantity >= workerIndexResult)
                {
                    return workerIndexResult;
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
        /// <summary>
        /// Check quantity of records in delivery_type table
        /// </summary>
        /// <param name="field">delivery_type index text box</param>
        /// <returns>Parsed delivery_type Index</returns>
        public int checkDeliveryTypeQan(string field)
        {
            IQueryable<delivery_type> count1 = db.delivery_type;
            var productsQuantity = count1.Count();

            int deliveryIndexInt;
            bool deliveryIntResult = int.TryParse(field, out deliveryIndexInt);
            if (deliveryIntResult)
            {
                if (productsQuantity >= deliveryIndexInt)
                {
                    return deliveryIndexInt;
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
        /// <summary>
        /// Get product data filtered by chosen ID 
        /// </summary>
        /// <param name="ID">index</param>
        /// <returns></returns>
        public List<orderTable> GetProductById(int ID)
        {
            var list = db.orderTable
            .Where(st => st.product.product_id == ID)
            .Include(x => x.product)
            .Include(x => x.customer)
            .Include(x => x.worker)
            .Include(x => x.delivery_type)
            .ToList();
            return list;
        }
        /// <summary>
        /// Get customer data filtered by chosen ID 
        /// </summary>
        /// <param name="ID">index</param>
        /// <returns></returns>
        public List<orderTable> GetCustomertById(int ID)
        {
            var list = db.orderTable
                .Where(st => st.customer.customer_id == ID)
                .Include(x => x.product)
                .Include(x => x.customer)
                .Include(x => x.worker)
                .Include(x => x.delivery_type)
                .ToList();
            return list;
        }
        /// <summary>
        /// Get worker data filtered by chosen ID 
        /// </summary>
        /// <param name="ID">index</param>
        /// <returns></returns>
        public List<orderTable> GetWorkerById(int ID)
        {
            var list = db.orderTable
                .Where(st => st.worker.worker_id == ID)
                .Include(x => x.product)
                .Include(x => x.customer)
                .Include(x => x.worker)
                .Include(x => x.delivery_type)
                .ToList();
            return list;
        }
        /// <summary>
        /// Get delivery table data filtered by chosen ID 
        /// </summary>
        /// <param name="ID">index</param>
        /// <returns></returns>
        public List<orderTable> GetDeliveryById(int ID)
        {
            var list = db.orderTable
                .Where(st => st.delivery_type.delivery_type_id == ID)
                .Include(x => x.product)
                .Include(x => x.customer)
                .Include(x => x.worker)
                .Include(x => x.delivery_type)
                .ToList();
            return list;
        }
        public List<orderTable> GetList()
        {
            var list = db.orderTable
                .Include(x => x.product)
                .Include(x => x.customer)
                .Include(x => x.worker)
                .Include(x => x.delivery_type)
                .ToList();
            return list;
        }
        /// <summary>
        /// Deletes entity from orderTable
        /// </summary>
        /// <param name="order">orderTable Object</param>
        public void DeleteOrder(orderTable order)
        {
            if (order != null) db.orderTable.Remove(order);
            db.SaveChanges();
        }
        /// <summary>
        /// Select order by order Id
        /// </summary>
        /// <param name="orderID">Order Index</param>
        /// <returns></returns>
        public orderTable SelectOrderById(int orderID) => db.orderTable.FirstOrDefault(y => y.order_id == orderID);
    }
}
