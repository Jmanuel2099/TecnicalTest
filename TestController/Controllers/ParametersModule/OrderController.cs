using Microsoft.AspNetCore.Mvc;
using TestModel.DbModel.ParametersModule;
using TestModel.Implementation.ParametersModule;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestController.Controllers.ParametersModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderImpModel _orderModel;

        public OrderController()
        {
            _orderModel = new OrderImpModel();
        }
            
        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] OrderDbModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var create = await _orderModel.RecordOrdenCreation(model);
            return Created("create", create);
        }

     
    }
}
