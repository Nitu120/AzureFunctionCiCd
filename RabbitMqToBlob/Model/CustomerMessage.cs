using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqToBlob.Model
{
    public class CustomerMessage
    {
        public string EventType { get; set; }
        public int CustomerId { get; set; }
    }
}
