using System;
using System.Text;

namespace Modelos
{
    public class MovimentoDeposito
    {
        private int idMovimentoBanco;

        public int IdMovimentoBanco
        {
            get { return idMovimentoBanco; }
            set { idMovimentoBanco = value; }
        }
        private int idEscritura;

        public int IdEscritura
        {
            get { return idEscritura; }
            set { idEscritura = value; }
        }
        private int cdAto;

        public int CdAto
        {
            get { return cdAto; }
            set { cdAto = value; }
        }

        
        private char tpMovimento; // D - Debito C - Crédito

        public char TpMovimento
        {
            get { return tpMovimento; }
            set { tpMovimento = value; }
        }
        private string dsMovimento;

        public string DsMovimento
        {
            get { return dsMovimento; }
            set { dsMovimento = value; }
        }
        private DateTime dtMovimento;

        public DateTime DtMovimento
        {
            get { return dtMovimento; }
            set { dtMovimento = value; }
        }
        private string dsLogin;

        public string DsLogin
        {
            get { return dsLogin; }
            set { dsLogin = value; }
        }
        private char stRegistro;

        public char StRegistro
        {
            get { return stRegistro; }
            set { stRegistro = value; }
        }

        private double vlMovimento;

        public double VlMovimento
        {
            get { return vlMovimento; }
            set { vlMovimento = value; }
        }
    }
}
