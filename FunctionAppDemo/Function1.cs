using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FunctionAppDemo
{
    public static class Function1
    {
        [FunctionName("UploadLog")]
        [StorageAccount("UploadInputStorageConnectionString")]
        public async Task Run([BlobTrigger("uploads/{name}")] Stream uploadedBlob,
        string name, ILogger log,
                         [Sql("dbo.UploadLogItems", connectionStringSetting:| = "UploadSqlServerConnectionString")] IAsyncCollector<UploadLogItem> uploadLogs)
        {
            log.LogInformation($"New blob uploaded:{name}");

            var uploadLog = new UploadLogItem
            {
                Id = Guid.NewGuid(),
                BlobName = name,
                Size = uploadedBlob.Length
            };
            await uploadLogs.AddAsync(uploadLog);
            await uploadLogs.FlushAsync();

            log.LogInformation("Stored blob upload item in SQL Server");
        }
    }
}
