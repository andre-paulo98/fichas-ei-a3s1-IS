using ProductsDatabaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

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

                reader.Close();



            } catch (Exception) {

            } finally {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return products;
        }

        // GET: api/Products/5
        public IHttpActionResult Get(int id) {

            Product prod = FindProduct(id);
            if(prod != null) {
                return Ok(prod);
            } else {
                return NotFound();
            }
            
        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody] Product value) {

            SqlConnection connection = null;
            try {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "INSERT INTO Prods (Name, Category, Price) VALUES (@Name, @Category, @Price) select scope_identity()";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", value.Name);
                command.Parameters.AddWithValue("@Category", value.Category);
                command.Parameters.AddWithValue("@Price", value.Price);

                var id = Convert.ToInt32(command.ExecuteScalar());



                Product prod = FindProduct(id);
                if(prod != null) {
                    return Ok(prod);
                } else {
                    return InternalServerError();
                }

            } catch (Exception e) {

                throw e;

            } finally {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, [FromBody] Product value) {

            SqlConnection connection = null;
            try {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "UPDATE Prods SET Name = @Name, Category = @Category, Price = @Price WHERE Id = @Id";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", value.Name);
                command.Parameters.AddWithValue("@Category", value.Category);
                command.Parameters.AddWithValue("@Price", value.Price);
                command.Parameters.AddWithValue("@Id", id);

                if(command.ExecuteNonQuery() > 0) {
                    return Ok(FindProduct(id));
                }

                return InternalServerError();

            } catch (Exception e) {

                throw e;

            } finally {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

        }

        // DELETE: api/Products/5
        public IHttpActionResult Delete(int id) {

            SqlConnection connection = null;
            try {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "DELETE FROM Prods WHERE Id = @idProd";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idProd", id);

                int i = command.ExecuteNonQuery();

                if (i > 0) {
                    return Ok();
                } else {
                    return InternalServerError();
                }


            } catch (Exception) {

            } finally {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return NotFound();

        }



        private Product FindProduct(int id) {

            SqlConnection connection = null;
            try {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT * FROM Prods WHERE ID = @idProd";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idProd", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {

                    Product prod = new Product {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Category = (string)reader["Category"],
                        Price = (reader["Price"] == DBNull.Value) ? 0 : (decimal)reader["Price"]
                    };

                    reader.Close();

                    return prod;

                } else {

                    reader.Close();

                    return null;

                }


            } catch (Exception) {

            } finally {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return null;
        }
    }
}
