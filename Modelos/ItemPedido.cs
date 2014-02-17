using System;
using System.Text;

namespace Modelos
{
    public class ItemPedido
    {
        private int idItemPedido;

        public int IdItemPedido
        {
            get { return idItemPedido; }
            set { idItemPedido = value; }
        }
        private int nrPedido;

        public int NrPedido
        {
            get { return nrPedido; }
            set { nrPedido = value; }
        }
        private int cdAto;

        public int CdAto
        {
            get { return cdAto; }
            set { cdAto = value; }
        }
        private double vlItem;

        public double VlItem
        {
            get { return vlItem; }
            set { vlItem = value; }
        }
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
        private String nrCartao;

        public String NrCartao
        {
            get { return nrCartao; }
            set { nrCartao = value; }
        }
        private String nrProcesso;

        public String NrProcesso
        {
            get { return nrProcesso; }
            set { nrProcesso = value; }
        }
        private char tpReconhecimento;

        public char TpReconhecimento
        {
            get { return tpReconhecimento; }
            set { tpReconhecimento = value; }
        }
        private int idMovimentoBanco;

        public int IdMovimentoBanco
        {
            get { return idMovimentoBanco; }
            set { idMovimentoBanco = value; }
        }
    }
}
