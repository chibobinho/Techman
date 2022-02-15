using Patrimonio.Domains;
using Xunit;

namespace Patrimonio.Test.Domains
{
    public class UsuarioDomainTests
    {
        [Fact] //Descrição do teste
        public void Deve_retornar_usuario_preenchido() 
        {
            // Sempre seguir a ordem abaixo


            //  Pré-Condição / Arrange
            Usuario usuario = new Usuario();
            usuario.Email = "paulo@email.com";
            usuario.Senha = "123456457";

            //  Procedimento / Act
            bool resultado = true;

            if (usuario.Senha == null || usuario.Email == null)
            {
                resultado = false;
            }

            // Resultado esperado / Assert
            Assert.True(resultado);
        }
    }
}
