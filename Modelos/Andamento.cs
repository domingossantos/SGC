using System;
using System.Text;

namespace Modelos
{
    public class Andamento
    {
        private int idAndamento;

        public int IdAndamento
        {
            get { return idAndamento; }
            set { idAndamento = value; }
        }
        private int idEscritura;

        public int IdEscritura
        {
            get { return idEscritura; }
            set { idEscritura = value; }
        }
        private string dsAndamento;

        public string DsAndamento
        {
            get { return dsAndamento; }
            set { dsAndamento = value; }
        }
        private DateTime dtAndamento;

        public DateTime DtAndamento
        {
            get { return dtAndamento; }
            set { dtAndamento = value; }
        }
        private double vlAndamento;

        public double VlAndamento
        {
            get { return vlAndamento; }
            set { vlAndamento = value; }
        }
        private char stRegistro;

        public char StRegistro
        {
            get { return stRegistro; }
            set { stRegistro = value; }
        }
        private string dsLogin;

        public string DsLogin
        {
            get { return dsLogin; }
            set { dsLogin = value; }
        }
    }
}
