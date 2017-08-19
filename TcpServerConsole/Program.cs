using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;




namespace TcpServerConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TcpServer();

        }


        static void TcpServer()
        {

            IPEndPoint ipAdd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4096);
            TcpListener listener = new TcpListener(ipAdd);
            listener.Start();


            Console.WriteLine("ipAdd:127.0.0.1 Port:4096のListenを開始しました。");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();


                if (client.Connected)
                {
                    Console.WriteLine("クライアントが接続しました。");
                    listener.Stop();
                    NetworkStream netStream = client.GetStream();
                    StreamReader sReader = new StreamReader(netStream, Encoding.UTF8);

                    string str = String.Empty;

                    do
                    {
                        str = sReader.ReadLine();
                        if (null == str)
                        {
                            break;
                        }
                        Console.WriteLine(str);
                    } while (!str.Equals("quit"));
                    sReader.Dispose();
                    client.Dispose();
                }
                Console.WriteLine("終了するには、Enterキーを押してください");
                Console.ReadLine();
            }
        }
    }
}

