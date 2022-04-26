using Microsoft.AspNetCore.Mvc;
using TestModel.DbModel.ParametersModule;
using TestModel.Implementation.ParametersModule;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestController.Controllers.ParametersModule
{
    /// <summary>
    /// This class is order controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderImpModel _orderModel;

        public OrderController()
        {
            _orderModel = new OrderImpModel();
        }
        
        /// <summary>
        /// this method isnerts a order in data base
        /// </summary>
        /// <param name="model">order model to be insert in data base</param>
        /// <returns>Response 200 if order was inserted sucessfull</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemByUserId(int id)
        {
            return Ok(await _orderModel.getItemsOrder(id));
        }

    }
}
