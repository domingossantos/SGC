using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos
{
    public class ItemOrcamento
    {
        private int idOrcamento;

        public int IdOrcamento
        {
            get { return idOrcamento; }
            set { idOrcamento = value; }
        }

        private int cdAto;

        public int CdAto
        {
            get { return cdAto; }
            set { cdAto = value; }
        }

        private int nrQuantidade;

        public int NrQuantidade
        {
            get { return nrQuantidade; }
            set { nrQuantidade = value; }
        }
        private double vlTotal;

        public double VlTotal
        {
            get { return vlTotal; }
            set { vlTotal = value; }
        }
        private char stRegistro;

        public char StRegistro
        {
            get { return stRegistro; }
            set { stRegistro = value; }
        }
        private string dsLogin;

        public string DsLogin
        {
            get { return dsLogin; }
            set { dsLogin = value; }
        }
    }
}
