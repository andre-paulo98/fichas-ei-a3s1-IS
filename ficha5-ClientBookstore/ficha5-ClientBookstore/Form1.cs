using ficha5_ClientBookstore.BookstoreServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ficha5_ClientBookstore {
    public partial class Form1 : Form {

        private EndpointAddress address;
        private BasicHttpBinding binding = new BasicHttpBinding();

        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            cbFilterCategory.DataSource = Enum.GetValues(typeof(BookCategory));
            cbInfoCategory.DataSource = Enum.GetValues(typeof(BookCategory));
            cbServiceSelected.SelectedIndex = 0;
        }

        private void btGetBooks_Click(object sender, EventArgs e) {
            GetBooks();
        }

        private void btFilterCategory_Click(object sender, EventArgs e) {
            using (ServiceBookstoreClient service = new ServiceBookstoreClient(binding, address)) {
                BookCategory category = (BookCategory)cbFilterCategory.SelectedItem;
                DisplayBooks(service.GetBooksByCategory(category));
            }
        }

        private void btFilterTitle_Click(object sender, EventArgs e) {
            /*using (ServiceBookstoreClient service = new ServiceBookstoreClient(binding, address)) {
                string title = tbFilterTtitle.Text;
                Book book = service.GetBookByTitle(title);
                List<Book> books = new List<Book>();
                if (book != null)
                    books.Add(book);
                DisplayBooks(books.ToArray());
            }*/
            using (ServiceBookstoreClient service = new ServiceBookstoreClient(binding, address)) {
                string title = tbFilterTtitle.Text;
                DisplayBooks(service.GetBooksByTitle(title));
            }
        }

        private void btClear_Click(object sender, EventArgs e) {
            clearInputs();
        }

        private void btDelete_Click(object sender, EventArgs e) {
            if (tbInfoTitle.Text != "") {
                using (ServiceBookstoreClient service = new ServiceBookstoreClient(binding, address)) {
                    if (service.DeleteBook(tbInfoTitle.Text)) {
                        MessageBox.Show("Livro apagado com sucesso");
                        GetBooks();
                    } else {
                        MessageBox.Show("Erro ao apagar o livro");
                    }
                }
            }
        }

        private void btAddBook_Click(object sender, EventArgs e) {
            using (ServiceBookstoreClient service = new ServiceBookstoreClient(binding, address)) {
                service.AddBook(new Book {
                    Title = tbInfoTitle.Text,
                    Author = tbInfoAuthor.Text,
                    Category = (BookCategory)cbInfoCategory.SelectedItem,
                    Price = double.Parse(tbInfoPrice.Text),
                    Year = int.Parse(tbInfoYear.Text),
                });
            }

            GetBooks();

        }

        private void lbBooks_SelectedIndexChanged(object sender, EventArgs e) {
            using (ServiceBookstoreClient service = new ServiceBookstoreClient(binding, address)) {
                Book book = service.GetBookByTitle(lbBooks.SelectedItem.ToString());
                if (book != null) {
                    tbInfoTitle.Text = book.Title;
                    tbInfoAuthor.Text = book.Author;
                    tbInfoYear.Text = book.Year + "";
                    tbInfoPrice.Text = book.Price + "";
                    cbInfoCategory.SelectedItem = book.Category;
                }
            }
        }

        private void cbServiceSelected_SelectedIndexChanged(object sender, EventArgs e) {
            if(cbServiceSelected.SelectedItem + "" == "Cloud") {
                address = new EndpointAddress("http://wcfserviceexample-64.apphb.com/ServiceBookstore.svc");
            } else {
                address = new EndpointAddress("http://localhost:53446/ServiceBookstore.svc");
            }
            GetBooks();
        }

        private void DisplayBooks(Book[] books) {
            lbBooks.Items.Clear();
            foreach (var book in books) {
                lbBooks.Items.Add(book.Title);
            }
        }

        private void clearInputs() {
            tbInfoAuthor.Text = "";
            tbInfoPrice.Text = "";
            tbInfoTitle.Text = "";
            tbInfoYear.Text = "";
            cbInfoCategory.SelectedIndex = 0;
        }

        private void GetBooks() {
            using (ServiceBookstoreClient service = new ServiceBookstoreClient(binding, address)) {
                DisplayBooks(service.GetBooks());
            }
        }
    }
}
