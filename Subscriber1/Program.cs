using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber1
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadMessageFromSubscriber1Queue();
            Console.ReadKey();
        }
        private static void ReadMessageFromSubscriber1Queue()
        {
            string currentDate = DateTime.Now.ToString();
            using (var msgQ = new MessageQueue(".\\private$\\subscriber1"))
            {
                msgQ.MulticastAddress = "234.1.1.1:8000";
                while(true)
                {
                    msgQ.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                    var message = msgQ.Receive().Body;
                    Console.WriteLine("Message received is"+ message.ToString());
                }
            }
        }
    }
}
