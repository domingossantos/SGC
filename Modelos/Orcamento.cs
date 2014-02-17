using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos
{
    public class Orcamento
    {
        private int idOrcamento;

        public int IdOrcamento
        {
            get { return idOrcamento; }
            set { idOrcamento = value; }
        }
        private DateTime dtTransacao;

        public DateTime DtTransacao
        {
            get { return dtTransacao; }
            set { dtTransacao = value; }
        }
        private double vlTransacao;

        public double VlTransacao
        {
            get { return vlTransacao; }
            set { vlTransacao = value; }
        }
        private double vlVenal;

        public double VlVenal
        {
            get { return vlVenal; }
            set { vlVenal = value; }
        }
        private string dsEndereco;

        public string DsEndereco
        {
            get { return dsEndereco; }
            set { dsEndereco = value; }
        }
        private string dsContato;

        public string DsContato
        {
            get { return dsContato; }
            set { dsContato = value; }
        }
        private string nrFoneContato;

        public string NrFoneContato
        {
            get { return nrFoneContato; }
            set { nrFoneContato = value; }
        }
        private string dsObservacao;

        public string DsObservacao
        {
            get { return dsObservacao; }
            set { dsObservacao = value; }
        }
        private char tpEscritura;

        public char TpEscritura
        {
            get { return tpEscritura; }
            set { tpEscritura = value; }
        }

        private int idTipoEscritura;

        public int IdTipoEscritura
        {
            get { return idTipoEscritura; }
            set { idTipoEscritura = value; }
        }


    }
}
