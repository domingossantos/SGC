using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class AtoOperacao
    {
        private int cdAto;

        public int CdAto
        {
            get { return cdAto; }
            set { cdAto = value; }
        }

        private String dsAto;

        public String DsAto
        {
            get { return dsAto; }
            set { dsAto = value; }
        }

        private double vlAto;

        public double VlAto
        {
            get { return vlAto; }
            set { vlAto = value; }
        }

        private int cdTipoDocumento;

        public int CdTipoDocumento
        {
            get { return cdTipoDocumento; }
            set { cdTipoDocumento = value; }
        }

        private int cdUso;

        public int CdUso
        {
            get { return cdUso; }
            set { cdUso = value; }
        }

        private String cdTJAto;

        public String CdTJAto
        {
            get { return cdTJAto; }
            set { cdTJAto = value; }
        }

        private int vlPercentual;

        public int VlPercentual
        {
            get { return vlPercentual; }
            set { vlPercentual = value; }
        }

        private char tpAto;

        public char TpAto
        {
            get { return tpAto; }
            set { tpAto = value; }
        }

        private string cdPlanoContas;

        public string CdPlanoContas
        {
            get { return cdPlanoContas; }
            set { cdPlanoContas = value; }
        }

        private char stRegistro;

        public char StRegistro
        {
            get { return stRegistro; }
            set { stRegistro = value; }
        }

        private char stRepeticao;

        public char StRepeticao
        {
            get { return stRepeticao; }
            set { stRepeticao = value; }
        }
    }
}
