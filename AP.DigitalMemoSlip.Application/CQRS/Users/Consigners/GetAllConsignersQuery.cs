using AP.DigitalMemoSlip.Application.Interfaces;
using AP.DigitalMemoSlip.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DigitalMemoSlip.Application.CQRS.Users.Consigners
{
    public class GetAllConsignersQuery : IRequest<IEnumerable<Consigner>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllConsignersQueryHandler : IRequestHandler<GetAllConsignersQuery, IEnumerable<Consigner>>
    {
        private readonly IUnitofWork uow;
        public GetAllConsignersQueryHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<Consigner>> Handle(GetAllConsignersQuery request, CancellationToken cancellationToken) // implement validation!
        {
            return await uow.ConsignersRepository.GetAll(request.PageNr, request.PageSize);
        }
    }


}
