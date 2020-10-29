using ficha5_ClientBookstore.BookstoreServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ficha5_ClientBookstore {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            cbFilterCategory.DataSource = Enum.GetValues(typeof(BookCategory));
            cbInfoCategory.DataSource = Enum.GetValues(typeof(BookCategory));
        }

        private void btGetBooks_Click(object sender, EventArgs e) {
            ServiceBookstoreClient service = new ServiceBookstoreClient();
            Book[] books = service.GetBooks();

        }

        private void btFilterCategory_Click(object sender, EventArgs e) {

        }

        private void btFilterTitle_Click(object sender, EventArgs e) {

        }

        private void btClear_Click(object sender, EventArgs e) {
            tbInfoAuthor.Text = "";
            tbInfoPrice.Text = "";
            tbInfoTitle.Text = "";
            tbInfoYear.Text = "";
            cbInfoCategory.SelectedIndex = 0;
        }

        private void btDelete_Click(object sender, EventArgs e) {

        }

        private void btAddBook_Click(object sender, EventArgs e) {

        }

        private void lbBooks_SelectedIndexChanged(object sender, EventArgs e) {
            ServiceBookstoreClient service = new ServiceBookstoreClient();
            Book book = service.GetBookByTitle(lbBooks.SelectedItem.ToString());
            tbInfoTitle.Text = book.Title;
            tbInfoAuthor.Text = book.Author;
            tbInfoYear.Text = book.Year + "";
            tbInfoPrice.Text = book.Price + "";
            cbInfoCategory.SelectedItem = book.Category;
        }

    }
}
