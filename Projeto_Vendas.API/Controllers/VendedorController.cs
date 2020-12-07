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
    public class VendedorController : ControllerBase
    {
        private readonly IServiceVendedor _serviceVendedor;

        public VendedorController(IServiceVendedor serviceVendedor)
        {
            _serviceVendedor = serviceVendedor;
        }

        // GET: api/<VendedorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_serviceVendedor.GetAll());
        }

        // GET api/<VendedorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(_serviceVendedor.GetById(id));
        }

        // POST api/<VendedorController>
        [HttpPost]
        public void Post(Vendedor vendedor)
        {
            _serviceVendedor.Add(vendedor);
        }

        // PUT api/<VendedorController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, Vendedor vendedor)
        {
            _serviceVendedor.Update(vendedor);
        }

    }
}
