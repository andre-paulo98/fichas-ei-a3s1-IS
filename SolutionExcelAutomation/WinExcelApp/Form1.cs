using ExcelLib1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinExcelApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExcelHandler.CreateNewExcelFile(tbFilename.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExcelHandler.WriteToExcelFile(tbFilename.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string content = ExcelHandler.ReadFromExcelFile(tbFilename.Text);
            MessageBox.Show("Conteudo do ficheiro: " + content);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExcelHandler.CreateChartToExcelFile(tbFilename.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string content = ExcelHandler.ReadFromExcelFile(tbFilename.Text, (int)numL.Value, (int)numC.Value);
            MessageBox.Show("Conteudo do ficheiro: " + content);
        }
    }
}
