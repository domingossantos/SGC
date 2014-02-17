using System;
using System.Text;

namespace Modelos
{
    public class Correntista
    {
        private string nrCPFCPNJ;

        public string NrCPFCPNJ
        {
            get { return nrCPFCPNJ; }
            set { nrCPFCPNJ = value; }
        }

        private string nmCorrentista;

        public string NmCorrentista
        {
            get { return nmCorrentista; }
            set { nmCorrentista = value; }
        }

        private string dsEndereco;

        public string DsEndereco
        {
            get { return dsEndereco; }
            set { dsEndereco = value; }
        }

        private string dsBairro;

        public string DsBairro
        {
            get { return dsBairro; }
            set { dsBairro = value; }
        }

        private string nrCEP;

        public string NrCEP
        {
            get { return nrCEP; }
            set { nrCEP = value; }
        }

        private string dsCidade;

        public string DsCidade
        {
            get { return dsCidade; }
            set { dsCidade = value; }
        }

        private string dsEmail;

        public string DsEmail
        {
            get { return dsEmail; }
            set { dsEmail = value; }
        }
        private string nrFone;

        public string NrFone
        {
            get { return nrFone; }
            set { nrFone = value; }
        }
        private DateTime dtInclusao;

        public DateTime DtInclusao
        {
            get { return dtInclusao; }
            set { dtInclusao = value; }
        }

        private char stCorrentista;

        public char StCorrentista
        {
            get { return stCorrentista; }
            set { stCorrentista = value; }
        }

        private String sgUF;

        public String SgUF
        {
            get { return sgUF; }
            set { sgUF = value; }
        }
    }

}
