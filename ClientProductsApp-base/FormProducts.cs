using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; //Stream
using System.Linq;
using System.Net; //HttpWebRequest
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using RestSharp;
using RestSharp.Authenticators;

//JavaScriptSerializer --> necessário criar referencia para System.Web.Extensions

namespace ClientProductsApp {
    public partial class FormProducts : Form {

        readonly string baseURI = @"http://localhost:60355/"; //needs to be updated!

        public FormProducts() {
            InitializeComponent();
        }

        private void buttonGetAll_Click(object sender, EventArgs e) {

            RestClient client = new RestClient(baseURI);
            var request = new RestRequest("api/products", Method.GET, DataFormat.Json);

            var response = client.Execute<List<Product>>(request).Data;

            richTextBoxShowProducts.Text = "";
            foreach (var item in response) {
                richTextBoxShowProducts.AppendText(item.ToString() + "\n");
            }

        }

        private void buttonGetProductById_Click(object sender, EventArgs e) {
            RestClient client = new RestClient(baseURI);
            var request = new RestRequest("api/products/{id}", Method.GET, DataFormat.Json);
            request.AddUrlSegment("id", textBox1.Text);

            var response = client.Execute<Product>(request).Data;

            if(response != null) {
                textBoxOutput.Text = response.ToString();

                textBoxID.Text = response.Id + "";
                textBoxName.Text = response.Name;
                textBoxCategory.Text = response.Category;
                textBoxPrice.Text = response.Price + "";
            } else {
                textBoxOutput.Text = "/not found/";

                textBoxID.Text = "";
                textBoxName.Text = "";
                textBoxCategory.Text = "";
                textBoxPrice.Text = "";
            }

            
        }

        private void buttonPost_Click(object sender, EventArgs e) {

            if(textBoxName.Text.Length > 0 && textBoxCategory.Text.Length > 0 && textBoxPrice.Text.Length > 0) {

                Product prod = new Product();
                prod.Name = textBoxName.Text;
                prod.Category = textBoxCategory.Text;
                prod.Price = Convert.ToDecimal(textBoxPrice.Text);


                RestClient client = new RestClient(baseURI);
                var request = new RestRequest("api/products/", Method.POST, DataFormat.Json);
                request.AddJsonBody(prod);

                var response = client.Execute<Product>(request).Data;

                if (response != null) {
                    textBoxID.Text = response.Id + "";
                    MessageBox.Show("Result: " + response);
                } else {
                    MessageBox.Show("Result: /error/");
                }

            }
            
        }

        private void buttonPut_Click(object sender, EventArgs e) {
            if (textBoxID.Text.Length > 0 && textBoxName.Text.Length > 0 && textBoxCategory.Text.Length > 0 && textBoxPrice.Text.Length > 0) {

                RestClient client = new RestClient(baseURI);
                var request = new RestRequest("api/products/{id}", Method.PUT, DataFormat.Json);
                request.AddUrlSegment("id", textBoxID.Text);

                Product prod = new Product();
                prod.Name = textBoxName.Text;
                prod.Category = textBoxCategory.Text;
                prod.Price = Convert.ToDecimal(textBoxPrice.Text);

                request.AddJsonBody(prod);


                var response = client.Execute<Product>(request).Data;

                if (response != null) {
                    textBoxID.Text = response.Id + "";
                    textBoxName.Text = response.Name;
                    textBoxCategory.Text = response.Category;
                    textBoxPrice.Text = response.Price + "";
                    MessageBox.Show("ok");
                } else {
                    MessageBox.Show("Result: /error/");
                }


            }
        }

        private void buttonDelete_Click(object sender, EventArgs e) {
            if (textBoxID.Text.Length > 0) {

                RestClient client = new RestClient(baseURI);
                var request = new RestRequest("api/products/{id}", Method.DELETE, DataFormat.Json);
                request.AddUrlSegment("id", textBoxID.Text);

                client.Execute(request);

                textBoxID.Text = "";
                textBoxName.Text = "";
                textBoxCategory.Text = "";
                textBoxPrice.Text = "";

            }
        }
    }
}
