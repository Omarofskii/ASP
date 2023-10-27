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
    public class AddConsignerCommand : IRequest<Consigner>
    {
        public Consigner Consigner { get; set; }
    }

    public class AddConsignerCommandHandler : IRequestHandler<AddConsignerCommand, Consigner>
    {
        private readonly IUnitofWork uow;
        public AddConsignerCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<Consigner> Handle(AddConsignerCommand request, CancellationToken cancellationToken) // implement validation!
        {
            await uow.ConsignersRepository.Create(request.Consigner);
            await uow.Commit();
            return request.Consigner;
        }
    }

}
