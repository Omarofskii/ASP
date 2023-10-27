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
    public class DeleteBrokerCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteBrokerCommandHandler : IRequestHandler<DeleteBrokerCommand>
    {
        private readonly IUnitofWork uow;
        public DeleteBrokerCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task Handle(DeleteBrokerCommand request, CancellationToken cancellationToken)
        {
            var broker = await uow.BrokersRepository.GetById(request.Id);
            if (broker == null)
                throw new KeyNotFoundException("the broker was not found");

            await uow.BrokersRepository.Delete(broker);
            await uow.Commit();
        }
    }
}
