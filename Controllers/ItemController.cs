using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemLibraryProject;
using ItemRestServiceUsingDatabaseAzure.Presistency;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FilterItem = Microsoft.AspNetCore.Mvc.Filters.FilterItem;

namespace ItemRestServiceUsingDatabaseAzure.Controllers
{
   
    // GET: api/Item
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private PresistencyServices _pService;

       //Get All method
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            _pService=new PresistencyServices();
            return _pService.Get();
            

        }

        // GET: api/Item/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet]
        [Route("{id}")]
        public Item Get(int id)
        {
            //return ItemList.Find(i => i.Id == id);

            _pService = new PresistencyServices();
            return _pService.Get(id);

        }

        // POST: api/Item
        [HttpPost]
        public void Post([FromBody] Item value)
        {
           _pService = new PresistencyServices();
           _pService.Get().Concat(new[] {value});
        }

        //// PUT: api/Item/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] Item value)
        //{
        //    Item item = Get(id);
        //    if (item != null)
        //    {
        //        item.Id = value.Id;
        //        item.Name = value.Name;
        //        item.Quality = value.Quality;
        //        item.Quantity = value.Quantity;
        //    }

        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    Item item = Get(id);
        //    ItemList.Remove(item);
        //}
        ////TO find the substring by name
        //[HttpGet]
        //[Route("Name/{substring}")]
        //public IEnumerable<Item> GetFromSubstring(string substring)
        //{
        //    return ItemList.FindAll(i => i.Name.Contains(substring));
        //}
        ////To find the data from quality
        //[HttpGet]
        //[Route("Quality/{quality}")]
        //public IEnumerable<Item> GetQuality(string quality)
        //{
        //    return ItemList.FindAll(i => i.Quality.Contains(quality));
        //}

        //public ActionResult<IEnumerable<string>> GetWithQuery([FromQuery] int request)
        //{
        //    return new string[] { "value1 :" + request, "value2" };
        //}
        //[HttpGet]
        //[Route("GetItemIndex/")]
        //public Item GetItem([FromQuery] int index)
        //{
        //    return ItemList[index];
        //}

        //[HttpGet]
        //[Route("Search/LowQuantity")]
        //public Item SearchLow([FromQuery] double number)
        //{
        //    return ItemList.Find(i => i.Quantity < number);
        //}
        ////Search with object parameter
        //[HttpGet]
        //[Route("Search/")]
        //public Item Search([FromQuery] FilterItem filter)
        //{
        //    return ItemList.Find(i => i.Quantity < filter.LowQuantity);

        //}

        //[HttpGet]
        //[Route("SearchAll/")]
        //public IEnumerable<Item> SearchAll([FromQuery] FilterItem filter)
        //{
        //    //return ItemList.Find(i => i.Quantity < filter.LowQuantity);
        //    return ItemList.FindAll(
        //        delegate (Item item)
        //        {
        //            return item.Quantity < filter.LowQuantity;
        //        });

        //}
    }
}
