using System;
using System.Text;

namespace Modelos
{
    public class MovimentoCaixa
    {
        private int idMovimentoCaixa;

        public int IdMovimentoCaixa
        {
            get { return idMovimentoCaixa; }
            set { idMovimentoCaixa = value; }
        }
        private int idHitoricoCaixa;

        public int IdHitoricoCaixa
        {
            get { return idHitoricoCaixa; }
            set { idHitoricoCaixa = value; }
        }
        private string dsLogin;

        public string DsLogin
        {
            get { return dsLogin; }
            set { dsLogin = value; }
        }
        private int nrCaixa;

        public int NrCaixa
        {
            get { return nrCaixa; }
            set { nrCaixa = value; }
        }
        private int idTipoMovimento;

        public int IdTipoMovimento
        {
            get { return idTipoMovimento; }
            set { idTipoMovimento = value; }
        }
        private char tpOperacao;

        public char TpOperacao
        {
            get { return tpOperacao; }
            set { tpOperacao = value; }
        }
        private double vlMovimento;

        public double VlMovimento
        {
            get { return vlMovimento; }
            set { vlMovimento = value; }
        }

        private DateTime dtMovimento;

        public DateTime DtMovimento
        {
            get { return dtMovimento; }
            set { dtMovimento = value; }
        }

        private int tpPagamento;

        public int TpPagamento
        {
            get { return tpPagamento; }
            set { tpPagamento = value; }
        }

        private Int32 nrPedido;

        public Int32 NrPedido
        {
            get { return nrPedido; }
            set { nrPedido = value; }
        }

        private double vlDesconto;

        public double VlDesconto
        {
            get { return vlDesconto; }
            set { vlDesconto = value; }
        }
        private string dsLoginAutDesconto;

        public string DsLoginAutDesconto
        {
            get { return dsLoginAutDesconto; }
            set { dsLoginAutDesconto = value; }
        }

        private string dsObservacao;

        public string DsObservacao
        {
            get { return dsObservacao; }
            set { dsObservacao = value; }
        }

        private int nrPedidoPagto;

        public int NrPedidoPagto {
            get { return nrPedidoPagto;  }
            set { nrPedidoPagto = value; }
        }

        private double vlDinheiro;

        public double VlDinheiro {
            get { return vlDinheiro; }
            set { vlDinheiro = value;  }

        }

        private String nmRecibo;

        public String NmRecibo {
            get { return nmRecibo; }
            set { nmRecibo = value;  }
        }
    }
}
