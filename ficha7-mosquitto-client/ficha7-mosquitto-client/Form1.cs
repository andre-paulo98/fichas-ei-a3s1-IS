using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ficha7_mosquitto_client {
    public partial class Form1 : Form {

        private MqttClient broker;
        string[] topics = { "news", "complaints" };
        byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };
        string guid;

        public Form1() {
            InitializeComponent();
            broker = new MqttClient("10.20.132.30");
            guid = Guid.NewGuid().ToString();
            broker.Connect(guid);
            if(!broker.IsConnected) {
                MessageBox.Show("Error connecting to broker");
                return;
            }

            broker.MqttMsgPublished += Broker_MqttMsgPublished;
            broker.MqttMsgPublishReceived += Broker_MqttMsgPublishReceived;
            broker.MqttMsgSubscribed += Broker_MqttMsgSubscribed;
            broker.MqttMsgUnsubscribed += Broker_MqttMsgUnsubscribed;

            broker.Subscribe(topics, qosLevels);

            comboBox1.DataSource = topics;

            richTextBox1.HideSelection = false;

        }

        private void Broker_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) {
            string msg = Encoding.UTF8.GetString(e.Message);
            //MessageBox.Show($"Recebi a mensage: {msg} do tópico: {e.Topic}");
            richTextBox1.Invoke((MethodInvoker) delegate {
                richTextBox1.AppendText("{"+e.Topic+"}: "+msg+"\n");
            });
            
        }

        private void Broker_MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e) {
            //throw new NotImplementedException();
        }

        private void Broker_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e) {
            //throw new NotImplementedException();
        }

        private void Broker_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e) {
           // throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            if(broker.IsConnected) {
                broker.Publish(comboBox1.SelectedItem.ToString(), Encoding.UTF8.GetBytes($"({guid}) => {textBox1.Text}"));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if(broker.IsConnected) {
                broker.Unsubscribe(topics);
                broker.Disconnect();
            }
        }
    }
}
