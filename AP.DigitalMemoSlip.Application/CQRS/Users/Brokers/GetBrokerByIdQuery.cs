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
    public class GetBrokerByIdQuery : IRequest<Broker>
    {
        public int Id { get; set; }
    }

    public class GetBrokerByIdQueryHandler : IRequestHandler<GetBrokerByIdQuery, Broker>
    {
        private readonly IUnitofWork uow;
        public GetBrokerByIdQueryHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<Broker> Handle(GetBrokerByIdQuery request, CancellationToken cancellationToken) // implement validation!
        {
            return await uow.BrokersRepository.GetById(request.Id);
        }
    }
}
