using System;
using System.Collections.Concurrent;
using System.IO;
using System.Windows.Threading;

namespace TPWA.Data
{
    public class DiagnosticsLogger
    {
        private readonly ConcurrentQueue<string> _logQueue = new ConcurrentQueue<string>();
        private readonly string _filePath;
        private readonly DispatcherTimer _timer;

        public DiagnosticsLogger(string filePath)
        {
            _filePath = filePath;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(5); // Adjust interval as needed
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        public void Log(string message)
        {
            _logQueue.Enqueue(message);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            using (var streamWriter = new StreamWriter(_filePath, true))
            {
                while (_logQueue.TryDequeue(out string logMessage))
                {
                    streamWriter.WriteLine(logMessage);
                }
            }
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
