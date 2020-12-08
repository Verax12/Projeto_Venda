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
    public class ClienteController : ControllerBase
    {

        private readonly IServiceCliente _serviceCliente;

        public ClienteController(IServiceCliente serviceCliente)
        {
            _serviceCliente = serviceCliente;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_serviceCliente.GetAll());
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(_serviceCliente.GetById(id));
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post(Cliente cliente)
        {
            _serviceCliente.Add(cliente);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(Cliente cliente)
        {

            _serviceCliente.Update(cliente);
        }

    }
}
