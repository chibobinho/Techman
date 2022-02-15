using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using System;
using System.IO;
using System.Text;
using Xunit;

namespace Patrimonio.Test.Controllers
{
    public class EquipamentosControllerTest
    {
        [Fact]
        public void Deve_cadastrar_um_equipamento()
        {
            //  Pré-Condição
            var fakeRepository = new Mock<IEquipamentoRepository>();
            fakeRepository
                .Setup(x => x.Cadastrar(It.IsAny<Equipamento>()));

            var equipamentoFake = new Equipamento()
            {
                Ativo = true,
                NomePatrimonio = "patrimonioTeste",
                DataCadastro = DateTime.Now,
                Descricao = "Este é um teste",
            };

            var controller = new EquipamentosController(fakeRepository.Object);

            //  Procedimento
            var bytes = Encoding.UTF8.GetBytes("Esse é um arquivo de teste.");
            IFormFile arquivo = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "teste.png");

            var resultado = controller.PostEquipamento(equipamentoFake, arquivo);

            //  Reusultado esperado
            Assert.IsType<CreatedResult>(resultado);

        }
    }
}
