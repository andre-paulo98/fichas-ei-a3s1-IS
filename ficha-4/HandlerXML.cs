﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace ProjectXML
{
    class HandlerXML
    {
        public HandlerXML(string xmlFile)
        {
            XmlFilePath = xmlFile;
        }

        public HandlerXML(string xmlFile, string xsdFile)
        {
            XmlFilePath = xmlFile;
            XsdFilePath = xsdFile;
        }

        public string XmlFilePath { get; set; }
        public string XsdFilePath { get; set; }

        private bool isValid = true;
        private string validationMessage;
        public string ValidationMessage
        {
            get { return validationMessage; }
        }

        //**********************************************
        // Ex. 7
        //**********************************************
        public List<string> GetTitles()
        {
            return null;
        }
        //**********************************************
        // Ex. 8
        //**********************************************       
        public void UpdateAuthorByTitle(string title, string author)
        {
            
        }

        //**********************************************
        // Ex. 9
        //**********************************************  
        public void AddRateToBook(string title, string rate)
        {
           
        }
        //**********************************************
        // Ex. 10 Add Attribute
        //**********************************************  
        public void AddAttributeISBNToBook(string title, string isbn)
        {
            
        }

        #region Ex. 6 - Validate XML with XML Schema (xsd)
        public bool ValidateXML()
        {
            isValid = true;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(XmlFilePath);
                ValidationEventHandler eventHandler = new ValidationEventHandler(MyValidateMethod);
                doc.Schemas.Add(null, XsdFilePath);
                doc.Validate(eventHandler);
            }
            catch (XmlException ex)
            {
                isValid = false;
                validationMessage = string.Format("ERROR: {0}", ex.ToString());
            }
            return isValid;
        }

        private void MyValidateMethod(object sender, ValidationEventArgs args)
        {
            isValid = false;
            switch (args.Severity)
            {
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
