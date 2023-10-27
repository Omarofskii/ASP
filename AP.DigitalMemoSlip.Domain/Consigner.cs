using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DigitalMemoSlip.Domain
{
    public class Consigner : User
    {
        public int CompanyId { get; set; }
        public List<Broker> ?Brokers { get; set; }
        //public List<Memo> Memos { get; set; }
    }
}
