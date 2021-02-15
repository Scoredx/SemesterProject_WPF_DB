using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProject_WPF_DB.Classes
{
    public class ProductService
    {
        Database1Entities1 db = new Database1Entities1();

        /// <summary>
        /// List of products in Database
        /// </summary>
        /// <returns>List of products in Database</returns>
        public List<product> GetList()
        {
            //this.productDataGrid.ItemsSource = 
            return db.product.ToList();
        }

        /// <summary>
        /// Create new product entity in database
        /// </summary>
        /// <param name="priceDecimal">Product Price</param>
        /// <param name="costDecimal">Product Cost </param>
        /// <param name="product_Name">Product Name</param>
        /// <param name="product_category_name">Product Category</param>
        /// <param name="product_manufacturer_name">Product Manufacturer</param>
        public void AddProduct(decimal priceDecimal, decimal costDecimal,string product_Name,string product_category_name, string product_manufacturer_name)
        {
            product productObject = new product()
            {
                product_name = product_Name,
                product_category_name = product_category_name,
                product_manufacturer_name = product_manufacturer_name,
                product_price = priceDecimal,
                product_cost = costDecimal
            };
            db.product.Add(productObject);
            db.SaveChanges();
        }
        /// <summary>
        /// Removes selected product from Database
        /// </summary>
        /// 
        public product SelectProductById(int productID)
        {
            var x = db.product.FirstOrDefault(y => y.product_id == productID);
            return x;
        }

        public void DeleteProduct(product p)
        {
            if (p != null) db.product.Remove(p);
            db.SaveChanges();
        }

    }
}


