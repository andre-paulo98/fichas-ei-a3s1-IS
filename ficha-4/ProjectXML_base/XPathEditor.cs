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

namespace ProjectXML {
    public partial class XPathEditor : Form {
        public XPathEditor() {
            InitializeComponent();
        }

        private void btSelectFile_Click(object sender, EventArgs e) {
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "XML files (*.xml)|*.xml";

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                tbPath.Text = openFileDialog1.FileName;
            }
        }

        private void btExecute_Click(object sender, EventArgs e) {
            XmlDocument doc = new XmlDocument();
            doc.Load(tbPath.Text);
            tbOutput.Text = "";

            try {
                var i = doc.SelectNodes(tbExpression.Text);
                foreach (XmlNode item in i) {
                    try {
                        tbOutput.Text += System.Xml.Linq.XElement.Parse(item.OuterXml).ToString() + "\n";
                    } catch (Exception) {
                        tbOutput.Text += item.OuterXml.ToString() + "\n";
                    }
                    
                }
            } catch (Exception ex) {
                tbOutput.Text = "ERROR!!\n" + ex.Message;
            }
        }

        private void tbExpression_KeyPress(object sender, KeyPressEventArgs e) {
            if(e.KeyChar == (char)Keys.Enter) {
                btExecute.PerformClick();
            }
        }
    }
}
