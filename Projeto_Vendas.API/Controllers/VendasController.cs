using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projeto_Vendas_Lib.Domain;
using Projeto_Vendas_Lib.Infra.Context;
using Projeto_Vendas_Lib.Service;
using Projeto_Vendas_Lib.Service.IServices;
using System.Text.Json;

namespace Projeto_Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IServiceVenda _serviceVenda;

        public VendasController(IServiceVenda serviceVenda)
        {
            _serviceVenda = serviceVenda;
        }

        [HttpGet]
        public async Task<List<Venda>> Get()
        {
            return _serviceVenda.GetVendaCompleta().Result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(_serviceVenda.GetVendaCompletaById(id).Result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Venda venda)
        {
            venda.Id = Guid.NewGuid();

            _serviceVenda.Add(venda);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Venda venda)
        {
            _serviceVenda.Update(venda);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> AtualizaStatusVenda(Venda venda)
        {
            _serviceVenda.Update(venda);
            return Ok();
        }
    }
}
