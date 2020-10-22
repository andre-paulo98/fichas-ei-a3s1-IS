using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProjectXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEx5_Click(object sender, EventArgs e)
        {
            CreateXML();
        }

        public string CreateXML()
        {
            XmlDocument doc = new XmlDocument();
            // Create the XML Declaration, and append it to XML document
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);
            // Create the root element
            XmlElement root = doc.CreateElement("bookstore");
            doc.AppendChild(root);
            // Create Books
            // Note that to set the text inside the element,
            // you use .InnerText
            // You use SetAttribute to set attribute
            root.AppendChild(createBook(doc, "CHILDREN", "0-3707-0631-5", "Harry Poter", "J K. Rowling", "2005", "29.99", "hardback"));
            root.AppendChild(createBook(doc, "WEB", "0-8268-0958-8", "Learning XML", "Erik t. Ray", "2003", "39.95", "paperback"));
            root.AppendChild(createBook(doc, "WEB", "0-5739-4044-4", "Programming .NET Web Services", "Alex Ferrara", "2002", "38.36", "electronic book text"));

            doc.Save(@"sample.xml");
            //string xmlOutput = doc.OuterXml;
            return doc.OuterXml;
            //return doc.InnerXml;
        }

        public XmlElement createBook(XmlDocument doc, string cat, string isbn, string t, string au, string y, string p, string bf)
        {
            XmlElement book = doc.CreateElement("book");
            book.SetAttribute("category", cat);
            book.SetAttribute("isbn", isbn);
            XmlElement title = doc.CreateElement("title");
            title.InnerText = t;
            XmlElement author = doc.CreateElement("author");
            author.InnerText = au;
            XmlElement year = doc.CreateElement("year");
            year.InnerText = y;
            XmlElement price = doc.CreateElement("price");
            price.InnerText = p;
            XmlElement bookformat = doc.CreateElement("bookformat");
            bookformat.InnerText = bf;
            book.AppendChild(title);
            book.AppendChild(author);
            book.AppendChild(year);
            book.AppendChild(price);
            book.AppendChild(bookformat);
            return book;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "XML files (*.xml)|*.xml";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxXmlFile.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "Schema files (*.xsd)|*.xsd";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                textBoxXsdFile.Text = openFileDialog1.FileName;
            }
        }

        private void buttonEx6_Click(object sender, EventArgs e) {
            HandlerXML handler = new HandlerXML(textBoxXmlFile.Text, textBoxXsdFile.Text);
            MessageBox.Show(handler.ValidateXML() ? "É válido!" : ("ERRO!\n:"+handler.ValidationMessage));
        }

        private void buttonEx7_Click(object sender, EventArgs e) {
            HandlerXML handler = new HandlerXML(textBoxXmlFile.Text, textBoxXsdFile.Text);
            var titles = handler.GetTitles();

            listBoxBookTitles.DataSource = titles;
        }

        private void listBoxBookTitles_SelectedIndexChanged(object sender, EventArgs e) {
            labelSelectedTitle.Text = listBoxBookTitles.SelectedItem.ToString();
        }

        private void buttonEx8_Click(object sender, EventArgs e) {
            string author = textBoxNewAuthorName.Text;

            HandlerXML handler = new HandlerXML(textBoxXmlFile.Text, textBoxXsdFile.Text);
            handler.UpdateAuthorByTitle(labelSelectedTitle.Text, author);

            MessageBox.Show("Atualizado com sucesso!");
        }

        private void button3_Click(object sender, EventArgs e) {
            string rate = numericUpDown1.Value.ToString();

            HandlerXML handler = new HandlerXML(textBoxXmlFile.Text, textBoxXsdFile.Text);
            handler.AddRateToBook(labelSelectedTitle.Text, rate);

            MessageBox.Show("Atualizado com sucesso!");
        }

        private void buttonEx10_Click(object sender, EventArgs e) {
            string isbn = textBoxISBN.Text;

            HandlerXML handler = new HandlerXML(textBoxXmlFile.Text, textBoxXsdFile.Text);
            handler.AddAttributeISBNToBook(labelSelectedTitle.Text, isbn);

            MessageBox.Show("Atualizado com sucesso!");
        }

        private void button4_Click(object sender, EventArgs e) {
            string category = textBox1.Text;

            HandlerXML handler = new HandlerXML(textBoxXmlFile.Text, textBoxXsdFile.Text);
            int number = handler.getNumberBooksPerCategory(category);

            MessageBox.Show($"Número de livros da categoria '{category}': {number}");
        }

        private void button5_Click(object sender, EventArgs e) {
            XPathEditor editor = new XPathEditor();
            editor.ShowDialog();
        }
    }
}
