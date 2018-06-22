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
    public class TestPaqueteRepetido
    {
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PaqueteRepetido()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("pTest1", "111-111-1112");
            c += p1;
            Paquete p2 = new Paquete("pTest2", "111-111-1112");
            c += p2;
        }
    }
}
