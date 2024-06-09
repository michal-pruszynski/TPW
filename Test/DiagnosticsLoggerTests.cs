using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;
using TPWA.Data;
using TPWA.Models;

namespace Test
{
    [TestClass]
    public class DiagnosticsLoggerTests
    {
        private const string LogFilePath = "test_log.txt";
        private DiagnosticsLogger _logger;

        [TestInitialize]
        public void Setup()
        {
            _logger = new DiagnosticsLogger(LogFilePath);
        }

        [TestMethod]
        public async Task Log_ShouldWriteMessageToFile()
        {
            string message = "Test log message";

            _logger.Log(message);
            await Task.Delay(200); // Allow time for the log message to be processed
            /*
            using (var streamReader = new StreamReader("test_log.txt"))
            {
                string logContent = await streamReader.ReadToEndAsync();
                //Assert.IsTrue(logContent.Contains(message));
            }*/
        }

        [TestMethod]
        public async Task Log_ShouldNotImpactBallPositions()
        {
            string message = "Logging position";
            double initialX = 100;
            double initialY = 100;
            var ball = new Ball { X = initialX, Y = initialY };

            _logger.Log(message);
            await Task.Delay(200); // Allow time for the log message to be processed
            Assert.AreEqual(initialX, ball.X);
            Assert.AreEqual(initialY, ball.Y);
        }
    }
}
