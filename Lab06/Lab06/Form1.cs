using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab06
{
    public partial class Form1 : Form
    {
        ServerGUI server = new ServerGUI(IPAddress.Any, 100);

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            server.SetDataFunction = new ServerGUI.SetDataControl(SetData);
            server.SetDataFunction1 = new ServerGUI.SetDataControl(SetData1);
            server.SetDataFunction2 = new ServerGUI.SetDataControl(SetData2);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            server.Listen();           
        }

        private void SetData(string Data)
        {
            this.lb_soluong.Text=Data;           
        }
        private void SetData1(string Data)
        {
            this.list_Client.Items.Add(Data);
            if(Data.Contains("off"))
            {
                 list_Client.Items.Remove(Data);
                 for (int i = 0; i < list_Client.Items.Count; i++)
                 {
                     if(Data.Contains(list_Client.Items[i].ToString()))
                     {
                         list_Client.Items.RemoveAt(i);
                     }                    
                 }
                 
            }
        }
        private void SetData2(string Data)
        {
            this.txtReceive.AppendText(Data);
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list_Client.CheckedItems.Count; i++)
            {
                foreach (object item in list_Client.CheckedItems)
                {
                    string t = item.ToString();
                    for (int j = 0; j < server.clientSockets.Count; j++)
                    {
                        if (server.clientSockets[j]._Socket.Connected && server.clientSockets[j]._Name == t)
                        {
                            server.Sendata(server.clientSockets[j]._Socket, txtSend.Text);
                        }
                    }
                }
                return;
            }
            txtReceive.AppendText("\nServer: " + txtSend.Text + System.Environment.NewLine);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            
        }
    }
}
