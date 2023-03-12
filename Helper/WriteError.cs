
using Domain;
using System.IO;

namespace Helper
{
    public static partial class WriteError
    {
        public static void WriteLog(string message, Exception ex)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Log(message, w);
            }
        }
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Error: ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine($"  :{logMessage}");
        }

        public static void WriteAction(string userId, string action)
        {
            string path;
            path = $"log_{DateTime.Now.Year}{ObtenerFormatoFecha(DateTime.Now.Month.ToString())}{ObtenerFormatoFecha(DateTime.Now.Day.ToString())}_{DateTime.Now.Minute.ToString()}.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter w = File.CreateText(path))
                {
                    LogAction(userId, action, w);
                }
            }
            else
            {
                using (StreamWriter w = File.AppendText(path))
                {
                    LogAction(userId, action, w);
                }
            }
        }
        public static void LogAction(string userId, string action, TextWriter w)
        {
            w.Write("\r\nLog Action: ");
            w.Write($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}: ");
            w.Write($" User=> {userId}; action=> {action};");
        }

        public static string ObtenerFormatoFecha(string sValor)
        {
            if (sValor.Length == 1)
            {
                sValor = "0" + sValor;
            }
            return sValor;
        }
    }
}
