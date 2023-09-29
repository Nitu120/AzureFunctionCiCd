using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusTopicToTableAndQueue.Model
{
    public class QuoteStoredMessage
    {
        public Guid QuoteId { get; set; }
        public string SupplierCode { get; set; }
    }
}
