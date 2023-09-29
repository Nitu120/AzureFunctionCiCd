using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusTopicToTableAndQueue.Model
{
    public class QuoteResponseEntity
    {
        public Guid QuoteId
        {
            get { return new Guid(RowKey); }
            set { RowKey = value.ToString(); }
        }
        public string SupplierCode
        {
            get { return PartitionKey; }
            set { PartitionKey = value; }
        }
        public double Quote { get; set; }

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
    }
}
