using AkademiECommerce.Order.Application.Features.CQRS.Results;
using AkademiECommerce.Order.Application.Interfaces;
using AkademiECommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiECommerce.Order.Application.Features.CQRS.Handlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                AddressID = x.AddressID,
                City = x.City,
                Detail = x.Detail,
                Disctrict = x.Disctrict,
                UserID = x.UserID
            }).ToList();
        }
    }
}
