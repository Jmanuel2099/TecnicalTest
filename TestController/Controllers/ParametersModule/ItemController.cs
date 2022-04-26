using Microsoft.AspNetCore.Mvc;
using TestModel.TestDataBase;
using TestModel.TestDataBase.ParametersModule;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace TestController.Controllers
{
    /// <summary>
    /// This class is item Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private ItemImpModel _itemModel;

        public ItemController() 
        {
            _itemModel = new ItemImpModel();
        } 
        
        /// <summary>
        /// this method gets all item that aren't removed
        /// </summary>
        /// <returns>Item list</returns>
        // GET: api/<ItemController>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            return Ok(await _itemModel.RecordItemList());
        }

        /// <summary>
        /// This method gets a item that have filter(id)
        /// </summary>
        /// <param name="id">filter to search for the item</param>
        /// <returns>200 if exist item whit filter </returns>
        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            return Ok(await _itemModel.RecordItemById(id));
        }

        /// <summary>
        /// This method gets a item that have filter(name)
        /// </summary>
        /// <param name="itemName">filter to search for the item</param>
        /// <returns>200 if exist item whit filter</returns>
        // GET api/<ItemController>/Pera
        [HttpGet("getItemByName/{itemName}")]
        public async Task<IActionResult> GetItemByName(string itemName)
        {
            return Ok(await _itemModel.RecordItemByName(itemName));
        }
    }
}
