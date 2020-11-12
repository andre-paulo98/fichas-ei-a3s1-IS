using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace publisher {
    public partial class FormPublisher : Form {

        MqttClient broker;
        string[] topics = { "news", "complaints", "spam" };

        public FormPublisher() {
            InitializeComponent();
            comboBox1.DataSource = topics;
        }

        private void button2_Click(object sender, EventArgs e) {
            broker = new MqttClient(textBox2.Text);
            broker.Connect(Guid.NewGuid().ToString());
        }

        private void button1_Click(object sender, EventArgs e) {
            if (broker.IsConnected) {
                broker.Publish(comboBox1.SelectedItem.ToString(), Encoding.UTF8.GetBytes(textBox1.Text));
            }
        }

        private void FormPublisher_FormClosing(object sender, FormClosingEventArgs e) {
            if (broker.IsConnected) {
                broker.Unsubscribe(topics);
                broker.Disconnect();
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            string bee = File.ReadAllText("bee.txt");
            var lines = bee.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in lines) {
                broker.Publish("spam", Encoding.UTF8.GetBytes(item));
                Thread.Sleep(10);
            }
        }
    }
}
