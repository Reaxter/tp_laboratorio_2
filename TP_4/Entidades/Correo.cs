using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if (item.IsAlive)
                    item.Abort();
            }
            this.mockPaquetes.Clear();
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete item in ((Correo)elementos).Paquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2})", item.TrackingID, item.DireccionEntrega, item.Estado.ToString()));
            }
            return sb.ToString();
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                {
                    throw new TrackingIdRepetidoException(string.Format("El ID {0} ya existe",p.TrackingID));
                }
            }
            try
            {
                c.paquetes.Add(p);
                Thread hilo = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(hilo);
                hilo.Start();
            }
            catch (Exception e)
            {
                throw e;
            }
            return c;
        }
    }
}