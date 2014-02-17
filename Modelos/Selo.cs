using System;
using System.Text;

namespace Modelos
{
    public class Selo
    {
        private int nrSelo;

        public int NrSelo
        {
            get { return nrSelo; }
            set { nrSelo = value; }
        }

        private int cdTipoSelo;

        public int CdTipoSelo
        {
            get { return cdTipoSelo; }
            set { cdTipoSelo = value; }
        }

        private DateTime dtLancamento;

        public DateTime DtLancamento
        {
            get { return dtLancamento; }
            set { dtLancamento = value; }
        }

        private Char stSelo;

        public Char StSelo
        {
            get { return stSelo; }
            set { stSelo = value; }
        }

        private String dsLogin;

        public String DsLogin
        {
            get { return dsLogin; }
            set { dsLogin = value; }
        }

        private DateTime dtAtribuicao;

        public DateTime DtAtribuicao
        {
            get { return dtAtribuicao; }
            set { dtAtribuicao = value; }
        }
    }
}
