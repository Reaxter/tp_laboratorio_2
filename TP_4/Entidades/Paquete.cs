using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public enum EEstado
    {
        Ingresado, EnViaje, Entregado
    }

    public delegate void DelegadoEstado(object sender, EventArgs e);

    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        public void MockCicloDeVida()
        {
            while(this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(10000);
                this.Estado++;
                this.InformarEstado(this, new EventArgs());
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID ? true : false;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }

        public override string ToString()
        {
            return ((IMostrar<Paquete>)this).MostrarDatos(this);
        }

        public event DelegadoEstado InformarEstado;
    }
}