using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MSMQ_Multicast
{
    class Program
    {
        static void Main(string[] args)
        {
            SendMessageToQueue();
            Console.ReadKey();
        }
        private static void SendMessageToQueue()
        {
            string currentDate = DateTime.Now.ToString();
            using (var msgQ = new MessageQueue("FormatName:MULTICAST=234.1.1.1:8000"))
            {
                msgQ.DefaultPropertiesToSend.Recoverable = true;
                msgQ.Send(currentDate);
            }          
            Console.WriteLine("Message sent ......");
            Console.WriteLine(" [MSMQ] Sent {0}", currentDate);
        }
    }
}
