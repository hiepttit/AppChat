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
        public delegate void SetDataControl(string Data);
        public SetDataControl SetDataFunction = null;
        Socket serverSocket = null;
        IPEndPoint iep = null;
        Socket clientSocket = null;
        //buffer để nhận và gởi dữ liệu
        byte[] buff = new byte[1024];
        //Số byte thực sự nhận được
        int byteReceive = 0;
        string stringReceive = "";

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.SetDataFunction = new SetDataControl(SetData);
        }
        private void SetData(string Data)
        {
            this.txtReceive.Text +=Data + System.Environment.NewLine ;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
            iep = new IPEndPoint(IPAddress.Any, 9001);
            server.Bind(iep);
            server.Listen(5);
            server.BeginAccept(new AsyncCallback(AcceptCallback), server);
        }
        

        void AcceptCallback(IAsyncResult iar)
        {
            serverSocket = (Socket)iar.AsyncState;
            clientSocket = serverSocket.EndAccept(iar);
            string hello = "Hello Client";
            buff = Encoding.ASCII.GetBytes(hello);
            SetDataFunction("Client da ket noi den");
            this.textBox2.Text = clientSocket.RemoteEndPoint.ToString();
            clientSocket.BeginSend(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(SendCallback), clientSocket);
        }

        void SendCallback(IAsyncResult iar)
        {
            Socket s = (Socket)iar.AsyncState;
            s.EndSend(iar);
            //khởi tạo lại buffer để nhận dữ liệu
            buff = new byte[1024];
            //Bắt đầu nhận dữ liệu
            s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new
            AsyncCallback(ReceiveCallback), s);
        }
        public void Close()
        {
            clientSocket.Close();
            serverSocket.Close();
        }
        void ReceiveCallback(IAsyncResult iar)
        {
            Socket s = (Socket)iar.AsyncState;
            try
            {
                byteReceive = s.EndReceive(iar);
            }
            catch
            {
                this.Close();
                SetDataFunction("Client ngat ket noi");
                return;
            }
            if (byteReceive == 0)
            {
                Close();
                SetDataFunction("Clien dong ket noi");
            }
            else
            {
                stringReceive = Encoding.ASCII.GetString(buff, 0, byteReceive);
                SetDataFunction(stringReceive);
                s.BeginSend(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(SendCallback), s);
            }
        }
    }
}
