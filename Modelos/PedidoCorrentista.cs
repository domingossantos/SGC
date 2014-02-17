using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos
{
    public class PedidoCorrentista
    {
        private int idPedidoCorrentista;

        public int IdPedidoCorrentista
        {
            get { return idPedidoCorrentista; }
            set { idPedidoCorrentista = value; }
        }
        private DateTime dtPedido;

        public DateTime DtPedido
        {
            get { return dtPedido; }
            set { dtPedido = value; }
        }
        private int nrPedido;

        public int NrPedido
        {
            get { return nrPedido; }
            set { nrPedido = value; }
        }
        private string nrCPFCNPJ;

        public string NrCPFCNPJ
        {
            get { return nrCPFCNPJ; }
            set { nrCPFCNPJ = value; }
        }
        private double vlPedido;

        public double VlPedido
        {
            get { return vlPedido; }
            set { vlPedido = value; }
        }
        private char stPedido;

        public char StPedido
        {
            get { return stPedido; }
            set { stPedido = value; }
        }
        private string dsAutorizacao;

        public string DsAutorizacao
        {
            get { return dsAutorizacao; }
            set { dsAutorizacao = value; }
        }
    }
}
