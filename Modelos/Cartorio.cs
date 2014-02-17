using System;

namespace Modelos
{
    public class Cartorio
    {
        private int idCartorio;

        public int IdCartorio
        {
            get { return idCartorio; }
            set { idCartorio = value; }
        }
        private string nmCartorio;

        public string NmCartorio
        {
            get { return nmCartorio; }
            set { nmCartorio = value; }
        }
        private string dsObservacao;

        public string DsObservacao
        {
            get { return dsObservacao; }
            set { dsObservacao = value; }
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
        private string dsCidade;

        public string DsCidade
        {
            get { return dsCidade; }
            set { dsCidade = value; }
        }
        private string sgUF;

        public string SgUF
        {
            get { return sgUF; }
            set { sgUF = value; }
        }
        private string nrFones;

        public string NrFones
        {
            get { return nrFones; }
            set { nrFones = value; }
        }
        private string nrFax;

        public string NrFax
        {
            get { return nrFax; }
            set { nrFax = value; }
        }
        private string dsEmail;

        public string DsEmail
        {
            get { return dsEmail; }
            set { dsEmail = value; }
        }
        private DateTime dtCadastro;

        public DateTime DtCadastro
        {
            get { return dtCadastro; }
            set { dtCadastro = value; }
        }
        private string nrCEP;

        public string NrCEP
        {
            get { return nrCEP; }
            set { nrCEP = value; }
        }
        private string nrCNPJ;

        public string NrCNPJ
        {
            get { return nrCNPJ; }
            set { nrCNPJ = value; }
        }
    }
}
