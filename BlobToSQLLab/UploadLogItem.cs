using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobToSQLLab
{
    
    
        public class UploadLogItem
        {
            public Guid Id { get; set; }
            public string BlobName { get; set; }
            public long Size { get; set; }
        }
    }

