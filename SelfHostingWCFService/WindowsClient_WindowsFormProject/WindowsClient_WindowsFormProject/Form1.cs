using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsClient_WindowsFormProject
{
    public partial class Form1 : Form
    {
        HelloService.HelloServiceClient client;
        public Form1()
        {
            InitializeComponent();
            client = new HelloService.HelloServiceClient();
        }

        private void btnGetMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (client.State == System.ServiceModel.CommunicationState.Faulted)
                {
                    client = new HelloService.HelloServiceClient();
                }
                lblMessage.Text = client.GetMessage(txtName.Text);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }
}
