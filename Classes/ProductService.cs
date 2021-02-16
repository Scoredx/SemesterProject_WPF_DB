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
        /// Returns product record selected by ID 
        /// </summary>
        /// <param name="productID">Product ID</param>
        /// <returns>Returns product record selected by ID </returns>
        public product SelectProductById(int productID)
        {
            var x = db.product.FirstOrDefault(y => y.product_id == productID);
            return x;
        }
        /// <summary>
        /// Remove product from Database
        /// </summary>
        /// <param name="p">product</param>
        public void DeleteProduct(product prdct)
        {
            if (prdct != null) db.product.Remove(prdct);
            db.SaveChanges();
        }
        /// <summary>
        /// Updates product in Database
        /// </summary>
        /// <param name="prdct">Product Object</param>
        /// <param name="priceDecimal">Product Price</param>
        /// <param name="costDecimal">Product Cost</param>
        /// <param name="product_category_name_">Category Name</param>
        /// <param name="product_manufacturer_name_">Manfacturer Namee</param>
        /// <param name="product_name_">Product Name</param>
        public void UpdateProduct(product prdct, decimal priceDecimal, decimal costDecimal,string product_category_name_, string product_manufacturer_name_, string product_name_)
        {
            if (prdct != null)
            {
                prdct.product_category_name = product_category_name_;
                prdct.product_manufacturer_name = product_manufacturer_name_;
                prdct.product_name = product_name_;
                prdct.product_price = priceDecimal;
                prdct.product_cost = costDecimal;
            }
            db.SaveChanges();
        }

    }
}


