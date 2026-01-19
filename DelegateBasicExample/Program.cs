using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateBasicExample
{
    class Program
    {
        delegate void LogDel(string text); //delegate reference created
        static void Main(string[] args)
        {

            Log log = new Log(); // for instance method reference to delegate

            LogDel LogTextToScreenDel, LogTextToFileDel; // multicaste delegate throght + 

            LogTextToScreenDel = new LogDel(log.LogTextToScreen);
            LogTextToFileDel = new LogDel(log.LogTextToFile);

            LogDel multiLogDel = LogTextToScreenDel + LogTextToFileDel;


            LogDel logDel = new LogDel(log.LogTextToFile);
            LogDel logDel1 = new LogDel(LogTextToScreen); // for static method invoke

            Console.Write("Please enter your name: ");
            //LogText(LogTextToFileDel, Console.ReadLine()); // deletegate passed as an argument
            multiLogDel(Console.ReadLine());

            Console.ReadKey();
        }

        static void LogTextToScreen(string text) // signature of delegate in static method
        {
            Console.WriteLine($"{DateTime.Now} : {text}");
        }

        static void LogTextToFile(string text) // signature of delegate in static method
        {
            using (StreamWriter streamWriter = new StreamWriter("log.txt", true)) 
            {
                streamWriter.WriteLine($"{DateTime.Now}, {text}");
                Console.WriteLine($"Log written!");
            }
        }

        static void LogText(LogDel logDel, string text) // delegate passed as argument
        {
            logDel(text);
        }
    }

    public class Log
    {
        public void LogTextToScreen(string text) // signature of delegate in instance method
        {
            Console.WriteLine($"{DateTime.Now} : {text}");
        }

        public void LogTextToFile(string text) // signature of delegate in instance method
        {
            using (StreamWriter streamWriter = new StreamWriter("log.txt", true))
            {
                streamWriter.WriteLine($"{DateTime.Now}, {text}");
                Console.WriteLine($"Log written!");
            }
        }
    }
}