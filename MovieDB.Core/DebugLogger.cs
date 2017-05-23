using System.Diagnostics;

namespace MovieDB.Core
{
    public class DebugLogger : ILogger
    {
        private const int MaxLength = 2048;

        public void Log(string label, object value)
        {
            string message = label + ": " + value;
            if (message.Length > MaxLength)
                message = message.Substring(0, MaxLength);
            Debug.WriteLine(message);
        }
    }
}
