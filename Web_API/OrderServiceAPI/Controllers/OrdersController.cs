using Microsoft.AspNetCore.Mvc;
using OrderServiceAPI.Models;
using OrderServiceAPI.Services;

namespace OrderServiceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Order>> Get()
    {
        var orders = _orderService.GetOrders();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public ActionResult<Order> Get(int id)
    {
        var order = _orderService.GetOrder(id);
        if (order == null)
            return NotFound();
            
        return Ok(order);
    }

    [HttpPost]
    public ActionResult Post([FromBody] Order order)
    {
        _orderService.CreateOrder(order);
        return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Order order)
    {
        if (id != order.Id)
            return BadRequest();

        var existingOrder = _orderService.GetOrder(id);
        if (existingOrder == null)
            return NotFound();

        _orderService.UpdateOrder(order);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var existingOrder = _orderService.GetOrder(id);
        if (existingOrder == null)
            return NotFound();

        _orderService.CancelOrder(id);
        return NoContent();
    }
}