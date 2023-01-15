
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

    }
}
