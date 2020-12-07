using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Vendas_Lib.Domain;
using Projeto_Vendas_Lib.Infra.Context;
using Projeto_Vendas_Lib.Service;
using Projeto_Vendas_Lib.Service.IServices;

namespace Projeto_Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IServiceCliente _serviceCliente;

        public VendasController(IServiceCliente serviceCliente)
        {
            _serviceCliente = serviceCliente;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_serviceCliente.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Cliente cliente)
        {
            _serviceCliente.Add(cliente);

            return Ok();
        }
    }
}
