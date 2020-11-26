using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client_lib
{
    public class TCP_Connector
    {
        #region fields
        public static int DEFAULT_PORT = 9000;
        public static IPAddress DEFAULT_IPADRESS= IPAddress.Parse("127.0.0.1");
        public static uint BUFFER_SIZE = 2048;
        private int port;
        private IPAddress ipAddress;
        private TcpClient tcpClient;
        private NetworkStream stream;
        private byte[] buffer;
        #endregion

        #region field_definitions
        TcpClient TCPClient
        {
            get => tcpClient;
            set { tcpClient = value; }
        }

        public IPAddress IPAddress
        {
            get => ipAddress;
            set { ipAddress = value; }
        }
        public NetworkStream Stream
        {
            get => stream;
            set { stream = value; }
        }

        public int Port
        {
            get => port;
            set { port = value; }
        }
        public byte[] Buffer
        {
            get => buffer;
            set { buffer = value; }
        }
        #endregion

        public TCP_Connector(int port, IPAddress ipAddress)
        {
            this.Port = port;
            this.IPAddress = ipAddress;
            this.Buffer = new byte[BUFFER_SIZE];
        }

        public TCP_Connector()
        {
            this.Port = DEFAULT_PORT;
            this.IPAddress = DEFAULT_IPADRESS;
            this.Buffer = new byte[BUFFER_SIZE];
        }

        public void Connect() 
        {
            this.TCPClient = new TcpClient(this.IPAddress.ToString(),this.Port);
            this.Stream = this.TCPClient.GetStream();
        }

        public void Disconnect()
        {
            this.Stream.Close();
            this.TCPClient.Close();
        }

        private void sendToServer(String m)
        {
            if (stream != null)
            {
                byte[] message = Encoding.ASCII.GetBytes(m);
                this.Stream.Write(message, 0, message.Length);
            }
        }

        private String getServerResponse()
        {
            Array.Clear(Buffer, 0, Buffer.Length);
            int messageLength = this.Stream.Read(Buffer, 0, Buffer.Length);
            return Encoding.UTF8.GetString(Buffer, 0, messageLength); ;
        }

        public Communication_Package ReceivePackage()
        {
            Array.Clear(Buffer, 0, Buffer.Length);

            Stream.Read(Buffer, 0, Buffer.Length);
            Communication_Package package = new Communication_Package(Buffer);
            return package;
        }

        public void Send(Communication_Package package)
        {
            if (this.Stream != null)
            {
                byte[] data = package.ToByteArray();
                Stream.Write(data, 0, data.Length);
            }
            
        }
    }
}
