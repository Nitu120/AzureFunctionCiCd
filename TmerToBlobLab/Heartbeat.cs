using System;
using System.IO;
using System.Text.Json;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace TmerToBlobLab
{
    public class Heartbeat
    {
        [FunctionName("Heartbeat")]
        [StorageAccount("HeartbeatOutputStorageConnectionString")]
        public void Run(
            [TimerTrigger("0 */1 * * * *")] TimerInfo myTimer,
            [Blob("heartbeat/{DateTime}.json", FileAccess.Write)] out string blobOutput,
            ILogger log)
        {
            var status = new
            {
                Component = "save-handler",
                Version = "1.0.1.0",
                TimestampUtc = DateTime.UtcNow,
                StatusCode = 200,
                StatusMessage = "OK"
            };

            log.LogInformation($"Writing status for: {status.Component}; at: {DateTime.UtcNow} (UTC)");

            blobOutput = JsonSerializer.Serialize(status);
        }
    }
}
