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
using Projeto_Vendas_Lib.Domain.Enum;

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

        /// <summary>
        /// Verifica todas as vendas realizadas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Venda>> Get()
        {
            return _serviceVenda.GetVendaCompleta().Result;
        }

        /// <summary>
        /// Get Venda By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(_serviceVenda.GetVendaCompletaById(id).Result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Venda venda)
        {
            if (!venda.Itens.Count.Equals(0))
            {
                venda.Id = Guid.NewGuid();
                venda.StatusVenda = 0;
                venda.DataVenda = DateTime.Now;

                _serviceVenda.Add(venda);
                return Ok();
            }

            return Ok("A Venda precisa de ao menos um item para ser efetuada");
        }

        [HttpPut]
        [Route("UpdateStatus")]
        public async Task<IActionResult> AtualizaStatusVenda(Guid id, StatusVenda status)
        {

            Venda venda = _serviceVenda.GetById(id);

            if (ValidaStatus(venda, status))
            {
                venda.StatusVenda = status;

                _serviceVenda.Update(venda);
                return Ok();
            }
            return Ok("O Status não pode ser alterado, confira as regras de alteração");
        }

        private bool ValidaStatus(Venda venda, StatusVenda status)
        {
            if (venda.StatusVenda.Equals(StatusVenda.Aguardando_Pagamento) && (status.Equals(StatusVenda.Pagamento_Aprovado) || status.Equals(StatusVenda.Cancelada)))
            {
                return true;
            }
            if (venda.StatusVenda.Equals(StatusVenda.Pagamento_Aprovado) && (status.Equals(StatusVenda.Enviado_para_Transportadora) || status.Equals(StatusVenda.Cancelada)))
            {
                return true;
            }
            if (venda.StatusVenda.Equals(StatusVenda.Enviado_para_Transportadora) && status.Equals(StatusVenda.Entregue))
            {
                return true;
            }
            return false;

        }
    }
}
