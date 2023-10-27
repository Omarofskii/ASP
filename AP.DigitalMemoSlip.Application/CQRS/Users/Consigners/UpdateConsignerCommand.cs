using AP.DigitalMemoSlip.Application.Interfaces;
using AP.DigitalMemoSlip.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP.DigitalMemoSlip.Application.CQRS.Users.Consigners
{
    public class UpdateConsignerCommand : IRequest<Consigner>
    {
        public Consigner Consigner { get; set; }
    }

    public class UpdateConsignerCommandHandler : IRequestHandler<UpdateConsignerCommand, Consigner>
    {
        private readonly IUnitofWork uow;
        public UpdateConsignerCommandHandler(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public async Task<Consigner> Handle(UpdateConsignerCommand request, CancellationToken cancellationToken) // implement validation!
        {
            var existing = await uow.ConsignersRepository.GetById(request.Consigner.Id);
            if (existing == null)
                throw new KeyNotFoundException("the consigner was not found");

            existing.Email = request.Consigner.Email;
            existing.PasswordHash = request.Consigner.PasswordHash;
            existing.Role = request.Consigner.Role;
            existing.FirstName = request.Consigner.FirstName;
            existing.LastName = request.Consigner.LastName;
            existing.CompanyId = request.Consigner.CompanyId;
            existing.Brokers = request.Consigner.Brokers;
            //existing.Memos = request.Consigner.Memos; // implementeren

            await uow.Commit();
            return existing;
        }
    }
}
