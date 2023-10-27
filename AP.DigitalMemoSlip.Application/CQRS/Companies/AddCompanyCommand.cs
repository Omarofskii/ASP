using AP.DigitalMemoSlip.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DigitalMemoSlip.Application.CQRS.Companies
{
    public class AddCompanyCommand : IRequest<Company> // implement !
    {
        public string Name { get; set; }
    }
}
