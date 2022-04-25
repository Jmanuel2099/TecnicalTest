using Microsoft.AspNetCore.Mvc;
using TestModel.DbModel.ParametersModule;
using TestModel.Implementation.ParametersModule;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestController.Controllers.ParametersModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyController : ControllerBase
    {
        private BuyImpModel _modelBuy;

        public BuyController()
        {
            _modelBuy = new BuyImpModel();
        }

        // POST api/<BuyController>
        [HttpPost]
        public async Task<IActionResult> PostBuy([FromBody] BuyDbModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var create = await _modelBuy.recordBuyCreation(model);
            return Created("Create", create);
        }
    }
}
