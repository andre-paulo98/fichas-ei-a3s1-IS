using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace ficha5_ServerBookstore {

    public class ServiceBookstore : IServiceBookstore {

        string FILEPATH = AppDomain.CurrentDomain.BaseDirectory + @"App_Data\bookstore.xml";

        public void AddBook(Book newBook) {
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);

            XmlNode bookstoreNode = doc.SelectSingleNode("/bookstore");

            XmlElement book = doc.CreateElement("book");
            book.SetAttribute("category", newBook.Category.ToString());
            XmlElement title = doc.CreateElement("title");
            title.InnerText = newBook.Title;
            XmlElement author = doc.CreateElement("author");
            author.InnerText = newBook.Author;
            XmlElement year = doc.CreateElement("year");
            year.InnerText = newBook.Year + "";
            XmlElement price = doc.CreateElement("price");
            price.InnerText = newBook.Price + "";

            book.AppendChild(title);
            book.AppendChild(author);
            book.AppendChild(year);
            book.AppendChild(price);

            bookstoreNode.AppendChild(book);

            doc.Save(FILEPATH);
        }

        public bool DeleteBook(string title) {

            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);

            XmlNode nodeBook = doc.SelectSingleNode($"/bookstore/book[title='{title}']");
            if (nodeBook != null) {
                XmlNode pai = nodeBook.ParentNode;
                pai.RemoveChild(nodeBook);

                doc.Save(FILEPATH);
                return true;
            }
            return false;
        }

        public Book GetBookByTitle(string title) {
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);

            XmlNode nodeBook = doc.SelectSingleNode($"/bookstore/book[title='{title}']");
            if(nodeBook != null) {
                /*string btitle = nodeBook["title"].InnerText;
                string bauthor = nodeBook["author"].InnerText;
                double bprice = Convert.ToDouble(nodeBook["price"].InnerText.Replace('.', ','));
                int byear = int.Parse(nodeBook["year"].InnerText);
                BookCategory bcategory = (BookCategory)Enum.Parse(typeof(BookCategory), nodeBook.Attributes["category"].Value);

                return new Book() {
                    Title = btitle,
                    Author = bauthor,
                    Price = bprice,
                    Year = byear,
                    Category = bcategory
                };*/
                return bookFromElement((XmlElement)nodeBook);
            }
            return null;
        }

        public List<Book> GetBooks() {

            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);

            List<Book> books = new List<Book>();

            foreach(XmlElement item in doc.SelectNodes("/bookstore/book")) {
                books.Add(bookFromElement(item));
            }

            return books;
        }

        public List<Book> GetBooksByCategory(BookCategory category) {
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);

            List<Book> books = new List<Book>();

            foreach (XmlElement item in doc.SelectNodes($"/bookstore/book[@category='{category.ToString()}']")) {
                books.Add(bookFromElement(item));
            }

            return books;
        }

        private Book bookFromElement(XmlElement el) {
            string title = el["title"].InnerText;
            string author = el["author"].InnerText;
            double price = Convert.ToDouble(el["price"].InnerText, NumberFormatInfo.InvariantInfo);
            int year = int.Parse(el["year"].InnerText);
            BookCategory bcategory = (BookCategory)Enum.Parse(typeof(BookCategory), el.Attributes["category"].Value);

            return new Book() {
                Title = title,
                Author = author,
                Price = price,
                Year = year,
                Category = bcategory
            };
        }
    }
}
