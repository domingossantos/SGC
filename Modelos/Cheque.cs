using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos
{
    public class Cheque
    {
        private int idCheque;

        public int IdCheque
        {
            get { return idCheque; }
            set { idCheque = value; }
        }

        private int nrPedido;

        public int NrPedido
        {
            get { return nrPedido; }
            set { nrPedido = value; }
        }

        private int nrCheque;

        public int NrCheque
        {
            get { return nrCheque; }
            set { nrCheque = value; }
        }
        private int nrBanco;

        public int NrBanco
        {
            get { return nrBanco; }
            set { nrBanco = value; }
        }
        private int nrAgencia;

        public int NrAgencia
        {
            get { return nrAgencia; }
            set { nrAgencia = value; }
        }
        private string nrConta;

        public string NrConta
        {
            get { return nrConta; }
            set { nrConta = value; }
        }
        private string nrRG;

        public string NrRG
        {
            get { return nrRG; }
            set { nrRG = value; }
        }
        private DateTime dtCheque;

        public DateTime DtCheque
        {
            get { return dtCheque; }
            set { dtCheque = value; }
        }
        private DateTime dt1Devolucao;

        public DateTime Dt1Devolucao
        {
            get { return dt1Devolucao; }
            set { dt1Devolucao = value; }
        }
        private DateTime dt2Devolucao;

        public DateTime Dt2Devolucao
        {
            get { return dt2Devolucao; }
            set { dt2Devolucao = value; }
        }
        private DateTime dtConpensacao;


        public DateTime DtConpensacao
        {
            get { return dtConpensacao; }
            set { dtConpensacao = value; }
        }
        private char stCheque;


        public char StCheque
        {
            get { return stCheque; }
            set { stCheque = value; }
        }

        private char stDeposito;

        public char StDeposito
        {
            get { return stDeposito; }
            set { stDeposito = value; }
        }
    }
}
