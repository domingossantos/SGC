using System;
using System.Text;

namespace Modelos
{
    public class Processo
    {
        String nrProceso;

        public String NrProceso
        {
            get { return nrProceso; }
            set { nrProceso = value; }
        }
        DateTime dtInclusao;

        public DateTime DtInclusao
        {
            get { return dtInclusao; }
            set { dtInclusao = value; }
        }
        DateTime dtEmissao;

        public DateTime DtEmissao
        {
            get { return dtEmissao; }
            set { dtEmissao = value; }
        }
        

        String nrLivro;

        public String NrLivro
        {
            get { return nrLivro; }
            set { nrLivro = value; }
        }

        string nrFolha;

        public string NrFolha
        {
            get { return nrFolha; }
            set { nrFolha = value; }
        }
        String dsPathArquivo;

        public String DsPathArquivo
        {
            get { return dsPathArquivo; }
            set { dsPathArquivo = value; }
        }
        int nrSelo;

        public int NrSelo
        {
            get { return nrSelo; }
            set { nrSelo = value; }
        }
        int cdTipoSelo;

        public int CdTipoSelo
        {
            get { return cdTipoSelo; }
            set { cdTipoSelo = value; }
        }
        int cdAto;

        public int CdAto
        {
            get { return cdAto; }
            set { cdAto = value; }
        }
        int cdTipoDocumento;

        public int CdTipoDocumento
        {
            get { return cdTipoDocumento; }
            set { cdTipoDocumento = value; }
        }

        private string dsObservacao;

        public string DsObservacao
        {
            get { return dsObservacao; }
            set { dsObservacao = value; }
        }

        private char stProcesso;

        public char StProcesso
        {
            get { return stProcesso; }
            set { stProcesso = value; }
        }

        private int idEscritura;

        public int IdEscritura
        {
            get { return idEscritura; }
            set { idEscritura = value; }
        }

        private string idProvimento;

        public string IdProvimento
        {
            get { return idProvimento; }
            set { idProvimento = value; }
        }
        private int idClasseProvimento;

        public int IdClasseProvimento
        {
            get { return idClasseProvimento; }
            set { idClasseProvimento = value; }
        }
        private int idSubClasseProvimento;

        public int IdSubClasseProvimento
        {
            get { return idSubClasseProvimento; }
            set { idSubClasseProvimento = value; }
        }

        private String dsLogin;

        public String DsLogin
        {
            get { return dsLogin; }
            set { dsLogin = value; }
        }

        private String nrLivroComp;

        public String NrLivroComp
        {
            get { return nrLivroComp; }
            set { nrLivroComp = value; }
        }

        private String nrFolhaComp;

        public String NrFolhaComp
        {
            get { return nrFolhaComp; }
            set { nrFolhaComp = value; }
        }

        private String dsDesconhecido;

        public String DsDesconhecido
        {
            get { return dsDesconhecido; }
            set { dsDesconhecido = value; }
        }

        private String dsRefLivro;

        public String DsRefLivro
        {
            get { return dsRefLivro; }
            set { dsRefLivro = value; }
        }

        private String dsRefLivroComp;

        public String DsRefLivroComp
        {
            get { return dsRefLivroComp; }
            set { dsRefLivroComp = value; }
        }


        private String dsRefFolha;

        public String DsRefFolha
        {
            get { return dsRefFolha; }
            set { dsRefFolha = value; }
        }


        private String dsRefFolhaComp;

        public String DsRefFolhaComp
        {
            get { return dsRefFolhaComp; }
            set { dsRefFolhaComp = value; }
        }


        private String dsRefUfOrigem;

        public String DsRefUfOrigem
        {
            get { return dsRefUfOrigem; }
            set { dsRefUfOrigem = value; }
        }


        private String dsRefCartorio;

        public String DsRefCartorio
        {
            get { return dsRefCartorio; }
            set { dsRefCartorio = value; }
        }

        private String dsRefCidade;

        public String DsRefCidade
        {
            get { return dsRefCidade; }
            set { dsRefCidade = value; }
        }

        private Double vlDocumento;

        public Double VlDocumento
        {
            get { return vlDocumento; }
            set { vlDocumento = value; }
        }
        private DateTime dtCasamento;

        public DateTime DtCasamento
        {
            get { return dtCasamento; }
            set { dtCasamento = value; }
        }

        private String dsRegimeBens;

        public String DsRegimeBens
        {
            get { return dsRegimeBens; }
            set { dsRegimeBens = value; }
        }

        private String nrFilhosMaiores;

        public String NrFilhosMaiores
        {
            get { return nrFilhosMaiores; }
            set { nrFilhosMaiores = value; }
        }

    }
}
