using AP.DigitalMemoSlip.Application.Interfaces;
using AP.DigitalMemoSlip.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP.DigitalMemoSlip.Application.CQRS.Users.Brokers
{
    public class UpdateBrokerCommand : IRequest<Broker>
    {
        public Broker Broker { get; set; }
    }

    public class UpdateBrokerCommandHandler : IRequestHandler<UpdateBrokerCommand, Broker>
    {
        private readonly IUnitofWork uow;
        public UpdateBrokerCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public async Task<Broker> Handle(UpdateBrokerCommand request, CancellationToken cancellationToken) // implement validation!
        {
            var existing = await uow.BrokersRepository.GetById(request.Broker.Id);
            if (existing == null)
                throw new KeyNotFoundException("the broker was not found");

            existing.Email = request.Broker.Email;
            existing.PasswordHash = request.Broker.PasswordHash;
            existing.Role = request.Broker.Role;
            existing.FirstName = request.Broker.FirstName;
            existing.LastName = request.Broker.LastName;
            existing.Companies = request.Broker.Companies;
            existing.VATNo = request.Broker.VATNo;
            existing.PhoneNr = request.Broker.PhoneNr;
            existing.InsuranceCoverage = request.Broker.InsuranceCoverage;
            existing.IsTCConfirmed = request.Broker.IsTCConfirmed;
            //existing.Memos = request.Broker.Memos; // must be implemented!

            await uow.Commit();
            return existing;
        }
    }
}
