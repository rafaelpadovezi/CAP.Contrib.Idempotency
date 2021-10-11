﻿using System.Threading.Tasks;
using DotNetCore.CAP;
using Example.Cap.Api.Dtos;
using Ziggurat;

namespace Example.Cap.Api.Consumers
{
    public class OrderCreatedConsumer : ICapSubscribe
    {
        private readonly IConsumerService<OrderCreatedMessage> _service;

        public OrderCreatedConsumer(IConsumerService<OrderCreatedMessage> service)
        {
            _service = service;
        }

        [CapSubscribe("order.created", Group = "catalog.order.created")]
        public async Task UpdateProductStock(OrderCreatedMessage message)
        {
            await _service.ProcessMessageAsync(message);
        }
    }
}