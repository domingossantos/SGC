using System;
using System.Text;

namespace Modelos
{
    public class PagamentoCorrentista
    {
        int idPagamentoCorrentista;

        public int IdPagamentoCorrentista
        {
            get { return idPagamentoCorrentista; }
            set { idPagamentoCorrentista = value; }
        }
        string nrCPFCNPJ;

        public string NrCPFCNPJ
        {
            get { return nrCPFCNPJ; }
            set { nrCPFCNPJ = value; }
        }
        int idMovimento;

        public int IdMovimento
        {
            get { return idMovimento; }
            set { idMovimento = value; }
        }
        DateTime dtPagamentoCorrentista;

        public DateTime DtPagamentoCorrentista
        {
            get { return dtPagamentoCorrentista; }
            set { dtPagamentoCorrentista = value; }
        }
        double vlPagamentoCorrentista;

        public double VlPagamentoCorrentista
        {
            get { return vlPagamentoCorrentista; }
            set { vlPagamentoCorrentista = value; }
        }
    }
}
