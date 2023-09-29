using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusTopicToTableAndQueue.Model
{
    public class QuoteRequestMessage
    {
        
        public Guid QuoteId { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}

