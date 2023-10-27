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
    public class DeleteConsignerCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteConsignerCommandHandler : IRequestHandler<DeleteConsignerCommand>
    {
        private readonly IUnitofWork uow;
        public DeleteConsignerCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task Handle(DeleteConsignerCommand request, CancellationToken cancellationToken) // implement validation!
        {
            var consigner = await uow.ConsignersRepository.GetById(request.Id);
            if (consigner == null)
                throw new KeyNotFoundException("the consigner was not found");

            await uow.ConsignersRepository.Delete(consigner);
            await uow.Commit();
        }
    }
}
