using AP.DigitalMemoSlip.Application.Interfaces;
using AP.DigitalMemoSlip.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DigitalMemoSlip.Application.CQRS.Users.Brokers
{
    public class GetAllBrokersQuery : IRequest<IEnumerable<Broker>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllBrokersQueryHandler : IRequestHandler<GetAllBrokersQuery, IEnumerable<Broker>>
    {
        private readonly IUnitofWork uow;
        public GetAllBrokersQueryHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<Broker>> Handle(GetAllBrokersQuery request, CancellationToken cancellationToken) // implement validation!
        {
            return await uow.BrokersRepository.GetAll(request.PageNr, request.PageSize);
        }
    }


}
