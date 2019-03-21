using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace udpstruct
{
    [Serializable]
    public class Players_Hero
    {
        private float xCoordinate;
        private float yCoordinate;
        private float zCoordinate;
        private uint hitPoint;
        private uint manaPoint;
        private uint gold;
        private uint level;
        private string status;

        public float Units_xCoordinate { get => xCoordinate; set => xCoordinate = value; }
        public float Units_yCoordinate { get => yCoordinate; set => yCoordinate = value; }
        public float Units_zCoordinate { get => zCoordinate; set => zCoordinate = value; }
        public uint Units_hitPoint { get => hitPoint; set => hitPoint = value; }
        public uint Units_manaPoint { get => manaPoint; set => manaPoint = value; }
        public uint Units_Gold { get => gold; set => gold = value; }
        public uint Units_Level { get => level; set => level = value; }
        public string Units_Status { get => status; set => status = value; }
    }

    class Program
    {
        static TcpClient client;
        Socket serverSocket = null;

        static void Main(string[] args)
        {
            connectToServer();
        }

        public static void DoSerialize()
        {

        }

        public static void connectToServer()
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect("127.0.0.1", 69);
            IPAddress ipAddrs = IPAddress.Parse("127.0.0.1");
            IPEndPoint iPEndPoint = new IPEndPoint(ipAddrs, 69);
            Players_Hero heroName = new Players_Hero();
            heroName.Units_xCoordinate = 6969f;
            heroName.Units_yCoordinate = 1234f;
            heroName.Units_zCoordinate = 100f;
            heroName.Units_hitPoint = 1356;
            heroName.Units_manaPoint = 960;
            heroName.Units_Level = 12;
            heroName.Units_Gold = 849;
            heroName.Units_Status = "Stunned";

            IFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();

        }
    }
}
