using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Owner.API.DataOperations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Owner.API.Controllers
{
    [Route("api/[controller]")]
    public class OwnerController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IList<Models.Owner> Get()
        {
            return DataGenerator.OwnerList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item= DataGenerator.OwnerList.FirstOrDefault(c=> c.Id==id);
            if (item == null)
                return BadRequest("Owner bulunamadı");
            return Ok(item);
        }

        // POST api/values
        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Post([FromBody] Models.Owner value)
        {
            if (value.Content.IndexOf("hack", StringComparison.CurrentCultureIgnoreCase) >= 0)
                return BadRequest("Geçersiz açıklama");

            DataGenerator.OwnerList.Add(value);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Models.Owner value)
        {
            var item = DataGenerator.OwnerList.FirstOrDefault(c => c.Id == id);
            if (item == null)
                return BadRequest("Güncellenecek Owner bulunamadı");

            item.Id = value.Id;
            item.Name = value.Name;
            item.Surname = value.Surname;
            item.Type = value.Type;
            item.Date = value.Date;
            item.Content = value.Content;
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = DataGenerator.OwnerList.FirstOrDefault(c => c.Id == id);
            if (item == null)
                return BadRequest("Silinecek Owner bulunamadı");

            DataGenerator.OwnerList.Remove(item);
            return Ok();

        }
    }
}

