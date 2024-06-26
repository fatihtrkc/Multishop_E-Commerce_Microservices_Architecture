﻿using Order.Domain.Entities.Abstract;

namespace Order.Domain.Entities.Concrete
{
    public class Address : BaseEntity
    {
        public Guid UserId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Info { get; set; }
    }
}