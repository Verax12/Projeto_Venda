using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_Vendas_Lib.Domain;
using Projeto_Vendas_Lib.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projeto_Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IServiceItem _serviceItem;

        public ItemController(IServiceItem serviceItem)
        {
            _serviceItem = serviceItem;
        }

        // GET: api/<ItemController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_serviceItem.GetAll());
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(_serviceItem.GetById(id));
        }

        // POST api/<ItemController>
        [HttpPost]
        public void Post(Item item)
        {
            _serviceItem.Add(item);
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(Item item)
        {
            _serviceItem.Update(item);
        }

    }
}
