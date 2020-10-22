using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace ProjectXML {
    class HandlerXML {
        public HandlerXML(string xmlFile) {
            XmlFilePath = xmlFile;
        }

        public HandlerXML(string xmlFile, string xsdFile) {
            XmlFilePath = xmlFile;
            XsdFilePath = xsdFile;
        }

        public string XmlFilePath { get; set; }
        public string XsdFilePath { get; set; }

        private bool isValid = true;
        private string validationMessage;
        public string ValidationMessage {
            get { return validationMessage; }
        }

        //**********************************************
        // Ex. 7
        //**********************************************
        public List<string> GetTitles() {

            XmlDocument doc = new XmlDocument();
            doc.Load(XmlFilePath);

            List<string> titles = new List<string>();
            
            foreach (XmlElement item in doc.SelectNodes("/bookstore/book/title")) {
                titles.Add(item.InnerText);
            }

            /*foreach (XmlElement item in doc.DocumentElement.ChildNodes) {
                titles.Add(item.GetElementsByTagName("title")[0].InnerText);
            }*/

            return titles;
        }
        //**********************************************
        // Ex. 8
        //**********************************************       
        public void UpdateAuthorByTitle(string title, string author) {
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlFilePath);

            doc.SelectSingleNode($"/bookstore/book[title='{title}']/author").InnerText = author;

            doc.Save(XmlFilePath);
        }

        //**********************************************
        // Ex. 9
        //**********************************************  
        public void AddRateToBook(string title, string rate) {
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlFilePath);

            XmlNode node = doc.SelectSingleNode($"/bookstore/book[title='{title}']/rate");
            if(node != null) {

                node.InnerText = rate;

            } else { // does not exist, needs to be created

                XmlNode rateEl = doc.CreateElement("rate");
                rateEl.InnerText = rate;

                doc.SelectSingleNode($"/bookstore/book[title='{title}']").AppendChild(rateEl);
            }

            doc.Save(XmlFilePath);
        }
        //**********************************************
        // Ex. 10 Add Attribute
        //**********************************************  
        public void AddAttributeISBNToBook(string title, string isbn) {
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlFilePath);

            XmlAttribute isbAt = doc.CreateAttribute("isbn");
            isbAt.Value = isbn;

            doc.SelectSingleNode($"/bookstore/book[title='{title}']").Attributes.Append(isbAt);

            doc.Save(XmlFilePath);
        }

        //**********************************************
        // Ex. 11 Get Number of Books per Category
        //********************************************** 
        public int getNumberBooksPerCategory(string category) {

            XmlDocument doc = new XmlDocument();
            doc.Load(XmlFilePath);

            var r = doc.SelectNodes($"/bookstore/book[@category='{category}']");

            return r.Count;
        }

        #region Ex. 6 - Validate XML with XML Schema (xsd)
        public bool ValidateXML() {
            isValid = true;
            XmlDocument doc = new XmlDocument();
            try {
                doc.Load(XmlFilePath);
                ValidationEventHandler eventHandler = new ValidationEventHandler(MyValidateMethod);
                doc.Schemas.Add(null, XsdFilePath);
                doc.Validate(eventHandler);
            } catch (XmlException ex) {
                isValid = false;
                validationMessage = string.Format("ERROR: {0}", ex.ToString());
            }
            return isValid;
        }

        private void MyValidateMethod(object sender, ValidationEventArgs args) {
            isValid = false;
            switch (args.Severity) {
                case XmlSeverityType.Error:
                    validationMessage = string.Format("ERROR: {0}", args.Message);
                    break;
                case XmlSeverityType.Warning:
                    validationMessage = string.Format("WARNING: {0}", args.Message);
                    break;
                default:
                    break;
            }
        }
        #endregion


    }
}
