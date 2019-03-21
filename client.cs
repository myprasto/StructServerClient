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
    public class Units_Character
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

    class client
    {
        static TcpClient clientSide;
        Socket serverSocket = null;

        static void Main(string[] args)
        {
            connectToServer();
        }

        public static void DoSerialize()
        {
            Units_Character unitsName = new Units_Character();
            unitsName.Units_xCoordinate = 6969f;
            unitsName.Units_yCoordinate = 1234f;
            unitsName.Units_zCoordinate = 100f;
            unitsName.Units_hitPoint = 1356;
            unitsName.Units_manaPoint = 960;
            unitsName.Units_Level = 12;
            unitsName.Units_Gold = 849;
            unitsName.Units_Status = "Stunned";

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("D:\\unitsData.dat", FileMode.Create, FileAccess.Write);
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, unitsName);
            byte[] buffer = memoryStream.ToArray();
            stream.Close();
            Console.WriteLine("Complete");
            Console.ReadKey();
        }

        public static void connectToServer()
        {
            Socket clientSide = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSide.Connect("127.0.0.1", 69);
            IPAddress ipAddrs = IPAddress.Parse("127.0.0.1");
            IPEndPoint iPEndPoint = new IPEndPoint(ipAddrs, 69);
            Units_Character unitsName = new Units_Character();
            unitsName.Units_xCoordinate = 6969f;
            unitsName.Units_yCoordinate = 1234f;
            unitsName.Units_zCoordinate = 100f;
            unitsName.Units_hitPoint = 1356;
            unitsName.Units_manaPoint = 960;
            unitsName.Units_Level = 12;
            unitsName.Units_Gold = 849;
            unitsName.Units_Status = "Stunned";

            IFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, unitsName);
            byte[] buffer = memoryStream.ToArray();
            clientSide.SendTo(buffer, iPEndPoint);
            clientSide.Shutdown(SocketShutdown.Both);
            clientSide.Close();

        }
    }
}
