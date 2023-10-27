using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DigitalMemoSlip.Application.Interfaces
{
    public interface IUnitofWork
    {
        public IConsignersRepository ConsignersRepository { get; }
        public IBrokersRepository BrokersRepository { get; }
        public Task Commit();
    }
}
