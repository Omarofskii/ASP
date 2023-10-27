using AP.DigitalMemoSlip.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DigitalMemoSlip.Application.Interfaces
{
    public interface IBrokersRepository
    {
        public Task<IEnumerable<Broker>> GetAll(int pageNr, int pageSize);
        public Task<Broker> GetById(int id);
        public Task<Broker> Create(Broker newBroker);
        public Task<Broker> Update(Broker modifiedBroker);
        public Task Delete(Broker broker);

    }
}
