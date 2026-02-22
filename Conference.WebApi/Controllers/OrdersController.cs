using Conference.Application.DTOs;
using Conference.Application.EventBus;
using Conference.Application.Messages;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Conference.WebApi.Controllers;

[ApiController]
[Route("/Orders")]
public class OrdersController: ControllerBase
{
    private readonly IServiceBusPublisher _serviceBus;
    public OrdersController(IServiceBusPublisher serviceBus)
    {
        _serviceBus = serviceBus;
    }

    [HttpPost]
    public async Task<IActionResult> PostOrders([FromBody] InputOrderDto inputOrder)
    {
        if (inputOrder == null)
        {
            return UnprocessableEntity();
        }

        var message = new OrderCreatedMessage
        {
            AttendeeIdList = inputOrder.AttendeeIdList,
            ConferenceId = inputOrder.ConferenceId,
            SeatId = inputOrder.SeatId
        };

        await _serviceBus.PublishMessageAsync(message);

        return Ok();
    }
}