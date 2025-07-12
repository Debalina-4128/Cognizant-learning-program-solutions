using System;
using System.Threading;
using System.Windows.Forms;

namespace KafkaClientChat
{
    public partial class Form1 : Form
    {
        private KafkaHelper _kafkaHelper = new KafkaHelper();
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
            _kafkaHelper.StartConsuming(OnMessageReceived, _cts.Token);
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                await _kafkaHelper.SendMessageAsync(message);
                txtMessage.Clear();
            }
        }

        private void OnMessageReceived(string message)
        {
            if (InvokeRequired)
            {
                Invoke(() => lstChat.Items.Add(message));
            }
            else
            {
                lstChat.Items.Add(message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _cts.Cancel();
            base.OnFormClosing(e);
        }
    }
}
