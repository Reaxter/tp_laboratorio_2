using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test_Unitarios
{
    [TestClass]
    public class TestListaInstanciada
    {
        [TestMethod]
        public void ListaInstanciada()
        {
            Correo c = new Correo();
            Paquete p = new Paquete("pTest1", "111-111-1111");
            try
            {
                c.Paquetes.Add(p);
            }
            catch (NullReferenceException e)
            {
                Assert.Fail();
            }
        }
        
    }
}