using System;
using System.Text;

namespace Modelos
{
    public class Pessoa
    {
        private String nrCpfCnpj;

        public String NrCpfCnpj
        {
            get { return nrCpfCnpj; }
            set { nrCpfCnpj = value; }
        }
        private char tpPessoa;

        public char TpPessoa
        {
            get { return tpPessoa; }
            set { tpPessoa = value; }
        }
        private String nmPessoa;

        public String NmPessoa
        {
            get { return nmPessoa; }
            set { nmPessoa = value; }
        }

        private int idCidade;

        public int IdCidade
        {
            get { return idCidade; }
            set { idCidade = value; }
        }


        private String dsEndereco;

        public String DsEndereco
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

        private String nrFones;

        public String NrFones
        {
            get { return nrFones; }
            set { nrFones = value; }
        }
        private String dsEmail;

        public String DsEmail
        {
            get { return dsEmail; }
            set { dsEmail = value; }
        }

        private string nrRg;

        public string NrRg
        {
            get { return nrRg; }
            set { nrRg = value; }
        }
        private string dsOrgaoEmissor;

        public string DsOrgaoEmissor
        {
            get { return dsOrgaoEmissor; }
            set { dsOrgaoEmissor = value; }
        }

        private String dtRgExpedicao;

        public String DtRgExpedicao
        {
            get { return dtRgExpedicao; }
            set { dtRgExpedicao = value; }
        }


        private string nmPai;

        public string NmPai
        {
            get { return nmPai; }
            set { nmPai = value; }
        }
        private string nmMae;

        public string NmMae
        {
            get { return nmMae; }
            set { nmMae = value; }
        }
        private string dtNascimento;

        public string DtNascimento
        {
            get { return dtNascimento; }
            set { dtNascimento = value; }
        }
        private string dsCidade;

        public string DsCidade
        {
            get { return dsCidade; }
            set { dsCidade = value; }
        }
        private string dsUf;

        public string DsUf
        {
            get { return dsUf; }
            set { dsUf = value; }
        }

        private string tpDocumento;

        public string TpDocumento
        {
            get { return tpDocumento; }
            set { tpDocumento = value; }
        }


        private string nrDocumento;

        public string NrDocumento
        {
            get { return nrDocumento; }
            set { nrDocumento = value; }
        }

        private string dsUfDocumento;

        public string DsUfDocumento
        {
            get { return dsUfDocumento; }
            set { dsUfDocumento = value; }
        }

        private String dtExpedicaoDocumento;

        public String DtExpedicaoDocumento
        {
            get { return dtExpedicaoDocumento; }
            set { dtExpedicaoDocumento = value; }
        }

        private String dsUfNascimento;

        public String DsUfNascimento
        {
            get { return dsUfNascimento; }
            set { dsUfNascimento = value; }
        }

        private String dsPaisNascimento;

        public String DsPaisNascimento
        {
            get { return dsPaisNascimento; }
            set { dsPaisNascimento = value; }
        }

        private char dsSexo;

        public char DsSexo
        {
            get { return dsSexo; }
            set { dsSexo = value; }
        }

    }
}
