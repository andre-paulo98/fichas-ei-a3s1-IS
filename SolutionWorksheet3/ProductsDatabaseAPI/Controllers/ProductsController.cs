using ProductsDatabaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;

namespace ProductsDatabaseAPI.Controllers {
    public class ProductsController : ApiController {

        string connectionString = Properties.Settings.Default.ConnApp;

        // GET: api/Products
        public IEnumerable<Product> Get() {
            List<Product> products = new List<Product>();

            SqlConnection connection = null;
            try {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Prods", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    Product prod = new Product {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Category = (string)reader["Category"],
                        Price = (reader["Price"] == DBNull.Value) ? 0 : (decimal)reader["Price"]
                    };
                    products.Add(prod);
                }


            } catch (Exception) {

            } finally {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return products;
        }

        // GET: api/Products/5
        public string Get(int id) {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody] string value) {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE: api/Products/5
        public void Delete(int id) {
        }
    }
}
