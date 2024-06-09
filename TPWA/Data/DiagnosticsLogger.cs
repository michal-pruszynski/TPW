using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TPWA.Data
{
    public class DiagnosticsLogger
    {
        private readonly ConcurrentQueue<string> _logQueue = new ConcurrentQueue<string>();
        private readonly string _filePath;
        private readonly Task _loggingTask;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public DiagnosticsLogger(string filePath)
        {
            _filePath = filePath;
            _loggingTask = Task.Run(ProcessLogQueue);
        }

        public void Log(string message)
        {
            _logQueue.Enqueue(message);
        }

        private async Task ProcessLogQueue()
        {
            using (var streamWriter = new StreamWriter(_filePath, true))
            {
                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    while (_logQueue.TryDequeue(out string logMessage))
                    {
                        await streamWriter.WriteLineAsync(logMessage);
                    }
                    await Task.Delay(100); // Adjust delay as needed
                }
            }
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
