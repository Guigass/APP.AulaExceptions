using APP.Excecao02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UTP.Qualidade
{
    [TestClass]
    public class UnitTestExceptions
    {
        [TestMethod]
        public void TestMethod_CalcularOperacaoNaoSuportada()
        {
            var programa = new Calculadora();

            Assert.ThrowsException<CalcularOperacaoNaoSuportadaException>(
                () => programa.Executar(10, 20, "*"));

            //Assert.ThrowsException<CalcularException>(
            //    () => programa.Executar(10, 20, "*"));

            var error = Assert.ThrowsException<CalcularOperacaoNaoSuportadaException>(
                () => programa.Executar(10, 20, "*"));

            Assert.AreEqual(error.Operador, "*");
        }
    }
}
