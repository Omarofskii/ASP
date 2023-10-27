using AP.DigitalMemoSlip.Application.Interfaces;
using AP.DigitalMemoSlip.Domain;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DigitalMemoSlip.Application.CQRS.Users.Brokers
{
    public class AddBrokerCommand : IRequest<Broker>
    {
        public Broker Broker { get; set; }
    }

    public class AddBrokerCommandValidator : AbstractValidator<AddBrokerCommand> // implement
    {
        public AddBrokerCommandValidator(IUnitofWork uow)
        {

            //RuleFor(s => s.Broker.Companies)
            //    .NotNull()
            //    .WithMessage("Companies cannot be empty");

            RuleFor(s => s.Broker.PhoneNr)
            .MaximumLength(10)
            .WithMessage("phone number cannot be longer than 10 characters");

        }
    }

    public class AddConsignerCommandHandler : IRequestHandler<AddBrokerCommand, Broker>
    {
        private readonly IUnitofWork uow;
        public AddConsignerCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public async Task<Broker> Handle(AddBrokerCommand request, CancellationToken cancellationToken)
        {
            await uow.BrokersRepository.Create(request.Broker);
            await uow.Commit();
            return request.Broker;
        }
    }

}
