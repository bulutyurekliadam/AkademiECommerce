﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiECommerce.Order.Application.Features.CQRS.Queries
{
    public class GetAddressByIdQuery
    {
        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

       
    }
}
