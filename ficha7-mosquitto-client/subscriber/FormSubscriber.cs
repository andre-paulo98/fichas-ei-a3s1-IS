using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace subscriber {
    public partial class FormSubscriber : Form {

        private MqttClient broker;
        string[] topics = { "news", "complaints", "spam" };
        byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };

        public FormSubscriber() {
            InitializeComponent();
            richTextBox1.HideSelection = false;
        }

        private void button1_Click(object sender, EventArgs e) {
            broker = new MqttClient(textBox1.Text);
            broker.Connect(Guid.NewGuid().ToString());
            broker.MqttMsgPublishReceived += Broker_MqttMsgPublishReceived;
            broker.Subscribe(topics, qosLevels);
        }

        private void Broker_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) {
            string msg = Encoding.UTF8.GetString(e.Message);
            //MessageBox.Show($"Recebi a mensage: {msg} do tópico: {e.Topic}");
            richTextBox1.Invoke((MethodInvoker)delegate {
                richTextBox1.AppendText("{" + e.Topic + "}: " + msg + "\n");
            });
        }

        private void button2_Click(object sender, EventArgs e) {
            broker.Unsubscribe(topics);
        }

        private void FormSubscriber_FormClosing(object sender, FormClosingEventArgs e) {
            if (broker.IsConnected) {
                broker.Unsubscribe(topics);
                broker.Disconnect();
            }
        }
    }
}
