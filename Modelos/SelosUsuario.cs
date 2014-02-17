using System;
using System.Text;

namespace Modelos
{
    public class SelosUsuario
    {
        private String dsLogin;

        public String DsLogin
        {
            get { return dsLogin; }
            set { dsLogin = value; }
        }

        private int nrInicioSeq;

        public int NrInicioSeq
        {
            get { return nrInicioSeq; }
            set { nrInicioSeq = value; }
        }
        private int nrFimSeq;

        public int NrFimSeq
        {
            get { return nrFimSeq; }
            set { nrFimSeq = value; }
        }
        private int cdTipoSelo;

        public int CdTipoSelo
        {
            get { return cdTipoSelo; }
            set { cdTipoSelo = value; }
        }
        private DateTime dtAtribuicao;

        public DateTime DtAtribuicao
        {
            get { return dtAtribuicao; }
            set { dtAtribuicao = value; }
        }
        private char stSeloUsuario;

        public char StSeloUsuario
        {
            get { return stSeloUsuario; }
            set { stSeloUsuario = value; }
        }
    }
}
