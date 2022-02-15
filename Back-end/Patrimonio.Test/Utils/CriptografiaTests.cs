using Patrimonio.Utils;
using System.Text.RegularExpressions;
using Xunit;

namespace Patrimonio.Test.Utils
{
    public class CriptografiaTests
    {
        [Fact]
        public void Deve_retornar_hash_em_BCrypt()
        {
            //  Pré-Condição
            var senha = Criptografia.GerarHash("123456789");
            var regex = new Regex(@"^\$2[ayb]\$.{56}$");

            //  Procedimento
            var retorno = regex.IsMatch(senha);

            //  Resultado esperado
            Assert.True(retorno);
        }

        [Fact]
        public void Deve_retornar_comparacao_valida()
        {
            //  Pré-Condição
            var senha = "123456789";
            var hash = "$2a$11$zDm/qxW90va1VJfp7UTJa.hzDSNoICFUU.02XoefZ1JbIEO0a8Nae";

            //  Procedimento
            var comparacao = Criptografia.Comparar(senha, hash);

            //  Resultado esperado
            Assert.True(comparacao);


        }
    }
}
