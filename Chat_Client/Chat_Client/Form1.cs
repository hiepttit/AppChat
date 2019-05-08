using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Client
{
    public partial class Form1 : Form
    {
        private Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        byte[] receivedBuf = new byte[1024];
        String stringReceive = "";

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void ReceiveData(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            if(socket.Connected)
            {
                try
                {
                    int received = socket.EndReceive(ar);
                    stringReceive = Encoding.ASCII.GetString(receivedBuf, 0, received);
                    if (stringReceive.Contains("@@"))
                    {
                        string[] t = stringReceive.Split(' ');
                        foreach (var item in t)
                        {
                            if (item != "")
                            {
                                list_Client.Items.Add(item);
                                if (stringReceive.Contains("@@") && stringReceive.Contains("off"))
                                {
                                    list_Client.Items.Remove(item);
                                    for (int i = 0; i < list_Client.Items.Count; i++)
                                    {
                                        if (stringReceive.Contains(list_Client.Items[i].ToString()))
                                        {
                                            list_Client.Items.RemoveAt(i);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (stringReceive.Contains("@"))
                        {
                            rb_chat.Text += "@" + stringReceive.Substring(stringReceive.LastIndexOf("@")) + System.Environment.NewLine;
                        }
                        else
                        {
                            rb_chat.Text += "Server: " + stringReceive + System.Environment.NewLine;
                        }
                    }
                    _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);
                }
                catch(Exception)
                {
                    lb_stt.Text = ("No connected!");
                }
            }
            
        }

        private void LoopConnect()
        {
            int attempts = 0;
            while (!_clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    _clientSocket.Connect(IPAddress.Loopback, 100);
                }
                catch (SocketException)
                {
                    //Console.Clear();
                    lb_stt.Text = ("No Connected!");
                }
            }
            lb_stt.Text = ("Connected!");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            LoopConnect();
            _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);
            byte[] buffer = Encoding.ASCII.GetBytes("@@" + txtName.Text);
            _clientSocket.Send(buffer);
            txtName.ReadOnly = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_clientSocket.Connected)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(txt_text.Text);
                if (list_Client.CheckedItems.Count > 0)
                {
                    for (int i = 0; i < list_Client.CheckedItems.Count; i++)
                    {
                        foreach (object item in list_Client.CheckedItems)
                        {
                            string t = item.ToString().Substring(1, item.ToString().Length - 1);
                            buffer = Encoding.ASCII.GetBytes("@" + txtName.Text + ": " + txt_text.Text + t + ";");
                            rb_chat.AppendText("@" + txtName.Text + ": " + txt_text.Text + " " + System.Environment.NewLine);
                            _clientSocket.Send(buffer);
                        }
                        return;
                    }
                }
                else
                {
                    _clientSocket.Send(buffer);
                    rb_chat.AppendText("Client: " + txt_text.Text + System.Environment.NewLine);
                }
            }   
        }
        bool Disconnect()
        {
            try
            {
                //Shutdown Soket đang kết nối đến Server
                _clientSocket.Shutdown(SocketShutdown.Both);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }
    }
}
