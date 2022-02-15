using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.ViewModels;
using System;
using Xunit;

namespace Patrimonio.Test.Controllers
{
    public class LoginControllerTest
    {
        [Fact]
        public void Deve_retornar_um_usuario_invalido()
        {
            //  Pré-Condição
            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario) null);

            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = "tsuka@email.com";
            loginViewModel.Senha = "123456789";

            var controller = new LoginController(fakeRepository.Object);

            //  Procedimento
            var resultado = controller.Login(loginViewModel);

            //  Resultado esperado
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]
        public void Deve_retornar_um_usuario_valido()
        {
            //  Pré-Condição
            var usuarioFake = new Usuario();
            usuarioFake.Email = "paulo@email.com";
            usuarioFake.Senha = "123456789";

            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository
                .Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuarioFake);

            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.Email = "paulo@email.com";
            loginViewModel.Senha = "123456789";

            var controller = new LoginController(fakeRepository.Object);

            //  Procedimento
            var resultado = controller.Login(loginViewModel);

            //  Resultado esperado
            Assert.IsType<OkObjectResult>(resultado);
        }

        private void Returns(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
