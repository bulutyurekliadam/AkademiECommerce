using AkademiECommerce.Order.Application.Features.Mediator.Commands;
using AkademiECommerce.Order.Application.Interfaces;
using AkademiECommerce.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiECommerce.Order.Application.Features.Mediator.Handlers
{
    public class CreateOrderingCommandHandler:IRequestHandler<CreateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Ordering
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserID = request.UserID
            });
        }
    }
}
