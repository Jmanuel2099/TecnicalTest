using Microsoft.AspNetCore.Mvc;
using TestModel.TestDataBase;
using TestModel.TestDataBase.ParametersModule;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private ItemImpModel _itemModel;

        public ItemController() 
        {
            _itemModel = new ItemImpModel();
        } 
            
        // GET: api/<ItemController>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            return Ok(await _itemModel.RecordItemList());
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            return Ok(await _itemModel.RecordItemById(id));
        }
    }
}
