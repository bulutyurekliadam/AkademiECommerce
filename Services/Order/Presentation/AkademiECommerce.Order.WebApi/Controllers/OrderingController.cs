using AkademiECommerce.Order.Application.Features.Mediator.Commands;
using AkademiECommerce.Order.Application.Features.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AkademiECommerce.Order.WebApi.Controllers
{
    public class OrderingController : Controller
    {
        private readonly IMediator _mediator;

        public OrderingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş oluşturuldu");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdering(int id)
        {
            var values = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Sipariş Silindi");
        }
    }
}
