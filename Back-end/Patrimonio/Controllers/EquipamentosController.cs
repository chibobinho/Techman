using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Patrimonio.Contexts;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.Repositories;
using Patrimonio.Utils;

namespace Patrimonio.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {
        private readonly IEquipamentoRepository _equipamentoRepository;

        public EquipamentosController(IEquipamentoRepository context)
        {
            _equipamentoRepository = context;
        }

        // GET: api/Equipamentos
        [HttpGet]
        public IActionResult GetEquipamentos()
        {
            return Ok(_equipamentoRepository.Listar());
        }

        // GET: api/Equipamentos/5
        [HttpGet("{id}")]
        public IActionResult GetEquipamento(int id)
        {
            Equipamento equipamento = _equipamentoRepository.BuscarPorID(id);

            if (equipamento == null)
            {
                return NotFound();
            }

            return Ok(equipamento);
        }

        // PUT: api/Equipamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutEquipamento(int id, Equipamento equipamento)
        {
            if (equipamento.Descricao == null || equipamento.Imagem == null || equipamento.NomePatrimonio == null || id != equipamento.Id)
            {
                return BadRequest();
            }

            try
            {
                _equipamentoRepository.Alterar(equipamento);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "A consulta indicada não foi encontrada.",
                    error
                });
            }
        }

        // POST: api/Equipamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostEquipamento([FromForm] Equipamento equipamento, IFormFile arquivo)
        {

            
            #region Upload da Imagem com extensões permitidas apenas
                string[] extensoesPermitidas = { "jpg", "png", "jpeg", "gif" };
                string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas);

                if (uploadResultado == "")
                {
                    return BadRequest("Arquivo não encontrado");
                }

                if (uploadResultado == "Extensão não permitida")
                {
                    return BadRequest("Extensão de arquivo não permitida");
                }

                equipamento.Imagem = uploadResultado; 
            #endregion

            // Pegando o horário do sistema
            equipamento.DataCadastro = DateTime.Now;

            _equipamentoRepository.Cadastrar(equipamento);
            return Created("Equipamento", equipamento);
        }

        // DELETE: api/Equipamentos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEquipamento(int id)
        {

            Equipamento equipamentoBuscado = _equipamentoRepository.BuscarPorID(id);

            if (equipamentoBuscado != null)
            {
                _equipamentoRepository.Excluir(equipamentoBuscado);
                return Ok();
            }

            return BadRequest();
        }

        //private bool EquipamentoExists(int id)
        //{
        //    return _context.Equipamentos.Any(e => e.Id == id);
        //}
    }
}
