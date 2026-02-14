using Conference.Application.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Conference.WebApi.Controllers;

[ApiController]
[Route("/Orders")]
public class OrdersController: ControllerBase
{
    //public OrdersController()

    [HttpPost]
    public async Task<IActionResult> PostOrders([FromBody] InputOrderDto inputOrder)
    {
        if (inputOrder == null)
        {
            return UnprocessableEntity();
        }

        

        return Ok();
    }
}