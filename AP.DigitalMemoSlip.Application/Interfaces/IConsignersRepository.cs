using AP.DigitalMemoSlip.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DigitalMemoSlip.Application.Interfaces
{
    public interface IConsignersRepository
    {
        public Task<IEnumerable<Consigner>> GetAll(int pageNr, int pageSize);
        public Task<Consigner> GetById(int id);
        public Task<Consigner> Create(Consigner newConsigner);
        public Task<Consigner> Update(Consigner modifiedConsigner);
        public Task Delete(Consigner consigner);
    }
}
