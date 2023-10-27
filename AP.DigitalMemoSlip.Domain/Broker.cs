using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DigitalMemoSlip.Domain
{
    public class Broker : User
    {
        public List<Company> ?Companies { get; set; }
        public string VATNo { get; set; }
        public string PhoneNr { get; set; }
        public string InsuranceCoverage { get; set; }
        public bool IsTCConfirmed { get; set; }
        //public List<Memo> Memos { get; set; }
    }
}
