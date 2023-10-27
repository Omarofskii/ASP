using AP.DigitalMemoSlip.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DigitalMemoSlip.Application.Interfaces
{
    public interface ICompaniesRepository
    {
        public Task<IEnumerable<Company>> GetAll(int pageNr, int pageSize);
        public Task<Company> GetById(int id);
        public Task<Company> Create(Company newCompany);
        public Task Delete(Company company);
    }
}
