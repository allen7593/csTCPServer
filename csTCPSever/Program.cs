using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;


namespace csTCPSever
{
    class Program
    {
        private const int portNum = 8080;
        static void Main(string[] args)
        {
            try
            {
                TcpListener listener = new TcpListener(portNum);
                listener.Start();

                TcpClient client = listener.AcceptTcpClient();
                NetworkStream ns = client.GetStream();

                byte[] byteTime = Encoding.ASCII.GetBytes(DateTime.Now.ToString());
                ns.Write(byteTime, 0, byteTime.Length);
                ns.Close();
                client.Close();
                listener.Stop();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}
