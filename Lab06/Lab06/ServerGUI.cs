using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
    class ServerGUI
    {
        private IPAddress serverIP;
        public IPAddress ServerIP
        {
            get
            {
                return serverIP;
            }
            set
            {
                this.serverIP = value;
            }
        }

        private int port;
        public int Port
        {
            get
            {
                return this.port;
            }
            set
            {
                this.port = value;
            }
        }
        IPEndPoint iep = null;
        //buffer để nhận và gởi dữ liệu
        byte[] buff = new byte[1024];
        public List<SocketT2h> clientSockets { get; set; }
        public List<string> _names, listClient = new List<string>();
        List<string> listClientBefore = new List<string>();
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        int received;
        public delegate void SetDataControl(string Data);
        public SetDataControl SetDataFunction, SetDataFunction1, SetDataFunction2 = null;        

        public ServerGUI(IPAddress ServerIP, int Port)
        {
            this.ServerIP = ServerIP;
            this.Port = Port;
            clientSockets = new List<SocketT2h>();
            
        }
        public void Listen()
        {
            iep = new IPEndPoint(ServerIP, Port);
            serverSocket.Bind(iep);
            serverSocket.Listen(5);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }
        void AcceptCallback(IAsyncResult iar)
        {            
            Socket socket = serverSocket.EndAccept(iar);
            clientSockets.Add(new SocketT2h(socket));
            listClient.Add(socket.RemoteEndPoint.ToString());
            if (clientSockets.Count > 1)
            {
                for (int j = 1; j < clientSockets.Count; j++)
                {
                    if (clientSockets[j]._Socket.Connected)
                    {
                        Sendata(socket, clientSockets[j - 1]._Name+" ");
                    }
                }                
            }
            socket.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);            
        }
        void SendCallback(IAsyncResult iar)
        {
            Socket s = (Socket)iar.AsyncState;
            s.EndSend(iar);
        }
        public void Sendata(Socket socket, string noidung)
        {
            byte[] data = Encoding.ASCII.GetBytes(noidung);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }
        void ReceiveCallback(IAsyncResult iar)
        {
            Socket s = (Socket)iar.AsyncState;            
            if (s.Connected)
            {
                try
                {
                    received = s.EndReceive(iar);
                    SetDataFunction("Số client đang kết nối: " + clientSockets.Count.ToString());
                }
                catch (Exception)
                {
                    // client đóng kết nối
                    for (int i = 0; i < clientSockets.Count; i++)
                    {                       
                        if (clientSockets[i]._Socket.RemoteEndPoint.ToString().Equals(s.RemoteEndPoint.ToString()))
                        {
                            for (int j = 0; j < clientSockets.Count; j++)
                            {
                                if (clientSockets[j]._Socket.Connected)
                                {
                                    Sendata(clientSockets[j]._Socket, clientSockets[i]._Name + "off");                                    
                                }
                            }
                            SetDataFunction1(clientSockets[i]._Name+"off");
                            clientSockets.RemoveAt(i);                            
                            SetDataFunction("Số client đang kết nối: " + clientSockets.Count.ToString());
                        }
                    }
                    // xóa trong list
                    for (int i = 0; i < listClient.Count; i++)
                    {
                        listClient.RemoveAt(i);
                        return;
                    }
                    return;
                }
                if (received != 0)
                {
                    string text = Encoding.ASCII.GetString(buff, 0, received);
                    string reponse = string.Empty;

                    if (text.Contains("@@"))
                    {
                        for (int i = 0; i < listClient.Count; i++)
                        {
                            if (s.RemoteEndPoint.ToString().Equals(clientSockets[i]._Socket.RemoteEndPoint.ToString()))
                            {
                                SetDataFunction1(text);
                                //ten.RemoveAt(i);
                                //ten.Insert(i, text.Substring(1, text.Length - 1));
                                clientSockets[i]._Name = text;
                                listClientBefore.Add(clientSockets[i]._Name);
                                s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), s);
                                for (int j = 0; j < clientSockets.Count; j++)
                                {
                                    if (clientSockets[j]._Socket.Connected && clientSockets[j]._Name!=text)
                                    {
                                        Sendata(clientSockets[j]._Socket, clientSockets[i]._Name);
                                    }
                                }
                                return;
                            }
                        }
                    }
                    for (int i = 0; i < clientSockets.Count; i++)
                    {
                        if (s.RemoteEndPoint.ToString().Equals(clientSockets[i]._Socket.RemoteEndPoint.ToString()))
                        {
                            SetDataFunction2(clientSockets[i]._Name + ": " + text + System.Environment.NewLine); 
                        }
                        string[] listText = text.Split(';');
                        foreach (var item in listText)
                        {

                            if (item != "")
                            {
                                if (text.Contains("@") && clientSockets[i]._Name.Substring(1, clientSockets[i]._Name.Length - 1) == item.Substring(item.LastIndexOf("@")))
                                {
                                    Sendata(clientSockets[i]._Socket, item.Substring(0, item.LastIndexOf("@")));
                                }
                            }
                        }
                    }
                    //reponse = "server da nhan" + text;
                    Sendata(s, reponse);
                }
                else
                {
                    for (int i = 0; i < clientSockets.Count; i++)
                    {
                        if (clientSockets[i]._Socket.RemoteEndPoint.ToString().Equals(s.RemoteEndPoint.ToString()))
                        {
                            clientSockets.RemoveAt(i);
                            SetDataFunction("Số client đang kết nối: " + clientSockets.Count.ToString());
                        }
                    }
                }
            }
            s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), s);
        }
    }
}
