﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiECommerce.Order.Domain.Entities
{
    public class Address
    {
        public int AddressID { get; set; }
        public string UserID { get; set; }
        public string Disctrict { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }

    }
}
