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
    public class GetConsignerByIdQuery : IRequest<Consigner>
    {
        public int Id { get; set; }
    }

    public class GetConsignerByIdQueryHandler : IRequestHandler<GetConsignerByIdQuery, Consigner>
    {
        private readonly IUnitofWork uow;
        public GetConsignerByIdQueryHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<Consigner> Handle(GetConsignerByIdQuery request, CancellationToken cancellationToken) // implement validation!
        {
            return await uow.ConsignersRepository.GetById(request.Id);
        }
    }
}
