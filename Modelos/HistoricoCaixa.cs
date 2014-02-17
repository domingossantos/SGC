using System;
using System.Text;

namespace Modelos
{
    public class HistoricoCaixa
    {
        private int idHistoricocaixa;

        public int IdHistoricocaixa
        {
            get { return idHistoricocaixa; }
            set { idHistoricocaixa = value; }
        }

        private String dsLogin;

        public String DsLogin
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
        private DateTime dtAbertura;

        public DateTime DtAbertura
        {
            get { return dtAbertura; }
            set { dtAbertura = value; }
        }
        private DateTime dtFechamento;

        public DateTime DtFechamento
        {
            get { return dtFechamento; }
            set { dtFechamento = value; }
        }

    }
}
