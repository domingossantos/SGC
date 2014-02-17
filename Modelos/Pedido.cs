using System;
using System.Text;
using System.Collections;

namespace Modelos
{
    public class Pedido
    {
        int nrPedido;

        public int NrPedido
        {
            get { return nrPedido; }
            set { nrPedido = value; }
        }
        DateTime dtPedido;

        public DateTime DtPedido
        {
            get { return dtPedido; }
            set { dtPedido = value; }
        }
        String dsLogin;

        public String DsLogin
        {
            get { return dsLogin; }
            set { dsLogin = value; }
        }
        char stPedido;

        public char StPedido
        {
            get { return stPedido; }
            set { stPedido = value; }
        }

        private double vlPedido;

        public double VlPedido
        {
            get { return vlPedido; }
            set { vlPedido = value; }
        }
    }
}
